using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RootKube.Models.Entidades;

[Table("Stock_Local")]
[Index("IdLocal", "IdProducto", Name = "idx_stock_local")]
public partial class StockLocal
{
    [Key]
    [Column("id_stock")]
    public int IdStock { get; set; }

    [Column("id_local")]
    public int IdLocal { get; set; }

    [Column("id_producto")]
    public int IdProducto { get; set; }

    [Column("cantidad", TypeName = "decimal(10, 2)")]
    public decimal Cantidad { get; set; }

    [ForeignKey("IdLocal")]
    [InverseProperty("StockLocals")]
    public virtual Locale IdLocalNavigation { get; set; } = null!;

    [ForeignKey("IdProducto")]
    [InverseProperty("StockLocals")]
    public virtual Producto IdProductoNavigation { get; set; } = null!;
}
