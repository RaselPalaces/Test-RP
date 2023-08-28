using backend.connection;
using backend.entidades;
using backend.servicios;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[EnableCors("DevelopmentCors")]
[ApiController]
[Route("api/[controller]")]
public class UsuariosController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly string? connectionString;

    public UsuariosController(IConfiguration configuration)
    {
        _configuration = configuration;
        connectionString = _configuration["SqlConnectionString:DefaultConnection"];
        BDManager.GetInstance.ConnectionString = connectionString;
    }

    [HttpGet]
    [Route("GetAllUsuarios")]
    public IActionResult GetAllUsuarios()
    {
        try
        {
            var result = UsuariosServicios.ObtenerTodo<Usuarios>();
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }


    [HttpGet]
    [Route("GetUsuariosById")]
    public IActionResult GetUsuariosById([FromQuery] int id)
    {
        try
        {
            var result = UsuariosServicios.ObtenerById<Usuarios>(id);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost]
    [Route("AddUsuario")]
    public IActionResult AddUsuario(Usuarios usuarios)
    {
        try
        {
            var result = UsuariosServicios.InsertUsuario(usuarios);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPut]
    [Route("UpdateUsuario")]
    public IActionResult UpdateUsuario(Usuarios usuarios)
    {
        try
        {
            var result = UsuariosServicios.UpdateUsuarios(usuarios);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete]
    [Route("DeleteUsuario")]
    public IActionResult DeleteUsuario([FromQuery]int id)
    {
        try
        {
            var result = UsuariosServicios.DeleteUsuarios(id);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}