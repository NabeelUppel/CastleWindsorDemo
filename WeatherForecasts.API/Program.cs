using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Microsoft.EntityFrameworkCore;
using WeatherForecasts.API.Installers;
using WeatherForecasts.DataAccess.Config;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var container = new WindsorContainer();
builder.Host.UseWindsorContainerServiceProvider(container);
container.Install(new MyInstaller());

//XML Configuration
//container.Install(Configuration.FromXmlFile("CWConfiguration.xml"));

//DbContext
var connectionString = builder.Configuration.GetConnectionString("Default");

//Property for key is the name of the property that is being injected. 
container.Register(Component.For<AppDbContext>().DependsOn(Property.ForKey("connectionString").Eq(connectionString)));

builder.Services.AddControllers();
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
