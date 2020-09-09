using System;
using Microsoft.AspNetCore.Http;

namespace backend.Models.Request
{
    public class MemeRequest
    {
        public string Autor { get; set; }
        public string Categoria { get; set; }
        public string Hashtags { get; set; }
        public bool Maior { get; set; }
        public IFormFile Imagem { get; set; }        
    }
       public class ComentarioRequest
    {
        public int IdDoMeme { get; set; }
        public string Texto { get; set; }        
    }
}