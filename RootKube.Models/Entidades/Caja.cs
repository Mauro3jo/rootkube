using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RootKube.Models.Entidades;

[Table("Caja")]
[Index("Fecha", Name = "idx_caja_fecha")]
public partial class Caja
{
    [Key]
    [Column("id_movimiento")]
    public int IdMovimiento { get; set; }

    [Column("id_local")]
    public int IdLocal { get; set; }

    [Column("id_usuario")]
    public int? IdUsuario { get; set; }

    [Column("tipo_movimiento")]
    [StringLength(50)]
    public string TipoMovimiento { get; set; } = null!;

    [Column("fecha", TypeName = "datetime")]
    public DateTime? Fecha { get; set; }

    [Column("monto", TypeName = "decimal(10, 2)")]
    public decimal Monto { get; set; }

    [ForeignKey("IdLocal")]
    [InverseProperty("Cajas")]
    public virtual Locale IdLocalNavigation { get; set; } = null!;

    [ForeignKey("IdUsuario")]
    [InverseProperty("Cajas")]
    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
