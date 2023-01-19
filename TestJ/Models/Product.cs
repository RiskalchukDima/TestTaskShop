namespace TestJ.Models
{
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	[Table("Product")]
	public class Product 
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public string Name { get; set; }
		public string Category { get; set; }
		public string Art { get; set; }
		public decimal Price { get; set; }
	}
}
