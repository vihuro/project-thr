using API.ASSISTENCIA_TECNICA_OS.ContextBase;
using API.ASSISTENCIA_TECNICA_OS.Interface;
using API.ASSISTENCIA_TECNICA_OS.Service.Client;
using API.ASSISTENCIA_TECNICA_OS.Service.Mapper;
using API.ASSISTENCIA_TECNICA_OS.Service.Mapper.Client;
using API.ASSISTENCIA_TECNICA_OS.Service.Mapper.Maquina;
using API.ASSISTENCIA_TECNICA_OS.Service.Mapper.MaquinaInCliente;
using API.ASSISTENCIA_TECNICA_OS.Service.Mapper.OrdemServico;
using API.ASSISTENCIA_TECNICA_OS.Service.Maquina;
using API.ASSISTENCIA_TECNICA_OS.Service.MaquinaCliente;
using API.ASSISTENCIA_TECNICA_OS.Utils;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(x => x.AddPolicy("corsPolicy", build =>
{
    build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));
//services
builder.Services.AddScoped<IClientInteService, ClientService>();
builder.Services.AddScoped<IMaquinaService, MaquinaService>();
builder.Services.AddScoped<IMaquinaClienteService, MaquinaClienteService>();

//context
var connectionString = builder.Configuration.GetConnectionString("assistencia-tecnica-os");
builder.Services.AddEntityFrameworkNpgsql()
    .AddDbContext<Context>(op =>
    {
        op.UseNpgsql(connectionString);
    });
builder.Services.AddAutoMapper(x =>
{
    x.AddProfile(typeof(OrdemServicoMapping));
    x.AddProfile(typeof(MaquinaMapping));
    x.AddProfile(typeof(ClientMapping));
    x.AddProfile(typeof(MaquinaInClienteMapping));
});

var environment = builder.Environment.EnvironmentName;

var filePath = builder.Configuration.Get<FilePath>();
filePath.Caminho = builder.Configuration.GetSection("variables:FileNOTA")[environment];

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("corsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
