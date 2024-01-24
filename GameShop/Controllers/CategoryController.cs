using AutoMapper;
using GameShop.Data;
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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CategoryDto>))]
        public IActionResult GetCategories()
        {
            var categories = _mapper.Map<List<CategoryDto>>(_categoryRepository.GetCategories());
            return Ok(categories);
        }

        [HttpGet("{categoryId}")]
        [ProducesResponseType(200, Type = typeof(CategoryDto))]
        [ProducesResponseType(404)]
        public IActionResult GetCategory(int categoryId)
        {
            var category = _mapper.Map<CategoryDto>(_categoryRepository.GetCategory(categoryId));

            if (category == null)
                return NotFound();

            return Ok(category);
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(string))]
        [ProducesResponseType(400)]
        [ProducesResponseType(422)]
        public IActionResult CreateCategory([FromBody] CategoryDto categoryCreate)
        {
            if (categoryCreate == null)
                return BadRequest();

            var existingCategory = _categoryRepository.GetCategories()
                .FirstOrDefault(c => c.CategoryName.Trim().ToUpper() == categoryCreate.CategoryName.TrimEnd().ToUpper());

            if (existingCategory != null)
                return StatusCode(422, "Category already exists");

            var categoryMap = _mapper.Map<Category>(categoryCreate);

            if (_categoryRepository.CreateCategory(categoryMap))
                return CreatedAtAction("GetCategory", new { categoryId = categoryMap.Id }, "Successfully created");
            else
                return StatusCode(500, "Something went wrong during save");
        }

        [HttpPut("{categoryId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult UpdateCategory(int categoryId, [FromBody] CategoryDto updatedCategory)
        {
            if (updatedCategory == null || categoryId != updatedCategory.Id)
                return BadRequest();

            if (!_categoryRepository.CategoryExists(categoryId))
                return NotFound();

            var categoryMap = _mapper.Map<Category>(updatedCategory);

            if (_categoryRepository.UpdateCategory(categoryMap))
                return NoContent();
            else
                return StatusCode(500, "Something went wrong during update");
        }

        [HttpDelete("{categoryId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult DeleteCategory(int categoryId)
        {
            if (!_categoryRepository.CategoryExists(categoryId))
                return NotFound();

            var categoryToDelete = _categoryRepository.GetCategory(categoryId);

            if (_categoryRepository.DeleteCategory(categoryToDelete))
                return NoContent();
            else
                return StatusCode(500, "Something went wrong during delete");
        }
    }
}