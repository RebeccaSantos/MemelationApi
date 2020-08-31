using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    [Table("tb_comentario")]
    public partial class TbComentario
    {
        [Key]
        [Column("id_comentario", TypeName = "int(11)")]
        public int IdComentario { get; set; }
        [Column("ds_comentario", TypeName = "varchar(255)")]
        public string DsComentario { get; set; }
        [Column("id_memelation", TypeName = "int(11)")]
        public int? IdMemelation { get; set; }
        [Column("id_usuario", TypeName = "int(11)")]
        public int? IdUsuario { get; set; }

        [ForeignKey(nameof(IdMemelation))]
        [InverseProperty(nameof(TbMemelation.TbComentario))]
        public virtual TbMemelation IdMemelationNavigation { get; set; }
        [ForeignKey(nameof(IdUsuario))]
        [InverseProperty(nameof(TbUsuario.TbComentario))]
        public virtual TbUsuario IdUsuarioNavigation { get; set; }
    }
}
