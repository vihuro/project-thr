using API.ESTOQUE_GRM_MATRIZ;
using API.ESTOQUE_GRM_MATRIZ.ContextBase;
using API.ESTOQUE_GRM_MATRIZ.Interface;
using API.ESTOQUE_GRM_MATRIZ.MessageConsumer;
using API.ESTOQUE_GRM_MATRIZ.Service.Estoque;
using API.ESTOQUE_GRM_MATRIZ.Service.Mapper.Estoque;
using API.ESTOQUE_GRM_MATRIZ.Service.Mapper.Locale;
using API.ESTOQUE_GRM_MATRIZ.Service.Mapper.Movimentacao;
using API.ESTOQUE_GRM_MATRIZ.Service.Mapper.Substituto;
using API.ESTOQUE_GRM_MATRIZ.Service.Mapper.Tipo;
using API.ESTOQUE_GRM_MATRIZ.Service.User;
using API.ESTOQUE_GRM_MATRIZ.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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




//Context
var connectionString = builder.Configuration.GetConnectionString("estoque_grm_matriz");
builder.Services.AddEntityFrameworkNpgsql()
    .AddDbContext<Context>(op =>
    {
        op.UseNpgsql(connectionString);
    });

var postgres = new DbContextOptionsBuilder<Context>().UseNpgsql(connectionString);

//service

builder.Services.Configure<RabbitMQConfig>(builder.Configuration.GetSection("RabbitMQConfig"));

builder.Services.AddScoped<ILocaleService, LocaleService>();
builder.Services.AddScoped<IEstoqueService, EstoqueService>();
builder.Services.AddScoped<ITipoService, TipoService>();
builder.Services.AddScoped<ISubstitutosService, SubstitutosService>();
builder.Services.AddScoped<IMovimentacaoService, MovimentacaoService>();
builder.Services.AddScoped<IUserService, UserService>();

//mapping
builder.Services.AddAutoMapper(x =>
{
    x.AddProfile(typeof(EstoqueMapping));
    x.AddProfile(typeof(LocaleMapping));
    x.AddProfile(typeof(TipoMapping));
    x.AddProfile(typeof(SubstitutoMapping));
    x.AddProfile(typeof(MovimentacaoMapping));
});

//

builder.Services.AddHostedService<RabbitMQMessageConsumerTeste>();

builder.Services.AddSingleton(new UserService(postgres.Options));


//JWT
var appSettingsSection = builder.Configuration.GetSection("AppSettings");
builder.Services.Configure<AppSettings>(appSettingsSection);

var appSettings = appSettingsSection.Get<AppSettings>();

var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(appSettings.Secret));

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = key,
        ValidateIssuer = false,
        ValidateAudience = false,
        ClockSkew = TimeSpan.Zero

    };
});

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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
