using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RootKube.Models.Entidades;

public partial class Locale
{
    [Key]
    [Column("id_local")]
    public int IdLocal { get; set; }

    [Column("nombre")]
    [StringLength(100)]
    public string Nombre { get; set; } = null!;

    [Column("direccion")]
    [StringLength(255)]
    public string Direccion { get; set; } = null!;

    [InverseProperty("IdLocalNavigation")]
    public virtual ICollection<Caja> Cajas { get; set; } = new List<Caja>();

    [InverseProperty("IdLocalNavigation")]
    public virtual ICollection<StockLocal> StockLocals { get; set; } = new List<StockLocal>();

    [InverseProperty("IdLocalNavigation")]
    public virtual ICollection<UsuarioLocale> UsuarioLocales { get; set; } = new List<UsuarioLocale>();

    [InverseProperty("IdLocalNavigation")]
    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
