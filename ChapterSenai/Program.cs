using ChapterSenai.Contexts;
using ChapterSenai.Interfaces;
using ChapterSenai.Repositories;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddCors(
    options =>
    {
        options.AddPolicy("CorsPolicy", policy =>
        {
            policy.WithOrigins("https://Localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
    }  
 );

builder.Services.AddAuthentication(Options =>
{
    Options.DefaultChallengeScheme = "JwtBearer";
    Options.DefaultAuthenticateScheme = "JwtBearer";
}

).AddJwtBearer("JwtBearer", Options =>

    Options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateAudience = true,
        ValidateIssuer = true,
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("chapter-chave-autenticacao")),
        ClockSkew = TimeSpan.FromMinutes(60),
        ValidAudience = "chapter.webapi",
        ValidIssuer = "chapter.webapi"
    }

);

builder.Services.AddScoped<Sqlcontext, Sqlcontext>();
builder.Services.AddTransient<LivroRepository, LivroRepository>();
builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();

// https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
