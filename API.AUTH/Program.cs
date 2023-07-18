using API.AUTH.ContextBase;
using API.AUTH.Interface;
using API.AUTH.Service.JWT;
using API.AUTH.Service.Mapper.Claims;
using API.AUTH.Service.Mapper.Login;
using API.AUTH.Service.User;
using API.AUTH.Utils;
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

//context
var connectionString = builder.Configuration.GetConnectionString("auth");
builder.Services.AddEntityFrameworkNpgsql()
    .AddDbContext<Context>(op =>
    {
        op.UseNpgsql(connectionString);
    });

//services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICreateTokenService, CreateToken>();
builder.Services.AddScoped<IRefreshTokenService, RefreshTokenService>();


//mapping
builder.Services.AddAutoMapper(x =>
{
    x.AddProfile(typeof(UserMapping));
    x.AddProfile(typeof(ClaimsTypeMapping));
});

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
