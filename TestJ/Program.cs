using Microsoft.EntityFrameworkCore;
using TestJ;
using TestJ.Context;
using TestJ.IRepository;
using TestJ.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

string connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<EFMSSQLDBContext>(options => options.UseSqlServer(connection));

builder.Services.AddTransient<IClientRepository, ClientRepository>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<ISaleRepository, SaleRepository>();
builder.Services.AddTransient<ISaleItemRepository, SaleItemRepository>();
builder.Services.AddTransient<ITodoRepository, TodoRepository>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddMvc(options =>
{
	options.SuppressAsyncSuffixInActionNames = false;
});
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.Run();
