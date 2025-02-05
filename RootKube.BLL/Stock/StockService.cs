using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RootKube.DAL.Contexto;
using RootKube.Models.Entidades;

namespace RootKube.BLL.Stock
{
    public class StockService
    {
        private readonly RootKubeDbContext _context;

        public StockService()
        {
            _context = new RootKubeDbContext();
        }

        // 🔹 Obtener todos los productos con sus categorías
        public List<Producto> ObtenerProductos()
        {
            return _context.Productos.Include(p => p.IdCategoriaNavigation).ToList();
        }

        // 🔹 Crear un nuevo producto
        public bool CrearProducto(string nombre, int idCategoria, string unidad, decimal precio)
        {
            if (_context.Productos.Any(p => p.Nombre == nombre)) return false;

            Producto nuevoProducto = new Producto
            {
                Nombre = nombre,
                IdCategoria = idCategoria,
                UnidadMedida = unidad,
                Precio = precio
            };

            _context.Productos.Add(nuevoProducto);
            _context.SaveChanges();
            return true;
        }

        // 🔹 Modificar un producto existente
        public bool ModificarProducto(int idProducto, string nombre, int idCategoria, string unidad, decimal precio)
        {
            var producto = _context.Productos.FirstOrDefault(p => p.IdProducto == idProducto);
            if (producto == null) return false;

            producto.Nombre = nombre;
            producto.IdCategoria = idCategoria;
            producto.UnidadMedida = unidad;
            producto.Precio = precio;
            _context.SaveChanges();
            return true;
        }

        // 🔹 Eliminar un producto
        public bool EliminarProducto(int idProducto)
        {
            var producto = _context.Productos.FirstOrDefault(p => p.IdProducto == idProducto);
            if (producto == null) return false;

            _context.Productos.Remove(producto);
            _context.SaveChanges();
            return true;
        }

        // 🔹 Obtener todas las categorías
        public List<Categoria> ObtenerCategorias()
        {
            return _context.Categorias.ToList();
        }

        // 🔹 Crear una nueva categoría
        public bool CrearCategoria(string nombre)
        {
            if (_context.Categorias.Any(c => c.Nombre == nombre)) return false;

            _context.Categorias.Add(new Categoria { Nombre = nombre });
            _context.SaveChanges();
            return true;
        }
        public bool ModificarCategoria(int idCategoria, string nuevoNombre)
        {
            var categoria = _context.Categorias.FirstOrDefault(c => c.IdCategoria == idCategoria);
            if (categoria == null) return false;

            if (_context.Categorias.Any(c => c.Nombre == nuevoNombre && c.IdCategoria != idCategoria)) return false;

            categoria.Nombre = nuevoNombre;
            _context.SaveChanges();
            return true;
        }

        // 🔹 Obtener el stock de un local
        public List<StockLocal> ObtenerStockPorLocal(int idLocal)
        {
            return _context.Set<StockLocal>() // ✅ Corrección: Usa Set<StockLocal>() en lugar de _context.StockLocal
                .Where(s => s.IdLocal == idLocal)
                .Include(s => s.IdProductoNavigation)
                .ToList();
        }

        // 🔹 Agregar stock a un local
        public bool AgregarStock(int idLocal, int idProducto, decimal cantidad)
        {
            var stockExistente = _context.Set<StockLocal>() // ✅ Corrección: Usa Set<StockLocal>()
                .FirstOrDefault(s => s.IdLocal == idLocal && s.IdProducto == idProducto);

            if (stockExistente != null)
            {
                stockExistente.Cantidad += cantidad;
            }
            else
            {
                StockLocal nuevoStock = new StockLocal
                {
                    IdLocal = idLocal,
                    IdProducto = idProducto,
                    Cantidad = cantidad
                };
                _context.Set<StockLocal>().Add(nuevoStock); // ✅ Corrección: Usa Set<StockLocal>()
            }

            _context.SaveChanges();
            return true;
        }
    }
}
