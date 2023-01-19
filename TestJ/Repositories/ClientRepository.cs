using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestJ.Context;
using TestJ.Models;

namespace TestJ
{
	public class ClientRepository : IClientRepository
	{
		private EFMSSQLDBContext Context;
		public ClientRepository(EFMSSQLDBContext context1)
		{
			Context = context1;
		}
		public IEnumerable<Client> Get()
		{
			return Context.Clients;
		}
		public Client Get(int Id)
		{
			return Context.Clients.Find(Id);
		}
		public void Create(Client item)
		{
			Context.Clients.Add(item);
			Context.SaveChanges();
		}
		public void Update(Client updatedTodoItem)
		{
			Client currentItem = Get(updatedTodoItem.Id);
			currentItem.Fio = updatedTodoItem.Fio;
			currentItem.BirthDate = updatedTodoItem.BirthDate;
			currentItem.RegDate = updatedTodoItem.RegDate;
			Context.Clients.Update(currentItem);
			Context.SaveChanges();
		}

		public Client Delete(int Id)
		{
			Client todoItem = Get(Id);

			if (todoItem != null)
			{
				Context.Clients.Remove(todoItem);
				Context.SaveChanges();
			}

			return todoItem;
		}
	}
}
