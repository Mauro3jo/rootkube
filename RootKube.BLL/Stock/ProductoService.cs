using RootKube.DAL.Contexto;
using RootKube.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RootKube.BLL.Stock
{
    public class ProductoService
    {
        private readonly RootKubeDbContext _context;

        public ProductoService(RootKubeDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtiene la lista de productos disponibles en stock para un local.
        /// </summary>
        public List<Producto> ObtenerProductosDisponibles(int idLocal)
        {
            return _context.StockLocals
                .Where(s => s.IdLocal == idLocal && s.Cantidad > 0)
                .Select(s => s.IdProductoNavigation)
                .ToList();
        }
    }
}
