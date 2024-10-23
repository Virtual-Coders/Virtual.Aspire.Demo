using Microsoft.EntityFrameworkCore;
using Virtual.Aspire.UserService.Entities;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddProblemDetails();
builder.Services.AddDbContext<UserContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("UserConnection")));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.MapDefaultEndpoints();

app.Run();
