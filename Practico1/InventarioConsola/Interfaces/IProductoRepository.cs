using System.Collections.Generic;
using InventarioConsola.Models;

namespace InventarioConsola.Interfaces
{
    public interface IProductoRepository
    {  
        void Agregar(Producto producto);
        List<Producto> ObtenerTodos();
        Producto? ObtenerPorId(int id);
        List<Producto> BuscarPorCategoria(string categoria);
    }
}
