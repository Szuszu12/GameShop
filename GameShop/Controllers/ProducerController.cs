using AutoMapper;
using GameShop.Dto;
using GameShop.Interfaces;
using GameShop.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace GameShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProducerController : Controller
    {
        private readonly IProducerRepository _producerRepository;
        private readonly IMapper _mapper;

        public ProducerController(IProducerRepository producerRepository, IMapper mapper)
        {
            _producerRepository = producerRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Producer>))]
        public IActionResult GetProducers()
        {
            var producers = _mapper.Map<List<ProducerDto>>(_producerRepository.GetProducers());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(producers);
        }

        [HttpGet("{producerId}")]
        [ProducesResponseType(200, Type = typeof(Producer))]
        [ProducesResponseType(400)]
        public IActionResult GetProducer(int producerId)
        {
            if (!_producerRepository.ProducerExists(producerId))
                return NotFound();

            var producer = _mapper.Map<ProducerDto>(_producerRepository.GetProducer(producerId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(producer);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateProducer([FromBody] ProducerDto producerCreate)
        {
            if (producerCreate == null)
                return BadRequest(ModelState);

            var producer = _producerRepository.GetProducers()
                .Where(p => p.ProducerName.Trim().ToUpper() == producerCreate.ProducerName.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (producer != null)
            {
                ModelState.AddModelError("", "Producent już istnieje");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var producerMap = _mapper.Map<Producer>(producerCreate);

            if (!_producerRepository.CreateProducer(producerMap))
            {
                ModelState.AddModelError("", "Coś poszło nie tak podczas zapisu");
                return StatusCode(500, ModelState);
            }

            return Ok("Pomyślnie utworzono");
        }

        [HttpPut("{producerId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateProducer(int producerId, [FromBody] ProducerDto updatedProducer)
        {
            if (updatedProducer == null)
                return BadRequest(ModelState);

            if (producerId != updatedProducer.Id)
            {
                return BadRequest(ModelState);
            }

            if (!_producerRepository.ProducerExists(producerId))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var producerMap = _mapper.Map<Producer>(updatedProducer);

            if (!_producerRepository.UpdateProducer(producerMap))
            {
                ModelState.AddModelError("", "Coś poszło nie tak podczas aktualizowania danych producenta");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{producerId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteProducer(int producerId)
        {
            if (!_producerRepository.ProducerExists(producerId))
            {
                return NotFound();
            }

            var producerToDelete = _producerRepository.GetProducer(producerId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_producerRepository.DeleteProducer(producerToDelete))
            {
                ModelState.AddModelError("", "Coś poszło nie tak podczas usuwania producenta");
            }

            return NoContent();
        }
    }
}
