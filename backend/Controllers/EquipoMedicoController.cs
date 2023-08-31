using backend.connection;
using backend.entidades;
using backend.servicios;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EquipoMedicoController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly string? connectionString;

    public EquipoMedicoController(IConfiguration configuration)
    {
        _configuration = configuration;
        connectionString = _configuration["SqlConnectionString:DefaultConnection"];
        BDManager.GetInstance.ConnectionString = connectionString;
    }

    [HttpGet]
    [Route("GetAllEquipoMedico")]
    public IActionResult GetAllEquipoMedico()
    {
        try
        {
            var result = EquipoMedicoServicios.ObtenerTodo<EquipoMedico>();
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }


    [HttpGet]
    [Route("GetEquipoMedicoById")]
    public IActionResult GetEquipoMedicoById([FromQuery] int id)
    {
        try
        {
            var result = EquipoMedicoServicios.ObtenerById<EquipoMedico>(id);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost]
    [Route("AddEquipoMedico")]
    public IActionResult AddEquipoMedico(EquipoMedico equipoMedico)
    {
        try
        {
            var result = EquipoMedicoServicios.InsertEquipoMedico(equipoMedico);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPut]
    [Route("UpdateEquipoMedico")]
    public IActionResult UpdateEquipoMedico(EquipoMedico equipoMedico)
    {
        try
        {
            var result = EquipoMedicoServicios.UpdateEquipoMedico(equipoMedico);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete]
    [Route("DeleteEquipoMedico")]
    public IActionResult DeleteEquipoMedico([FromQuery]int id)
    {
        try
        {
            var result = EquipoMedicoServicios.DeleteEquipoMedico(id);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}