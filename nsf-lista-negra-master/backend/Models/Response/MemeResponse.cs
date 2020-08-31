using System;

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
        public int Curtidas { get; set; }
        public DateTime Inclusao { get; set; }
    }
}