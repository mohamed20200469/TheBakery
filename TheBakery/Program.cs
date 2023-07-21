using Data.SQL;
using ITheBakery.DAL;
using TheBakery.DAL;
using ITheBakery.Services;
using Microsoft.EntityFrameworkCore;
using TheBakery.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ProductDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSQLConnection"));
});
builder.Services.AddDbContext<OrderDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSQLConnection"));
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRazorPages();

builder.Services.AddTransient<IProductServices, ProductServices>();
builder.Services.AddTransient<IProductDAL, ProductDAL>();
builder.Services.AddTransient<IOrderServices, OrderServices>();
builder.Services.AddTransient<IOrderDAL, OrderDAL>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
