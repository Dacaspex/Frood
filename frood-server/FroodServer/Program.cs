using System.Text.Json.Serialization;
using FroodServer.Authentication;
using FroodServer.Entities;
using FroodServer.Model;
using FroodServer.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter<MoodValue>());
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<FroodContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("FroodDatabase")));

builder.Services.AddScoped<ConfigurationService>();
builder.Services.AddScoped<AuthenticationService>();
builder.Services.AddScoped<ApiService>();

builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(TokenAuthenticationOptions.DefaultScheme)
    .AddScheme<TokenAuthenticationOptions, TokenAuthenticationHandler>(
        TokenAuthenticationOptions.DefaultScheme, _ => { });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(policyBuilder =>
{
    policyBuilder.AllowAnyOrigin();
    policyBuilder.AllowAnyHeader();
    policyBuilder.AllowAnyMethod();
});

app.UseHttpsRedirection();

app.MapControllers();

app.UseDefaultFiles();
app.UseStaticFiles();

app.Run();
