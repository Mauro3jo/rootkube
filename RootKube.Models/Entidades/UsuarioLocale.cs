using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RootKube.Models.Entidades;

[Table("Usuario_Locales")]
public partial class UsuarioLocale
{
    [Key]
    [Column("id_usuario_local")]
    public int IdUsuarioLocal { get; set; }

    [Column("id_usuario")]
    public int IdUsuario { get; set; }

    [Column("id_local")]
    public int IdLocal { get; set; }

    [ForeignKey("IdLocal")]
    [InverseProperty("UsuarioLocales")]
    public virtual Locale IdLocalNavigation { get; set; } = null!;

    [ForeignKey("IdUsuario")]
    [InverseProperty("UsuarioLocales")]
    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
