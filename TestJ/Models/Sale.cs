namespace TestJ.Models
{
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	[Table("Sale")]
	public class Sale 
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public int Nmr { get; set; }
		public DateTime SaleDate { get; set; }
		public decimal SaleAmount { get; set; }
		public int ClientId { get; set; }
		[ForeignKey("ClientId")]
		public Client? Client	{ get; set; }
	}
}
