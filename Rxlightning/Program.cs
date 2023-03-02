using System.Text;
using Rxlightning.WebApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Rxlightning.Interface;
using Rxlightning.Repository;
using Microsoft.VisualBasic;
using Rxlightning.Models;
using Rxlightning.Extensions;

var builder = WebApplication.CreateBuilder(args);

var config = builder.Configuration["PatientsDataProviderSettings:Gateway"];

builder.Services.AddCors(options => {
    options.AddPolicy("CorsPolicy", policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});


//Implementation for JWT
var jwtSettings = new JwtSettings();
builder.Configuration.Bind("JwtSettings", jwtSettings);
builder.Services.AddSingleton(jwtSettings);



builder.Services.AddHttpClient("PatientsHttpClient", httpClient =>
{
    httpClient.BaseAddress = new Uri(config);
});

builder.Services.AddJwt(jwtSettings);

builder.Services.AddScoped<IPatientsHttp, PatientsHttps>();
builder.Services.AddScoped<IUsersData, UserData>();

builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IUserAuth, UserAuth>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
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


app.UseCors("CorsPolicy");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

