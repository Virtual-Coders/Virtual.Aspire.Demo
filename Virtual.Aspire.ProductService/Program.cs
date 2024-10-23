using Microsoft.EntityFrameworkCore;
using Virtual.Aspire.ProductService.Entities;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddProblemDetails();
builder.Services.AddDbContext<ProductContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("ProductConnection")));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.MapDefaultEndpoints();

app.Run();
