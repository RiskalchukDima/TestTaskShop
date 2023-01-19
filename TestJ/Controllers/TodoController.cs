using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestJ.ApiModels;
using TestJ.IRepository;
using TestJ.Models;

namespace TestJ.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class TodoController : Controller
	{
		ITodoRepository TodoRepository;

		public TodoController(ITodoRepository todoRepository)
		{
			TodoRepository = todoRepository;
		}

		[HttpGet("GetClientsBirth/{dat}")]
		public IActionResult GetClientsBirth(DateTime dat)
		{
			return Ok(TodoRepository.GetBirth(dat));
		}

		[HttpGet("GetClientsLastByN/{n}")]
		public IActionResult GetClientsLastByN(int n)
		{
			IEnumerable<Sale> sales = TodoRepository.GetLastN(n);
			var response = sales
				.GroupBy(c => new { c.Client.Id, c.Client.Fio } )
				.Select(x => new GetLastByNDays
				{
					Id = x.Key.Id,
					Fio = x.Key.Fio,
					LastDate = x.Max(h => h.SaleDate)
				})
				.ToList();

			return Ok(response);
		}
		[HttpGet("GetPopularCategories/{id}")]
		public IActionResult GetPopularCategories(int id)
		{
			IEnumerable<SaleItem> query = TodoRepository.GetPopCat(id);
			var response = query
				.GroupBy(g => g.Product.Category)
				.Select(x => new GetPopularCategories
				{
					Category = x.Key,
					CountAll = x.Sum(c => c.Count)
				})
				.ToList();

			return Ok(response);
		}
	}
}
