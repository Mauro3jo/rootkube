using RootKube.DAL.Contexto;
using RootKube.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RootKube.BLL.Ventas
{
    public class VentasService
    {
        private readonly RootKubeDbContext _context;

        public VentasService(RootKubeDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Registra una nueva venta en la base de datos y actualiza el stock del local.
        /// </summary>
        public bool RegistrarVenta(int idUsuario, int idLocal, string metodoPago, List<DetalleVentum> detalles)
        {
            try
            {
                // Verificar stock suficiente antes de registrar la venta
                foreach (var detalle in detalles)
                {
                    var stockLocal = _context.StockLocals
                        .FirstOrDefault(s => s.IdLocal == idLocal && s.IdProducto == detalle.IdProducto);

                    if (stockLocal == null || stockLocal.Cantidad < detalle.Cantidad)
                    {
                        return false; // Stock insuficiente
                    }
                }

                // Calcular total de la venta
                decimal totalVenta = detalles.Sum(d => d.Subtotal);

                // Crear venta sin detalles
                Venta nuevaVenta = new Venta
                {
                    IdLocal = idLocal,
                    IdUsuario = idUsuario,
                    Fecha = DateTime.Now,
                    MetodoPago = metodoPago,
                    Total = totalVenta
                };

                _context.Ventas.Add(nuevaVenta);
                _context.SaveChanges(); // Guardamos la venta antes de asociarle detalles

                // Asignar el ID de la venta a los detalles y guardarlos
                foreach (var detalle in detalles)
                {
                    detalle.IdVenta = nuevaVenta.IdVenta; // Asociar con la venta creada
                    detalle.IdProductoNavigation = null; // Evita que Entity Framework intente insertar un nuevo producto
                    _context.DetalleVenta.Add(detalle);
                }

                _context.SaveChanges(); // Guardar los detalles de la venta

                // Descontar stock
                foreach (var detalle in detalles)
                {
                    var stockLocal = _context.StockLocals
                        .FirstOrDefault(s => s.IdLocal == idLocal && s.IdProducto == detalle.IdProducto);

                    if (stockLocal != null)
                    {
                        stockLocal.Cantidad -= detalle.Cantidad;
                    }
                }

                _context.SaveChanges(); // Guardar cambios en el stock
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en RegistrarVenta: {ex.Message}");
                return false;
            }
        }



        /// <summary>
        /// Obtiene la lista de ventas registradas.
        /// </summary>
        public List<Venta> ObtenerVentas()
        {
            return _context.Ventas
                .OrderByDescending(v => v.Fecha)
                .ToList();
        }

        /// <summary>
        /// Obtiene los detalles de una venta específica.
        /// </summary>
        public Venta? ObtenerVentaPorId(int idVenta)
        {
            return _context.Ventas
                .FirstOrDefault(v => v.IdVenta == idVenta);
        }
    }
}
