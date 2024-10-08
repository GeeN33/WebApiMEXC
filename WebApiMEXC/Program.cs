using Npgsql;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IDbConnection>((s) =>
{
    IDbConnection conn = new NpgsqlConnection(builder.Configuration.GetConnectionString("DefaultConnection"));
    conn.Open();
    return conn;
});

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.MapGet("/", () => "Hi GeeN!");

app.Run();
