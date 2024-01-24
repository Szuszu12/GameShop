using AutoMapper;
using GameShop.Dto;
using GameShop.Interfaces;
using GameShop.Models;
using GameShop.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace GameShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IGameRepository _gameRepository;
        private readonly IMapper _mapper;

        public OrderController(IOrderRepository orderRepository, IGameRepository gameRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _gameRepository = gameRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Order>))]
        public IActionResult GetOrders()
        {
            var orders = _mapper.Map<List<OrderDto>>(_orderRepository.GetOrders());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(orders);
        }

        [HttpGet("{orderId}")]
        [ProducesResponseType(200, Type = typeof(Order))]
        [ProducesResponseType(400)]
        public IActionResult GetOrder(int orderId)
        {
            if (!_orderRepository.OrderExists(orderId))
                return NotFound();

            var order = _mapper.Map<OrderDto>(_orderRepository.GetOrder(orderId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(order);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateOrder([FromBody] OrderDto orderCreate)
        {
            if (orderCreate == null)
                return BadRequest(ModelState);

            var orders = _orderRepository.GetOrders()
                .Where(o => o.OrderNumber.Trim().ToUpper() == orderCreate.OrderNumber.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (orders != null)
            {
                ModelState.AddModelError("", "Takie zamówienie już istnieje");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var orderMap = _mapper.Map<Order>(orderCreate);

            if (!_orderRepository.CreateOrder(orderMap))
            {
                ModelState.AddModelError("", "Coś poszło nie tak podczas zapisu");
                return StatusCode(500, ModelState);
            }

            return Ok("Pomyślnie utworzono");
        }

        [HttpPut("{orderId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateOrder(int orderId, [FromBody] OrderDto updatedOrder)
        {
            if (updatedOrder == null)
                return BadRequest(ModelState);

            if (orderId != updatedOrder.Id)
            {
                return BadRequest(ModelState);
            }

            if (!_orderRepository.OrderExists(orderId))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var orderMap = _mapper.Map<Order>(updatedOrder);

            if (!_orderRepository.UpdateOrder(orderMap))
            {
                ModelState.AddModelError("", "Coś poszło nie tak podczas aktualizowania danych zamówienia");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{orderId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteOrder(int orderId)
        {
            if (!_orderRepository.OrderExists(orderId))
            {
                return NotFound();
            }

            var orderToDelete = _orderRepository.GetOrder(orderId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_orderRepository.DeleteOrder(orderToDelete))
            {
                ModelState.AddModelError("", "Coś poszło nie tak podczas usuwania zamówienia");
            }

            return NoContent();
        }
    }
}
