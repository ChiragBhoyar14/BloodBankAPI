using BloodBank.Comman;
using BloodBank.IRepository;
using BloodBank.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//JWT Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => {
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
        ClockSkew = TimeSpan.Zero  

    };
});


var ConnectionString = builder.Configuration["ConnectionStrings:BloodBankString"];
var Key = builder.Configuration["Security:Key"];
var IV = builder.Configuration["Security:IV"];

builder.Services.AddSingleton(_ => new AppDb(ConnectionString, Key, IV));
builder.Services.AddSingleton<IBloodDoner, BloodDoner>();

var JWDKey = builder.Configuration["Jwt:Key"];
var Issuer = builder.Configuration["Jwt:Issuer"];
var Audience = builder.Configuration["Jwt:Audience"];
var ExpiryTimeExpiryTime = builder.Configuration["Jwt:ExpiryTime"];

builder.Services.AddSingleton(_ => new JWD(JWDKey, Audience, Issuer, ExpiryTimeExpiryTime));



builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
