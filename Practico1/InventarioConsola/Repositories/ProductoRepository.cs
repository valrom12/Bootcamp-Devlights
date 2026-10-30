using System;
using System.Collections.Generic;
using System.Linq;
using InventarioConsola.Models;
using InventarioConsola.Interfaces;

namespace InventarioConsola.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly List<Producto> _productos;

        public ProductoRepository()
        {
            _productos = new List<Producto>()
            {
                new Producto { Id = 1, Nombre = "Laptop", Precio = 1500.00m, Categoria = "Electrónica", Activo = true },
                new Producto { Id = 2, Nombre = "Teléfono", Precio = 800.00m, Categoria = "Electrónica", Activo = true },
                new Producto { Id = 3, Nombre = "Mouse", Precio = 20.00m, Categoria = "Periféricos", Activo = false },
            };
        }

        public void Agregar(Producto producto)
        {
            _productos.Add(producto);
        }

        public List<Producto> ObtenerTodos()
        {
            return _productos;
        }

        public Producto? ObtenerPorId(int id)
        {
            return _productos.FirstOrDefault(p => p.Id == id);
        }

        public List<Producto> BuscarPorCategoria(string categoria)
        {
            return _productos.Where(p => string.Equals(p.Categoria, categoria, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}
