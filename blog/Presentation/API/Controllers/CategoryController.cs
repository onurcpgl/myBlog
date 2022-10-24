using Application.DataTransferObject;
using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost("/category")]
        public async Task<IActionResult> AddCategory([FromBody] CategoryDto categoryDto)
        {
            var result = await _categoryService.saveCategory(categoryDto);
            if (!result)
            {
                return BadRequest();
            }
            else
            {
                return Ok(true);
            }
        }


        [HttpGet("/category/{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var category = await _categoryService.getCategoryById(id);
            return Ok(category);
        }

        [HttpGet("/categories")]
        public async Task<IActionResult> CategoryList()
        {
            var result = await _categoryService.categoryList();
            return Ok(result);
        }
    }
}
