using System.Data.SQLite;

var builder = WebApplication.CreateBuilder(args);
SQLiteConnection sqlite_conn = new SQLiteConnection("Data Source=./database/test.db;Version=3;");
sqlite_conn.Open();

// Add services to the container.
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

app.UseHttpsRedirection();


app.MapGet("/noodle", () =>
{
    string statement = "SELECT * FROM NOODLE";
    using var cmd = new SQLiteCommand(statement, sqlite_conn);
    using SQLiteDataReader reader = cmd.ExecuteReader();
    reader.Read();
    return reader.GetString(1);
});

app.Run();

record Noodle(int id, string name, string flourType);

