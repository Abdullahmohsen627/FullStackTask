using System.Text;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using TaskFullStack.Context;
using TaskFullStack.IRepositories;
using TaskFullStack.IServices;
using TaskFullStack.Mapping;
using TaskFullStack.Models;
using TaskFullStack.Repositories;
using TaskFullStack.RepoUnitOfWork;
using TaskFullStack.Services;
using TaskFullStack.ServUnitOfWork;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
//builder.Services.AddDbContext<Data>(op => op.UseNpgsql(builder.Configuration.GetConnectionString("webApiDatabase")));
builder.Services.AddDbContext<Data>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("dev")));
builder.Services.AddScoped<IRepoUnitOfWork, RepoUnitOfWork>();
builder.Services.AddScoped<IServUnitOfWork, ServUnitOfWork>();

builder.Services.AddScoped<IPasswordHasher<user>, PasswordHasher<user>>();

builder.Services.AddAutoMapper(op => op.AddProfile<UserMap>());

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});


#region JWT Settings
var jwtSettings = new JwtSettings();
builder.Configuration.GetSection(nameof(jwtSettings)).Bind(jwtSettings);
builder.Services.AddSingleton(jwtSettings);
#endregion

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme=JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme=JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = jwtSettings.ValidateIssuer,
        ValidateAudience = jwtSettings.ValidateAudience,
        ValidateLifetime = jwtSettings.ValidateLifeTime,
        ValidateIssuerSigningKey = jwtSettings.ValidateIssuerSigningKey,
        ValidIssuer = jwtSettings.Issuer,
        ValidAudience = jwtSettings.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.ASCII.GetBytes(jwtSettings.Secret)
        )
    };
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(op => op.SwaggerEndpoint("/openapi/v1.json", "v1"));
}

app.UseCors();
app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
