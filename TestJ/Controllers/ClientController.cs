using Microsoft.AspNetCore.Mvc;
using TestJ.ApiModels;
using TestJ.Models;

namespace TestJ
{
	[ApiController]
	[Route("api/[controller]")]
	public class ClientController : Controller
	{
		IClientRepository ClientRepository;

		public ClientController(IClientRepository todoRepository)
		{
			ClientRepository = todoRepository;
		}

		[HttpGet("GetAllClients", Name = "GetAllClients")]
		public IActionResult GetAllClients()
		{
			return Ok(ClientRepository.Get());
		}

		[HttpGet("GetClientById/{id}", Name = "GetClientById")]
		public IActionResult GetClientById(int id)
		{
			Client todoItem = ClientRepository.Get(id);

			if (todoItem == null)
			{
				return NotFound();
			}

			return Ok(todoItem);
		}

		[HttpPost("CreateClient")]
		public IActionResult Create([FromBody] Client todoItem)
		{
			if (todoItem == null)
			{
				return BadRequest();
			}
			ClientRepository.Create(todoItem);
			return CreatedAtRoute(nameof(GetClientById), new { id = todoItem.Id }, todoItem);
		}
		
		[HttpPut("UpdateClient/{id}")]
		public IActionResult Update(int id, [FromBody] Client updatedTodoItem)
		{
			if (updatedTodoItem == null || updatedTodoItem.Id != id)
			{
				return BadRequest();
			}

			var todoItem = ClientRepository.Get(id);
			if (todoItem == null)
			{
				return NotFound();
			}

			ClientRepository.Update(updatedTodoItem);
			return Ok(ClientRepository.Get(id));
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			var deletedTodoItem = ClientRepository.Delete(id);

			if (deletedTodoItem == null)
			{
				return BadRequest();
			}

			return new ObjectResult(deletedTodoItem);
		}
	}
}
