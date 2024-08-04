using BloodBank.Comman;
using BloodBank.IRepository;
using BloodBank.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var ConnectionString = builder.Configuration["ConnectionStrings:BloodBankString"];
var Key = builder.Configuration["Security:Key"];
var IV = builder.Configuration["Security:IV"];

builder.Services.AddSingleton(_ => new AppDb(ConnectionString, Key, IV));
builder.Services.AddSingleton<IBloodDoner, BloodDoner>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
