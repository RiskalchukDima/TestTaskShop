using TestJ.Context;
using TestJ.IRepository;
using TestJ.Models;

namespace TestJ.Repositories
{
	public class ProductRepository:IProductRepository
	{
		private EFMSSQLDBContext Context;
		public ProductRepository(EFMSSQLDBContext context1)
		{
			Context = context1;
		}
		public IEnumerable<Product> Get()
		{
			return Context.Products;
		}
		public Product Get(int Id)
		{
			return Context.Products.Find(Id);
		}
		public void Create(Product item)
		{
			Context.Products.Add(item);
			Context.SaveChanges();
		}
		public void Update(Product updatedTodoItem)
		{
			Product currentItem = Get(updatedTodoItem.Id);
			currentItem.Name = updatedTodoItem.Name;
			currentItem.Category = updatedTodoItem.Category;
			currentItem.Art = updatedTodoItem.Art;
			currentItem.Price = updatedTodoItem.Price;
			Context.Products.Update(currentItem);
			Context.SaveChanges();
		}

		public Product Delete(int Id)
		{
			Product todoItem = Get(Id);

			if (todoItem != null)
			{
				Context.Products.Remove(todoItem);
				Context.SaveChanges();
			}

			return todoItem;
		}
	}
}
