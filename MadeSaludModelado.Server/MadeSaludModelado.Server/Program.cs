using MadeSalud.BD.DATOS;
using MadeSalud.Repositorio.IRepositorios;
using MadeSalud.Repositorio.Repositorios;
using MadeSalud.Servicio.ServiciosHttp;
using MadeSaludModelado.Server.Client.Pages;
using MadeSaludModelado.Server.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System;


//CONSTRUCTOR DE LA APLICACION
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("https://localhost:7164/")
});

#region construccion 
builder.Services.AddScoped<IHttpServicio, HttpServicio>();



builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "MadeSalud API",
        Version = "v1",
        Description = "API de MadeSalud",
    });
});



var connectionString =
        builder.Configuration.GetConnectionString("ConSqlServer")
       ?? throw new InvalidOperationException(
            "No se encuentra la conexión a la base de datos.");

builder.Services.AddDbContext<AppDBContext>(
    options => options.UseSqlServer(connectionString)
);

builder.Services.AddScoped<IPacienteRepositorio, PacienteRepositorio>();
builder.Services.AddScoped<IPersonaRepositorio, PersonaRepositorio>();
builder.Services.AddScoped<IMedicoRepositorio, MedicoRepositorio>();
builder.Services.AddScoped<ISecretariaRepositorio, SecretariaRepositorio>();



builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("https://localhost:7164/") // tu URL de la API
});

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddServerSideBlazor()
    .AddCircuitOptions(options => { options.DetailedErrors = true; });
var app = builder.Build();

#endregion

#region configuracion

app.MapControllers();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "MadeSalud API V1");
        c.RoutePrefix = "swagger"; // La UI de Swagger estará en /swagger
    });

}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(MadeSaludModelado.Server.Client._Imports).Assembly);

#endregion
app.Run();
