using blue.zebra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<StoreContext>(options => 
{
    options.UseSqlite("Data Source=../Registrar.sqlite", b => b.MigrationsAssembly("blue.zebra.Api"));
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

String storeConnectionString = builder.Configuration.GetConnectionString("StoreConnection") ?? 
    throw new ArgumentNullException("ConnectionString:StoreConnection");

builder.Services.AddDbContext<StoreContext>(options => options.UseSqlServer(storeConnectionString, b => b.MigrationsAssembly("blue.zebra.Api")));

builder.Services.AddCors(options => { 
    options.AddDefaultPolicy(builder => {
        builder.WithOrigins("http://localhost:5002", "https://blue-zebra-api.azurewebsites.net/catalog")
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});