using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RootKube.Models.Entidades;

[Index("Fecha", Name = "idx_venta_fecha")]
public partial class Venta
{
    [Key]
    [Column("id_venta")]
    public int IdVenta { get; set; }

    [Column("id_local")]
    public int IdLocal { get; set; }

    [Column("id_usuario")]
    public int? IdUsuario { get; set; }

    [Column("fecha", TypeName = "datetime")]
    public DateTime? Fecha { get; set; }

    [Column("metodo_pago")]
    [StringLength(50)]
    public string MetodoPago { get; set; } = null!;

    [Column("total", TypeName = "decimal(10, 2)")]
    public decimal Total { get; set; }

    [InverseProperty("IdVentaNavigation")]
    public virtual ICollection<DetalleVentum> DetalleVenta { get; set; } = new List<DetalleVentum>();

    [ForeignKey("IdLocal")]
    [InverseProperty("Venta")]
    public virtual Locale IdLocalNavigation { get; set; } = null!;

    [ForeignKey("IdUsuario")]
    [InverseProperty("Venta")]
    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
