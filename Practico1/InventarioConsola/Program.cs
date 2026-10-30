using System;
using InventarioConsola.Models;
using InventarioConsola.Interfaces;
using InventarioConsola.Repositories;

IProductoRepository repo = new ProductoRepository();

Console.WriteLine("-- Inventario de Productos --");
foreach (var p in repo.ObtenerTodos())
{
    Console.WriteLine($"{p.Id} - {p.Nombre} (${p.Precio}) - {p.Categoria}");
}

Console.WriteLine("\n-- Buscar producto 2 --");
var prod = repo.ObtenerPorId(2);
if (prod != null) {   
    Console.WriteLine($"{prod.Id} - {prod.Nombre} (${prod.Precio}) - {prod.Categoria}");
}

Console.WriteLine("\n-- Buscar por categoría 'Electrónica' --");
foreach (var p in repo.BuscarPorCategoria("Electrónica"))
{
    Console.WriteLine($"{p.Id} - {p.Nombre} (${p.Precio}) - {p.Categoria}");
}

Console.WriteLine("\n-- Agregar nuevo producto --");
var nuevoProducto = new Producto { Id = 4, Nombre = "Teclado", Precio = 50.00m, Categoria = "Periféricos", Activo = true };
repo.Agregar(nuevoProducto);
Console.WriteLine("Producto agregado: " + nuevoProducto.Nombre);
Console.WriteLine("Total de productos: " + repo.ObtenerTodos().Count);