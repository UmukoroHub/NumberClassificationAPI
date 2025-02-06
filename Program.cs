using NumberClassificationAPI.Service;
using NumberClassificationAPI.Service.HttpService;
using System.Net.Http.Headers;
using System.Numerics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRestHelper, RestHelper>();
builder.Services.AddScoped<INumberFact, NumberFact>();

builder.Services.AddHttpClient ("", 
    client =>
    {
        client.Timeout = TimeSpan.FromMinutes(1);
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    });

builder.Services.AddCors(p => p.AddPolicy("AllowAll", policy =>
{
    policy.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("AllowAll");

app.MapControllers();

app.Run();
