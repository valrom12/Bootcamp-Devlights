using GestorProductos_DataAccessLayer.Models;

namespace GestorProductos_DataAccessLayer.Repositories;

public interface IProductoRepository
{
    List<Producto> ObtenerTodos();
    Producto? ObtenerPorId(int id);
    Producto Agregar(Producto producto);
    bool Actualizar(Producto producto);
    bool Eliminar(int id);
}