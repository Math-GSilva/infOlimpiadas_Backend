using infOlimpiadas.Infra;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AtletaDbContext>();
builder.Services.AddDbContext<MedalhaDbContext>();
builder.Services.AddDbContext<ModalidadeDbContext>();
builder.Services.AddDbContext<PaisDbContext>();
builder.Services.AddDbContext<UsuarioDbContext>();

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
