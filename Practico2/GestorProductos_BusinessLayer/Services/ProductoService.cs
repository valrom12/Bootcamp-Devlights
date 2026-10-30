using GestorProductos_BusinessLayer.DTOs;
using GestorProductos_DataAccessLayer.Models;
using GestorProductos_DataAccessLayer.Repositories;

namespace GestorProductos_BusinessLayer.Services;

public class ProductoService : IProductoService
{
    private readonly IProductoRepository _repository;

    public ProductoService(IProductoRepository repository)
    {
        _repository = repository;
    }

    public List<ProductoDto> ObtenerTodos()
    {
        var entidades = _repository.ObtenerTodos();
        return entidades.Select(e => new ProductoDto
        {
            Id = e.Id,
            Nombre = e.Nombre,
            Precio = e.Precio,
            Categoria = e.Categoria,
            Activo = e.Activo
        }).ToList();
    }

    public ProductoDto? ObtenerPorId(int id)
    {
        var e = _repository.ObtenerPorId(id);
        if (e == null) return null;

        return new ProductoDto
        {
            Id = e.Id,
            Nombre = e.Nombre,
            Precio = e.Precio,
            Categoria = e.Categoria,
            Activo = e.Activo
        };
    }

    public ProductoDto Agregar(CreateProductoDto dto)
    {
        var nuevaEntidad = new Producto
        {
            Nombre = dto.Nombre,
            Precio = dto.Precio,
            Categoria = dto.Categoria,
            Activo = dto.Activo
        };

        var entidadCreada = _repository.Agregar(nuevaEntidad);

        return new ProductoDto
        {
            Id = entidadCreada.Id,
            Nombre = entidadCreada.Nombre,
            Precio = entidadCreada.Precio,
            Categoria = entidadCreada.Categoria,
            Activo = entidadCreada.Activo
        };
    }

    public bool Actualizar(int id, CreateProductoDto dto)
    {
        var entidadActualizada = new Producto
        {
            Id = id,
            Nombre = dto.Nombre,
            Precio = dto.Precio,
            Categoria = dto.Categoria,
            Activo = dto.Activo
        };
        return _repository.Actualizar(entidadActualizada);
    }

    public bool Eliminar(int id)
    {
        return _repository.Eliminar(id);
    }
}