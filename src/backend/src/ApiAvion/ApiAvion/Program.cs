using System.Text;
using ApiAvion.Data;
using ApiAvion.Context;
using ApiAvion.Interfaces;
using ApiAvion.Interfaces.Services;
using ApiAvion.Mappings;
using ApiAvion.Repositories.Aviones;
using ApiAvion.Repositories.Usuarios;
using ApiAvion.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ContextDb = ApiAvion.Context.ContextDb;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Authentication whit Bearer scheme",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});







builder.Services.AddDbContext<ContextDb>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexionDb"));
});
builder.Services.AddScoped<IAvionesRepository, AvionesRepository>();
builder.Services.AddScoped<IAvionesService, AvionesServices>();

builder.Services.AddScoped<IUsuariosRespository, UsuarioRepository>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
        };
    });

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyHeader()
            .AllowAnyOrigin()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();