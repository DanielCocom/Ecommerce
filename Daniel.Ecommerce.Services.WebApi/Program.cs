using Daniel.Ecommece.Domain.Core;
using Daniel.Ecommerce.Aplicacion.Interface;
using Daniel.Ecommerce.Aplicacion.Main;
using Daniel.Ecommerce.Infrastructura.Repository;
using Daniel.Ecommerce.Infrastructure.Data;
using Daniel.Ecommerce.Infrastructure.Interface;
using Daniel.Ecommerce.Transversal.Common;
using Daniel.Ecommerce.Tranversal.Domain.Interfaces;
using AutoMapper.Configuration;
using Daniel.Ecommerce.Transversal.Mapper;
using Daniel.Ecommerce.Services.WebApi.Helpers;
using Microsoft.Extensions.Options;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Azure.Core;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
 
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IConnectionFactory, ConnectionFactory>();
builder.Services.AddScoped<ICustomerAplication, CustomerAplication>();
builder.Services.AddScoped<ICustomersDomian, CustomersDomain>();
builder.Services.AddScoped<ICustomersRepository, CustomerRepository>();
builder.Services.AddScoped<IUsuarioAplication, UsuarioAplication>();
builder.Services.AddScoped<IUsuarioDomain, UsuarioDomain>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();


var appSettingsSection = builder.Configuration.GetSection("Config");

//indexar la clase AppSettings  
var key = Encoding.ASCII.GetBytes(appSettingsSection["key"]);
Console.WriteLine(key); 

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
    x.Events = new JwtBearerEvents
    {
        //verificar validar el token
        OnTokenValidated = context =>
        {
            var userName = context.Principal.Identity.Name;
            return Task.CompletedTask;
        },
        OnAuthenticationFailed = context =>
        {
            if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
            {
                context.Response.Headers.Add( "Token-Expired", value: "True");
            }
            return Task.CompletedTask;
        }
    };
    x.RequireHttpsMetadata = true;
    x.SaveToken = false;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateIssuer = false,
        ValidateAudience = false,
        
        IssuerSigningKey = new SymmetricSecurityKey(key),
       
       
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero,
        // Asegúrate de que ValidateIssuer y ValidateAudience estén configurados correctamente

    };
});


builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Mi API", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header usando el esquema Bearer. Ejemplo: 'Authorization: Bearer {token}'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header,
            },
            new List<string>()
        }
    });
});





// mapear las propiedades del archivo a mi clase
builder.Services.Configure<AppSettings>(appSettingsSection); 


//inyectar clase junto con sus propiedades
builder.Services.AddSingleton(resolver => resolver.GetRequiredService<IOptions<AppSettings>>().Value);




builder.Services.AddAutoMapper(typeof(MappingsProfile).Assembly);



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

    app.MapControllers();

app.Run();
