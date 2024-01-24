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
    public class ClientController : Controller
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public ClientController(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Client>))]
        public IActionResult GetClients()
        {
            var clients = _mapper.Map<List<ClientDto>>(_clientRepository.GetClients());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(clients);
        }

        [HttpGet("{clientId}")]
        [ProducesResponseType(200, Type = typeof(Client))]
        [ProducesResponseType(400)]
        public IActionResult GetClient(int clientId)
        {
            if (!_clientRepository.ClientExists(clientId))
                return NotFound();

            var client = _mapper.Map<ClientDto>(_clientRepository.GetClient(clientId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(client);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateClient([FromBody] ClientDto clientCreate)
        {
            if (clientCreate == null)
                return BadRequest(ModelState);

            var client = _clientRepository.GetClients()
                .Where(c => c.Name.Trim().ToUpper() == clientCreate.Name.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (client != null)
            {
                ModelState.AddModelError("", "Taki klient już istnieje");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var clientMap = _mapper.Map<Client>(clientCreate);

            if (!_clientRepository.CreateClient(clientMap))
            {
                ModelState.AddModelError("", "Coś poszło nie tak podczas zapisu");
                return StatusCode(500, ModelState);
            }

            return Ok("Pomyślnie utworzono");
        }

        [HttpPut("{clientId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateClient(int clientId, [FromBody] ClientDto updatedClient)
        {
            if (updatedClient == null)
                return BadRequest(ModelState);

            if (clientId != updatedClient.Id)
            {
                return BadRequest(ModelState);
            }

            if (!_clientRepository.ClientExists(clientId))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var clientMap = _mapper.Map<Client>(updatedClient);

            if (!_clientRepository.UpdateClient(clientMap))
            {
                ModelState.AddModelError("", "Coś poszło nie tak podczas aktualizowania danych klienta");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{clientId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteClient(int clientId)
        {
            if (!_clientRepository.ClientExists(clientId))
            {
                return NotFound();
            }

            var clientToDelete = _clientRepository.GetClient(clientId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_clientRepository.DeleteClient(clientToDelete))
            {
                ModelState.AddModelError("", "Coś poszło nie tak podczas usuwania klienta");
            }

            return NoContent();
        }
    }
}
