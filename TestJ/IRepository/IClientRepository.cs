using Microsoft.AspNetCore.Mvc;
using TestJ.Models;

namespace TestJ
{
	public interface IClientRepository
	{
		IEnumerable<Client> Get();
		Client Get(int id);
		void Create(Client item);
		void Update(Client item);
		Client Delete(int id);
	}
}
