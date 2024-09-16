using BACKENDCRUDAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using BACKENDCRUDAPI.Services.Contrato;
using BACKENDCRUDAPI.Services.Implementacion;
using AutoMapper;
using BACKENDCRUDAPI.DTOs;
using BACKENDCRUDAPI.Utilidades;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<EmpleadoasfContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("CadenaSQL"));
});
builder.Services.AddScoped<ICargoService, CargoService>();
builder.Services.AddScoped<IEmpleadoService, EmpleadoService>();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddCors(options =>
{
    options.AddPolicy("Nueva Politica", app =>
    {
        app.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.

if(app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");

});


#region PETICIONES API REST
app.MapGet("/cargo/lista", async (
    ICargoService _cargoService,
    IMapper _mapper
    ) =>
{
    var listaCargo = await _cargoService.GetList();
    var listaCargoDTO = _mapper.Map<List<CargoDTO>>(listaCargo);

    if (listaCargoDTO.Count > 0)
        return Results.Ok(listaCargoDTO);
    else
        return Results.NotFound();

});

app.MapGet("/empleado/lista", async (
    IEmpleadoService _empleadoService,
    IMapper _mapper
    ) =>
{
var listaEmpleado = await _empleadoService.GetList();
var listaEmpleadoDTO = _mapper.Map<List<EmpleadoDTO>>(listaEmpleado);

if (listaEmpleadoDTO.Count > 0)
return Results.Ok(listaEmpleadoDTO);
else
return Results.NotFound();

});

app.MapPost("/empleado/guardar", async (
    EmpleadoDTO modelo,
    IEmpleadoService _empleadoService,
    IMapper _mapper
    ) => {
        var _empleado = _mapper.Map<Empleado>(modelo);
        var _empleadoCreado = await _empleadoService.Add(_empleado);

        if(_empleadoCreado.Idempleado !=0)
            return Results.Ok(_mapper.Map<EmpleadoDTO>(_empleadoCreado));
        else
            return Results.StatusCode(StatusCodes.Status500InternalServerError);
    });

app.MapPut("/empleado/actualizar/{idEmpleado}", async(
    int IdEmpleado,
    EmpleadoDTO modelo,
    IEmpleadoService _empleadoService,
    IMapper _mapper
    ) => {

        var _encontrado = await _empleadoService.Get(IdEmpleado);
        if(_encontrado is null) return Results.NotFound();

        var _empleado= _mapper.Map<Empleado>(modelo);

        _encontrado.Nombres = _empleado.Nombres;
        _encontrado.Apellidos = _empleado.Apellidos;
        _encontrado.Afp = _empleado.Afp;
        _encontrado.Cargo = _empleado.Cargo;

        var respuesta = await _empleadoService.Update(_encontrado);

        if (respuesta)
            return Results.Ok(_mapper.Map<EmpleadoDTO>(_encontrado));
        else
            return Results.StatusCode(StatusCodes.Status500InternalServerError);

    });

app.MapDelete("/empleado/eliminar/{idEmpleado}", async (
    int idEmpleado,
    IEmpleadoService _empleadoService
    ) => {

        var _encontrado = await _empleadoService.Get(idEmpleado);

        if(_encontrado is null)return Results.NotFound();

        var respuesta = await _empleadoService.Delete(_encontrado);
        if (respuesta)
            return Results.Ok();
        else
            return Results.StatusCode(StatusCodes.Status500InternalServerError);
    });
#endregion
{

    app.UseCors("Nueva Politica");
    app.Run();

}