using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    [Table("tb_memelation")]
    public partial class TbMemelation
    {
        public TbMemelation()
        {
            TbComentario = new HashSet<TbComentario>();
        }

        [Key]
        [Column("id_memelation", TypeName = "int(11)")]
        public int IdMemelation { get; set; }
        [Required]
        [Column("nm_autor", TypeName = "varchar(100)")]
        public string NmAutor { get; set; }
        [Required]
        [Column("ds_categoria", TypeName = "varchar(50)")]
        public string DsCategoria { get; set; }
        [Required]
        [Column("ds_hashtags", TypeName = "varchar(200)")]
        public string DsHashtags { get; set; }
        [Column("bt_maior")]
        public bool BtMaior { get; set; }
        [Required]
        [Column("img_meme", TypeName = "varchar(100)")]
        public string ImgMeme { get; set; }
        [Column("dt_inclusao", TypeName = "datetime")]
        public DateTime DtInclusao { get; set; }
        [Column("qtd_curtidas", TypeName = "int(11)")]
        public int? QtdCurtidas { get; set; }

        [InverseProperty("IdMemelationNavigation")]
        public virtual ICollection<TbComentario> TbComentario { get; set; }
    }
}
