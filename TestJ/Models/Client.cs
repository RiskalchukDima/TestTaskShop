namespace TestJ.Models
{
	using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Client")]
	public class Client 
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public string Fio { get; set; }
		public DateTime BirthDate { get; set; }
		public DateTime RegDate { get; set; }
	}
}
