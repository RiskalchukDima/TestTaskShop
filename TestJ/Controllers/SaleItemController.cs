using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestJ.IRepository;
using TestJ.Models;

namespace TestJ.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class SaleItemController : Controller
	{
		ISaleItemRepository SaleItemRepository;

		public SaleItemController(ISaleItemRepository todoRepository)
		{
			SaleItemRepository = todoRepository;
		}

		[HttpGet("GetAllSaleItems", Name = "GetAllSaleItems")]
		public IActionResult Get()
		{
			return Ok(SaleItemRepository.Get());
		}

		[HttpGet("GetSaleItemById/{id}", Name = "GetSaleItemById")]
		public IActionResult GetSaleItemById(int id)
		{
			SaleItem todoItem = SaleItemRepository.Get(id);

			if (todoItem == null)
			{
				return NotFound();
			}

			return Ok(todoItem);
		}

		[HttpPost("CreateSaleItem")]
		public IActionResult Create([FromBody] SaleItem todoItem)
		{
			if (todoItem == null)
			{
				return BadRequest();
			}
			SaleItemRepository.Create(todoItem);
			return CreatedAtRoute(nameof(GetSaleItemById), new { id = todoItem.Id }, todoItem);
		}

		[HttpPut("UpdateSaleItem/{id}")]
		public IActionResult Update(int id, [FromBody] SaleItem updatedTodoItem)
		{
			if (updatedTodoItem == null || updatedTodoItem.Id != id)
			{
				return BadRequest();
			}

			var todoItem = SaleItemRepository.Get(id);
			if (todoItem == null)
			{
				return NotFound();
			}

			SaleItemRepository.Update(updatedTodoItem);
			return Ok(SaleItemRepository.Get(id));
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			var deletedTodoItem = SaleItemRepository.Delete(id);

			if (deletedTodoItem == null)
			{
				return BadRequest();
			}

			return new ObjectResult(deletedTodoItem);
		}
	}
}
