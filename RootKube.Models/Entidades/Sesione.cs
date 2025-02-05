using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RootKube.Models.Entidades;

public partial class Sesione
{
    [Key]
    [Column("id_sesion")]
    public int IdSesion { get; set; }

    [Column("id_usuario")]
    public int IdUsuario { get; set; }

    [Column("fecha_inicio", TypeName = "datetime")]
    public DateTime? FechaInicio { get; set; }

    [Column("fecha_fin", TypeName = "datetime")]
    public DateTime? FechaFin { get; set; }

    [ForeignKey("IdUsuario")]
    [InverseProperty("Sesiones")]
    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
