using backend.connection;
using backend.entidades;
using backend.servicios;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdenReparacionController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly string? connectionString;

    public OrdenReparacionController(IConfiguration configuration)
    {
        _configuration = configuration;
        connectionString = _configuration["SqlConnectionString:DefaultConnection"];
        BDManager.GetInstance.ConnectionString = connectionString;
    }

    [HttpGet]
    [Route("GetAllOrdenReparacion")]
    public IActionResult GetAllOrdenReparacion()
    {
        try
        {
            var result = OrdenReparacionServicios.ObtenerTodo<OrdenReparacion>();
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }


    [HttpGet]
    [Route("GetOrdenReparacionById")]
    public IActionResult GetOrdenReparacionById([FromQuery] int id)
    {
        try
        {
            var result = OrdenReparacionServicios.ObtenerById<OrdenReparacion>(id);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost]
    [Route("AddOrdenReparacion")]
    public IActionResult AddOrdenReparacion(OrdenReparacion ordenReparacion)
    {
        try
        {
            var result = OrdenReparacionServicios.InsertOrdenReparacion(ordenReparacion);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPut]
    [Route("UpdateOrdenReparacion")]
    public IActionResult UpdateOrdenReparacion(OrdenReparacion ordenReparacion)
    {
        try
        {
            var result = OrdenReparacionServicios.UpdateOrdenReparacion(ordenReparacion);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete]
    [Route("DeleteOrdenReparacion")]
    public IActionResult DeleteOrdenReparacion([FromQuery]int id)
    {
        try
        {
            var result = OrdenReparacionServicios.DeleteOrdenReparacion(id);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}