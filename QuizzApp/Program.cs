using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using QuizzApp.Common.Interfaces.Authentication;
using QuizzApp.Interfaces.Persistance;
using QuizzApp.Interfaces.Persistence;
using QuizzApp.Interfaces.Services;
using QuizzApp.Persistance.Repostiory;

ConfigurationManager configurationManager = new();
configurationManager.SetBasePath(Directory.GetCurrentDirectory());
configurationManager.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
var jwtSettings = new JwtSettings();
configurationManager.Bind("JwtSettings", jwtSettings);
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();  
builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
builder.Services.AddScoped<IUserRepository, SqlUserRepository>();
builder.Services.AddScoped<IQuestionService, QuestionService>();
builder.Services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddSingleton(Options.Create(jwtSettings));
builder.Services.AddDbContext<QuizzAppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings.Issuer,
        ValidAudience = jwtSettings.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(jwtSettings.Secret))
    };
});

var app = builder.Build();
app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseHttpsRedirection();  
app.MapControllers(); 
app.Run();