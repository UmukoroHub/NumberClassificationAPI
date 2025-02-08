using NumberClassificationAPI.Service;
using NumberClassificationAPI.Service.HttpService;
using System.Net.Http.Headers;
using System.Numerics;

var builder = WebApplication.CreateBuilder(args);

// Set the default port to 8080 for Render but allow local access
var port = Environment.GetEnvironmentVariable("PORT") ?? "5000";
var localhostUrl = $"http://localhost:{port}";

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRestHelper, RestHelper>();
builder.Services.AddScoped<INumberFact, NumberFact>();

builder.Services.AddHttpClient("", client =>
{
    client.Timeout = TimeSpan.FromMinutes(1);
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// Allow local development access
if (app.Environment.IsDevelopment())
{
    app.Urls.Add(localhostUrl);
}
else
{
    app.Urls.Add($"http://*:{port}"); // For Render
}

// Enable Swagger always (important for ngrok testing)
app.UseSwagger();
app.UseSwaggerUI();

// Uncomment if you want HTTPS, but disable if ngrok causes issues
// app.UseHttpsRedirection(); 

app.UseAuthorization();
app.UseCors("AllowAll");
app.MapControllers();
app.Run();
