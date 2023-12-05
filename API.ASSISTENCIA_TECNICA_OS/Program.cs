using API.ASSISTENCIA_TECNICA_OS.ContextBase;
using API.ASSISTENCIA_TECNICA_OS.Interface;
using API.ASSISTENCIA_TECNICA_OS.MessageConsumer;
using API.ASSISTENCIA_TECNICA_OS.Service.CEP;
using API.ASSISTENCIA_TECNICA_OS.Service.Client;
using API.ASSISTENCIA_TECNICA_OS.Service.Mapper.CEP;
using API.ASSISTENCIA_TECNICA_OS.Service.Mapper.Client;
using API.ASSISTENCIA_TECNICA_OS.Service.Mapper.Maquina;
using API.ASSISTENCIA_TECNICA_OS.Service.Mapper.MaquinaInCliente;
using API.ASSISTENCIA_TECNICA_OS.Service.Mapper.Orcamento;
using API.ASSISTENCIA_TECNICA_OS.Service.Mapper.Pecas;
using API.ASSISTENCIA_TECNICA_OS.Service.Mapper.Status;
using API.ASSISTENCIA_TECNICA_OS.Service.Mapper.Tecnico;
using API.ASSISTENCIA_TECNICA_OS.Service.Maquina;
using API.ASSISTENCIA_TECNICA_OS.Service.MaquinaCliente;
using API.ASSISTENCIA_TECNICA_OS.Service.Orcamento;
using API.ASSISTENCIA_TECNICA_OS.Service.Peca;
using API.ASSISTENCIA_TECNICA_OS.Service.Status;
using API.ASSISTENCIA_TECNICA_OS.Service.Tecnico;
using API.ASSISTENCIA_TECNICA_OS.Service.User;
using API.ASSISTENCIA_TECNICA_OS.Service.Utils;
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
builder.Services.AddScoped<IOrcamentoService, OrcamentoService>();
builder.Services.AddScoped<IClientInteService, ClientService>();
builder.Services.AddScoped<IMaquinaService, MaquinaService>();
builder.Services.AddScoped<IPecaService, PecaService>();
builder.Services.AddScoped<IMaquinaClienteService, MaquinaClienteService>();
builder.Services.AddScoped<IUserService, UserAuthService>();
builder.Services.AddScoped<IStatusService, StatusService>();
builder.Services.AddScoped<ICEPService, CEPService>();
builder.Services.AddScoped<ITecnicoService, TecnicoService>();
builder.Services.AddScoped<IPecasRadarService, PecasRadarService>();
builder.Services.AddScoped<IDiarioService, DiaroService>();
builder.Services.AddScoped<IPecasNoOrcamentoService, PecaNoOrcamentoService>();
builder.Services.AddScoped<IStatusOrcamentoService, StatusOrcamentoService>();
builder.Services.AddScoped<ReaderFile>();


var connectionString = builder.Configuration.GetConnectionString("assistencia-tecnica-os");

builder.Services.AddSingleton<IMessageConsumer, MessageConsumer>();

builder.Services.AddHostedService<ConsumerHostedService>();


//context

builder.Services.AddEntityFrameworkNpgsql()
    .AddDbContext<Context>(op =>
    {
        op.UseNpgsql(connectionString);
    });
builder.Services.AddAutoMapper(x =>
{
    x.AddProfile(typeof(OrcamentoMapping));
    x.AddProfile(typeof(MaquinaMapping));
    x.AddProfile(typeof(ClientMapping));
    x.AddProfile(typeof(MaquinaInClienteMapping));
    x.AddProfile(typeof(StatusMapping));
    x.AddProfile(typeof(CepMapping));
    x.AddProfile(typeof(PecasMapping));
    x.AddProfile(typeof(TecnicoMapping));
    x.AddProfile(typeof(DiarioOrcamentoMapping));
});


//  environment
var environment = builder.Environment.EnvironmentName;

builder.Services.Configure<AndressReports>(builder.Configuration.GetSection("AndressReportsRadar"));
builder.Services.Configure<AndressApiAuth>(builder.Configuration.GetSection("AndressApiAuth"));
builder.Services.Configure<RabbitMQConfig>(builder.Configuration.GetSection("RabbitMQConfig"));

var app = builder.Build();
try
{
    using var serviceScope = app.Services.CreateScope();
    var context = serviceScope.ServiceProvider.GetRequiredService<Context>();
    context.Database.Migrate();

}
catch (Exception ex)
{

    Console.WriteLine(ex.Message);
}

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
