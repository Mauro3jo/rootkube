using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RootKube.Models.Entidades;

public partial class Token
{
    [Key]
    [Column("id_token")]
    public Guid IdToken { get; set; }

    [Column("id_usuario")]
    public int IdUsuario { get; set; }

    [Column("token")]
    [StringLength(500)]
    public string Token1 { get; set; } = null!;

    [Column("fecha_creacion", TypeName = "datetime")]
    public DateTime? FechaCreacion { get; set; }

    [Column("fecha_expiracion", TypeName = "datetime")]
    public DateTime FechaExpiracion { get; set; }

    [ForeignKey("IdUsuario")]
    [InverseProperty("Tokens")]
    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
