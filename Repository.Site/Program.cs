using Repository.Data.Implementations;
using Repository.Data.Interfaces;

var builder = WebApplication.CreateBuilder(args);

//adds the DI to the IOC container.
builder.Services.AddSingleton<ICarRepository, CarRepository>();
builder.Services.AddSingleton<IPersonRepository, PersonRepository>();

//adds MVC to the application
builder.Services.AddMvc(options => { options.EnableEndpointRouting = false; });

var app = builder.Build();

app.UseMvcWithDefaultRoute();
app.Run();