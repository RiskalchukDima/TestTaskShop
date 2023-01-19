using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestJ.IRepository;
using TestJ.Models;

namespace TestJ.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ProductController : Controller
	{
		IProductRepository ProductRepository;

		public ProductController(IProductRepository todoRepository)
		{
			ProductRepository = todoRepository;
		}

		[HttpGet("GetAllProducts", Name = "GetAllProducts")]
		public IActionResult Get()
		{
			return Ok(ProductRepository.Get());
		}

		[HttpGet("GetProductById/{id}", Name = "GetProductById")]
		public IActionResult GetProductById(int id)
		{
			Product todoItem = ProductRepository.Get(id);

			if (todoItem == null)
			{
				return NotFound();
			}

			return Ok(todoItem);
		}

		[HttpPost("CreateProduct")]
		public IActionResult Create([FromBody] Product todoItem)
		{
			if (todoItem == null)
			{
				return BadRequest();
			}
			ProductRepository.Create(todoItem);
			return CreatedAtRoute(nameof(GetProductById), new { id = todoItem.Id }, todoItem);
		}

		[HttpPut("UpdateProduct/{id}")]
		public IActionResult Update(int id, [FromBody] Product updatedTodoItem)
		{
			if (updatedTodoItem == null || updatedTodoItem.Id != id)
			{
				return BadRequest();
			}

			var todoItem = ProductRepository.Get(id);
			if (todoItem == null)
			{
				return NotFound();
			}

			ProductRepository.Update(updatedTodoItem);
			return Ok(ProductRepository.Get(id));
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			var deletedTodoItem = ProductRepository.Delete(id);

			if (deletedTodoItem == null)
			{
				return BadRequest();
			}

			return new ObjectResult(deletedTodoItem);
		}
	}
}
