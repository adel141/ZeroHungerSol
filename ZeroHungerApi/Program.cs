using BLL;
using BLL.Services;
using DAL.EF;
using DAL.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<RestaurantRepo>();
builder.Services.AddScoped<FoodCollectionRequestRepo>();
builder.Services.AddScoped<FoodItemRepo>();
builder.Services.AddScoped<AssignmentRepo>();
builder.Services.AddScoped<EmployeeRepo>();
builder.Services.AddScoped<FoodItemService>();
builder.Services.AddScoped<FoodCollectionRequestService>();
builder.Services.AddScoped<EmployeeService>();
builder.Services.AddScoped<AssignmentService>();
builder.Services.AddScoped<RestaurantService>();



builder.Services.AddControllers();
builder.Services.AddDbContext<ZeroHungerContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConn")));
builder.Services.AddAutoMapper(typeof(MappingProfile));


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
