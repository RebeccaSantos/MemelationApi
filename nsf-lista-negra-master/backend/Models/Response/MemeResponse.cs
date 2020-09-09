using System;
using System.Collections.Generic; 

namespace backend.Models.Response
{
    public class MemeResponse
    {
    public int ID { get; set; }
        public string Autor { get; set; }
        public string Categoria { get; set; } 
        public string Hashtags { get; set; }
        public bool Maior { get; set; }
        public string Imagem { get; set; }
        public int? Curtidas { get; set; }
        public DateTime Inclusao { get; set; }
        public List<ComentarioResponse> Comentarios { get; set; }
    }
        public class ComentarioResponse
    {
        public int Id { get; set; }
        public int? IdDoMeme { get; set; }
        public string Texto { get; set; }
    }
}