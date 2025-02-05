using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RootKube.Models.Entidades;

[Table("Claves_Producto")]
[Index("Clave", Name = "UQ__Claves_P__71DCA3DBF7E49A81", IsUnique = true)]
[Index("Clave", Name = "idx_clave_producto")]
public partial class ClavesProducto
{
    [Key]
    [Column("id_clave")]
    public int IdClave { get; set; }

    [Column("clave")]
    [StringLength(50)]
    public string Clave { get; set; } = null!;

    [Column("fecha_expiracion")]
    public DateOnly FechaExpiracion { get; set; }
}
