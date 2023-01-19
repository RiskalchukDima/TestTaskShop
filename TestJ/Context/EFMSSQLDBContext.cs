namespace TestJ.Context
{
    using Microsoft.EntityFrameworkCore;
    using TestJ.Models;

    public class EFMSSQLDBContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sale { get; set; }
        public DbSet<SaleItem> SaleItem { get; set; }
        public EFMSSQLDBContext(DbContextOptions<EFMSSQLDBContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();   
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Property(b => b.Price).HasColumnType("decimal(5,2)");
            modelBuilder.Entity<Sale>().Property(b => b.SaleAmount).HasColumnType("decimal(5,2)");

            //Ініціалізуємо продукти
            Product orange = new Product { Id = 11, Name = "Orange", Category = "Fruit", Art = "112", Price = 12.60m };
            Product egg = new Product { Id = 12, Name = "Egg", Category = "Meal", Art = "113", Price = 6.70m };
            Product banana = new Product { Id = 13, Name = "Banana", Category = "Fruit", Art = "114", Price = 8m };

            //Ініціалізуємо клієнтів
            Client tom = new Client { Id = 1, Fio = "Tom", BirthDate = new DateTime(1980, 12, 25), RegDate = new DateTime(2020, 12, 11) };
            Client alice = new Client { Id = 2, Fio = "Alice", BirthDate = new DateTime(1983, 11, 27), RegDate = new DateTime(2019, 8, 7) };
            Client sam = new Client { Id = 3, Fio = "Sam", BirthDate = new DateTime(1983, 11, 27), RegDate = new DateTime(2020, 3, 2) };

            //Ініціалізуємо покупки
            Sale first = new Sale { Id = 31, Nmr = 3331, SaleDate = new DateTime(2023, 1, 3), SaleAmount = 0, ClientId = tom.Id };
            Sale second = new Sale { Id = 32, Nmr = 3332, SaleDate = new DateTime(2023, 1, 5), SaleAmount = 0, ClientId = tom.Id };
            Sale third = new Sale { Id = 33, Nmr = 3333, SaleDate = new DateTime(2023, 1, 7), SaleAmount = 0, ClientId = alice.Id };
            Sale fourth = new Sale { Id = 34, Nmr = 3334, SaleDate = new DateTime(2023, 1, 11), SaleAmount = 0, ClientId = sam.Id };

            SaleItem first1 = new SaleItem { Id = 311, SaleId = first.Id, ProductId = orange.Id, Count=5};
            SaleItem first2 = new SaleItem { Id = 312, SaleId = first.Id, ProductId = egg.Id, Count = 7 };
            SaleItem first3 = new SaleItem { Id = 313, SaleId = first.Id, ProductId = banana.Id, Count = 3 };

            SaleItem second1 = new SaleItem { Id = 321, SaleId = second.Id, ProductId = orange.Id, Count = 3 };
            SaleItem second2 = new SaleItem { Id = 322, SaleId = second.Id, ProductId = egg.Id, Count = 6 };          

            SaleItem third1 = new SaleItem { Id = 331, SaleId = third.Id, ProductId = orange.Id, Count = 11 };
            SaleItem third2 = new SaleItem { Id = 332, SaleId = third.Id, ProductId = banana.Id, Count = 13 };

            SaleItem fourth1 = new SaleItem { Id = 341, SaleId = fourth.Id, ProductId = banana.Id, Count = 55 };       

            first.SaleAmount = first1.Count * orange.Price + first2.Count * egg.Price + first3.Count * banana.Price;
            second.SaleAmount = second1.Count * orange.Price + second2.Count * egg.Price;
            third.SaleAmount = third1.Count * orange.Price + third2.Count * banana.Price;
            fourth.SaleAmount = fourth1.Count * banana.Price;

            modelBuilder.Entity<Client>().HasData(tom, alice, sam);
            modelBuilder.Entity<Product>().HasData(orange, egg, banana);
            modelBuilder.Entity<Sale>().HasData(first, second, third, fourth);
            modelBuilder.Entity<SaleItem>().HasData(first1, first2, first3,second1,second2,third1,third2,fourth1);
        }
    }
}
