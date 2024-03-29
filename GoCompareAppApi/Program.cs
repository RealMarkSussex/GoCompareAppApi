using Domain.Interfaces;
using Domain.Services;
using InMemoryRepository.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(c =>
{
    c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

builder.Services.AddScoped<IQuoteService, QuoteService>();
builder.Services.AddScoped<IResultsService, ResultsService>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IVehicleService, VehicleService>();
builder.Services.AddScoped<IPriceIncreaseService, PriceIncreaseService>();


builder.Services.AddScoped<IResultsRepository, InMemoryResultsRepository>();
builder.Services.AddScoped<IQuoteRepository, InMemoryQuoteRepository>();
builder.Services.AddScoped<IVehicleRepository, InMemoryVehicleRepository>();
builder.Services.AddScoped<IAddressRepository, InMemoryAddressRepository>();
builder.Services.AddScoped<IAddressRepository, InMemoryAddressRepository>();
builder.Services.AddScoped<ICustomerRepository, InMemoryCustomerRepository>();
builder.Services.AddScoped<IPriceRepository, InMemoryPriceRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options => options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.MapControllers();

app.Run();
