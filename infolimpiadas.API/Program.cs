using infolimpiadas.Domain.Repository;
using infolimpiadas.Domain.Service;
using infolimpiadas.Repository;
using infolimpiadas.Service;
using infOlimpiadas.Infra;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("DefaultCors",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
            };
        });


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AtletaDbContext>();
builder.Services.AddDbContext<MedalhaDbContext>();
builder.Services.AddDbContext<ModalidadeDbContext>();
builder.Services.AddDbContext<PaisDbContext>();
builder.Services.AddDbContext<UsuarioDbContext>();
builder.Services.AddScoped<IAtletaRepository, AtletaRepository>();
builder.Services.AddScoped<IMedalhaRepository, MedalhaRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("DefaultCors");

app.MapControllers();

app.Run();
