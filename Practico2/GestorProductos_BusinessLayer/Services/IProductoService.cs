using GestorProductos_BusinessLayer.DTOs;

namespace GestorProductos_BusinessLayer.Services;

public interface IProductoService
{
    List<ProductoDto> ObtenerTodos();
    ProductoDto? ObtenerPorId(int id);
    ProductoDto Agregar(CreateProductoDto dto);
    bool Actualizar(int id, CreateProductoDto dto);
    bool Eliminar(int id);
}