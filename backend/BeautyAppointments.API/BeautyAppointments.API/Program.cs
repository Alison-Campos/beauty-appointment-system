using BeautyAppointments.API.Models;
using BeautyAppointments.API.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("ReactPolicy",
        policy =>
        {
            policy.WithOrigins("http://localhost:5173")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//
//builder.Services.AddScoped<Usuario>();
builder.Services.AddScoped<UsuarioRepository>();
builder.Services.AddScoped<ServicioRepository>();
builder.Services.AddScoped<ClienteRepository>();
builder.Services.AddScoped<CitaRepository>();


var app = builder.Build();

app.UseCors("ReactPolicy");

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
