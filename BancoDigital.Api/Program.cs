using BancoDigital.Api.Data;
using BancoDigital.Api.GraphQL;
using BancoDigital.Api.Repositories;
using BancoDigital.Api.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddPooledDbContextFactory<AppDbContext>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

builder.Services.AddScoped<IContaRepository, ContaRepository>();
builder.Services.AddScoped<ContaService>();

builder.Services.AddGraphQLServer()
    .AddQueryType<ContaQuery>()
    .AddMutationType<ContaMutation>();



var app = builder.Build();

app.UseHttpsRedirection();

app.MapGraphQL();

app.Run();