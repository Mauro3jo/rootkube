using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RootKube.Models.Entidades;

public partial class Producto
{
    [Key]
    [Column("id_producto")]
    public int IdProducto { get; set; }

    [Column("nombre")]
    [StringLength(150)]
    public string Nombre { get; set; } = null!;

    [Column("id_categoria")]
    public int IdCategoria { get; set; }

    [Column("unidad_medida")]
    [StringLength(20)]
    public string UnidadMedida { get; set; } = null!;

    [Column("precio", TypeName = "decimal(10, 2)")]
    public decimal Precio { get; set; }

    [InverseProperty("IdProductoNavigation")]
    public virtual ICollection<DetalleVentum> DetalleVenta { get; set; } = new List<DetalleVentum>();

    [ForeignKey("IdCategoria")]
    [InverseProperty("Productos")]
    public virtual Categoria IdCategoriaNavigation { get; set; } = null!;

    [InverseProperty("IdProductoNavigation")]
    public virtual ICollection<StockLocal> StockLocals { get; set; } = new List<StockLocal>();
}
