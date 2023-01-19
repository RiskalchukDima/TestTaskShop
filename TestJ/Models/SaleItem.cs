namespace TestJ.Models
{
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	[Table("SaleItem")]
	public class SaleItem 
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public int SaleId { get; set; }
		[ForeignKey("SaleId")]
		public Sale? Sale { get; set; }
		public int ProductId { get; set; }
		[ForeignKey("ProductId")]
		public Product? Product { get; set; }
		public int Count { get; set; }
		
	}
}
