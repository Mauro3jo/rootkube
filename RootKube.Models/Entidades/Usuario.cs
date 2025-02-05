using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RootKube.Models.Entidades;

[Index("Correo", Name = "UQ__Usuarios__2A586E0BFC85A1C0", IsUnique = true)]
[Index("Correo", Name = "idx_usuario_correo")]
public partial class Usuario
{
    [Key]
    [Column("id_usuario")]
    public int IdUsuario { get; set; }

    [Column("nombre")]
    [StringLength(100)]
    public string Nombre { get; set; } = null!;

    [Column("correo")]
    [StringLength(150)]
    public string Correo { get; set; } = null!;

    [Column("contraseña")]
    [StringLength(255)]
    public string Contraseña { get; set; } = null!;

    [Column("rol")]
    [StringLength(50)]
    public string Rol { get; set; } = null!;

    [Column("fecha_creacion", TypeName = "datetime")]
    public DateTime? FechaCreacion { get; set; }

    [InverseProperty("IdUsuarioNavigation")]
    public virtual ICollection<Caja> Cajas { get; set; } = new List<Caja>();

    [InverseProperty("IdUsuarioNavigation")]
    public virtual ICollection<Sesione> Sesiones { get; set; } = new List<Sesione>();

    [InverseProperty("IdUsuarioNavigation")]
    public virtual ICollection<Token> Tokens { get; set; } = new List<Token>();

    [InverseProperty("IdUsuarioNavigation")]
    public virtual ICollection<UsuarioLocale> UsuarioLocales { get; set; } = new List<UsuarioLocale>();

    [InverseProperty("IdUsuarioNavigation")]
    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
