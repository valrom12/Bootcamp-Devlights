using Microsoft.AspNetCore.Mvc;
using GestorProductos_BusinessLayer.DTOs;
using GestorProductos_BusinessLayer.Services;

namespace GestorProductos_PresentationLayer.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductosController : ControllerBase
{
    private readonly IProductoService _service;

    public ProductosController(IProductoService service)
    {
        _service = service;
    }

    [HttpGet]
    public ActionResult<List<ProductoDto>> GetAll()
    {
        return Ok(_service.ObtenerTodos());
    }

    [HttpGet("{id:int}")]
    public ActionResult<ProductoDto> GetById([FromRoute] int id)
    {
        var producto = _service.ObtenerPorId(id);
        if (producto == null) return NotFound();
        return Ok(producto);
    }

    [HttpPost]
    public ActionResult<ProductoDto> Create([FromBody] CreateProductoDto dto)
    {
        var creado = _service.Agregar(dto);
        return CreatedAtAction(nameof(GetById), new { id = creado.Id }, creado);
    }

    [HttpPut("{id:int}")]
    public IActionResult Update([FromRoute] int id, [FromBody] CreateProductoDto dto)
    {
        var exito = _service.Actualizar(id, dto);
        if (!exito) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete([FromRoute] int id)
    {
        var exito = _service.Eliminar(id);
        if (!exito) return NotFound();
        return NoContent();
    }
}