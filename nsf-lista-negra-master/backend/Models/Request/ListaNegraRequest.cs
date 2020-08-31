using System;
using Microsoft.AspNetCore.Http;

namespace backend.Models.Request
{
    public class ListaNegraRequest
    {
        public string Nome { get; set; }
        public string Motivo { get; set; }
        public string Local { get; set; }
        public DateTime Inclusao { get; set; }
        public IFormFile Foto { get; set; }
    }
}