using Primer_tp.Services; //agregado

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IProductoService, ProductoService>(); //agregado.

//Le indica al contenedor de dependencias de ASP.NET Core que, cada vez que una clase pida un contrato IProduc..., el FrmWrk tiene que fabricar y entregar una instancia de ProductoService.
//AddScoped crea una instancia nueva por cada solicitud y la destruye cuando termina la consulta.

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
