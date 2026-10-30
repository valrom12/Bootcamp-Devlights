using GestorProductos_DataAccessLayer.Models;

namespace GestorProductos_DataAccessLayer.Repositories;

public class ProductoRepositoryInMemory : IProductoRepository
{
    private static readonly List<Producto> _productos = new()
        {
            new Producto { Id = 1, Nombre = "Producto A", Precio = 10.5m, Categoria = "Categoria 1", Activo = true },
            new Producto { Id = 2, Nombre = "Producto B", Precio = 20.0m, Categoria = "Categoria 2", Activo = true },
            new Producto { Id = 3, Nombre = "Producto C", Precio = 15.75m, Categoria = "Categoria 1", Activo = false }
        };

    public List<Producto> ObtenerTodos()
    {
        return _productos.ToList();
    }

    public Producto? ObtenerPorId(int id)
    {
        return _productos.FirstOrDefault(p => p.Id == id);
    }

    public Producto Agregar(Producto producto)
    {
        producto.Id = _productos.Any() ? _productos.Max(p => p.Id) + 1 : 1;
        _productos.Add(producto);
        return producto;
    }

    public bool Actualizar(Producto producto)
    {
        var existente = ObtenerPorId(producto.Id);
        if (existente == null) 
            return false;

        existente.Nombre = producto.Nombre;
        existente.Precio = producto.Precio;
        existente.Categoria = producto.Categoria;
        existente.Activo = producto.Activo;
        return true;
    }

    public bool Eliminar(int id)
    {
        var producto = ObtenerPorId(id);
        if (producto == null) 
            return false;
        return _productos.Remove(producto);
    }
}