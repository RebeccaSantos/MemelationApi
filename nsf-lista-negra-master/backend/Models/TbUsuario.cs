using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    [Table("tb_usuario")]
    public partial class TbUsuario
    {
        public TbUsuario()
        {
            TbComentario = new HashSet<TbComentario>();
        }

        [Key]
        [Column("id_usuario", TypeName = "int(11)")]
        public int IdUsuario { get; set; }
        [Column("nm_usuario", TypeName = "varchar(50)")]
        public string NmUsuario { get; set; }
        [Column("ds_senha", TypeName = "varchar(50)")]
        public string DsSenha { get; set; }

        [InverseProperty("IdUsuarioNavigation")]
        public virtual ICollection<TbComentario> TbComentario { get; set; }
    }
}
