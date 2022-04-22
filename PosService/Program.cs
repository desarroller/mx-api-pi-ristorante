using PosService.Services;
using StorageDB;

var builder = WebApplication.CreateBuilder(args);

// Start Add services to the container.

builder.Services.Configure<StorageDBSettings>(
    builder.Configuration.GetSection("StorageDB"));

builder.Services.AddSingleton<StorageDBService>();

// End Add services to the container.

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
