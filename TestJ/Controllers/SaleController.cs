using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestJ.IRepository;
using TestJ.Models;

namespace TestJ.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class SaleController : Controller
	{
		ISaleRepository SaleRepository;

		public SaleController(ISaleRepository todoRepository)
		{
			SaleRepository = todoRepository;
		}

		[HttpGet("GetAllSales", Name = "GetAllSales")]
		public IActionResult GetAllSales()
		{
			return Ok(SaleRepository.Get());
		}

		[HttpGet("GetSaleById/{id}", Name = "GetSaleById")]
		public IActionResult GetSaleById(int id)
		{
			Sale todoItem = SaleRepository.Get(id);

			if (todoItem == null)
			{
				return NotFound();
			}

			return Ok(todoItem);
		}

		[HttpPost("CreateSale")]
		public IActionResult Create([FromBody] Sale todoItem)
		{
			if (todoItem == null)
			{
				return BadRequest();
			}
			SaleRepository.Create(todoItem);
			return CreatedAtRoute(nameof(GetSaleById), new { id = todoItem.Id }, todoItem);
		}

		[HttpPut("UpdateSale/{id}")]
		public IActionResult Update(int id, [FromBody] Sale updatedTodoItem)
		{
			if (updatedTodoItem == null || updatedTodoItem.Id != id)
			{
				return BadRequest();
			}

			var todoItem = SaleRepository.Get(id);
			if (todoItem == null)
			{
				return NotFound();
			}

			SaleRepository.Update(updatedTodoItem);
			return Ok(SaleRepository.Get(id));
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			var deletedTodoItem = SaleRepository.Delete(id);

			if (deletedTodoItem == null)
			{
				return BadRequest();
			}

			return new ObjectResult(deletedTodoItem);
		}
	}
}
