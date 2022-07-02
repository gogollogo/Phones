using System.Reflection;
using Phones;
using Phones.Entities;
using Phones.Middleware;
using Phones.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<PhonesDbContext>();
builder.Services.AddScoped<PhoneSeeder>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddScoped<ErrorHandlingMiddleware>();
builder.Services.AddScoped<IPhoneService, PhoneService>();
builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddHttpContextAccessor();


var app = builder.Build();


var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<PhoneSeeder>();

seeder.Seed();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
