using ConverterApi;
using ConverterApi.Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddLogging();

builder.Services.AddScoped<IConversionCalculator, ConversionCalculator>();
builder.Services.AddScoped<IHistoryService, HistoryService>();

var historyApiBase = builder.Configuration[ConfigValues.HistoryApi];

builder.Services.AddHttpClient(ConfigValues.HistoryApi, client =>
{
    client.BaseAddress = new Uri(historyApiBase);
});

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
app.UseCors(options =>
{
    options.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
});
app.UseAuthorization();

app.MapControllers();

app.Run();
