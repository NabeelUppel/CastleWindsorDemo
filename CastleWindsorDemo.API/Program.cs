using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Microsoft.EntityFrameworkCore;
using CastleWindsorDemo.API.Configs;
using CastleWindsorDemo.API.Installers;
using CastleWindsorDemo.DataAccess.Config;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var container = new WindsorContainer();
builder.Host.UseWindsorContainerServiceProvider(container);

// Register AppSettings.json ConnectionStrings to the container to be resolved when needed.
container.Register(Component.For<ConnectionStrings>().LifestyleSingleton().UsingFactoryMethod(() =>
{
    var settings = builder.Configuration.GetSection("ConnectionStrings").Get<ConnectionStrings>();
    return settings;
}));

// Register Media installer.
//container.Install(new MediaInstaller());

// Register Weather installer.
//container.Install(new WeatherForecastsInstaller());

// XML Configuration
container.Install(Configuration.FromXmlFile("CWConfiguration.xml"));

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
