using AutoMapper;
using GameShop.Data;
using GameShop.Dto;
using GameShop.Interfaces;
using GameShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace GameShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : Controller
    {
        private readonly IGameRepository _gameRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly IProducerRepository _producerRepository;

        public GameController(IGameRepository gameRepository, ICategoryRepository categoryRepository, IMapper mapper, IProducerRepository producerRepository)
        {
            _gameRepository = gameRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _producerRepository = producerRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Game>))]
        public IActionResult GetGames()
        {
            var games = _mapper.Map<List<GameDto>>(_gameRepository.GetGames());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(games);
        }

        [HttpGet("{gameId}")]
        [ProducesResponseType(200, Type = typeof(Game))]
        [ProducesResponseType(404)]
        public IActionResult GetGame(int gameId)
        {
            if (!_gameRepository.GameExists(gameId))
                return NotFound();

            var game = _mapper.Map<GameDto>(_gameRepository.GetGame(gameId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(game);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateGame([FromQuery] int producerId, [FromQuery] int categoryId, [FromBody] GameDto gameCreate)
        {
            if (gameCreate == null)
                return BadRequest(ModelState);

            var games = _gameRepository.GetGames()
                .Where(g => g.Title.Trim().ToUpper() == gameCreate.Title.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (games != null)
            {
                ModelState.AddModelError("", "Gra już istnieje");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var gameMap = _mapper.Map<Game>(gameCreate);

            //gameMap.Producer = _producerRepository.GetProducer(producerId);

            if (!_gameRepository.CreateGame(categoryId, gameMap))
            {
                ModelState.AddModelError("", "Coś poszło nie tak podczas zapisu");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpPut("{gameId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateGame(int gameId, [FromQuery] int categoryId, [FromBody] GameDto updatedGame)
        {
            if (updatedGame == null)
                return BadRequest(ModelState);

            if (gameId != updatedGame.Id)
            {
                return BadRequest(ModelState);
            }

            if (!_gameRepository.GameExists(gameId))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var gameMap = _mapper.Map<Game>(updatedGame);

            if (!_gameRepository.UpdateGame(categoryId, gameMap))
            {
                ModelState.AddModelError("", "Coś poszło nie tak podczas aktualizowania danych gry");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{gameId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteGame(int gameId)
        {
            if (!_gameRepository.GameExists(gameId))
            {
                return NotFound();
            }

            var gameToDelete = _gameRepository.GetGame(gameId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_gameRepository.DeleteGame(gameToDelete))
            {
                ModelState.AddModelError("", "Coś poszło nie tak podczas usuwania gry");
            }

            return NoContent();
        }
    }
}
