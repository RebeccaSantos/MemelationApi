using System;

namespace backend.Models.Request
{
    public class ListaFofaRequest
    {
        public string Fofura { get; set; }
        public string Porque { get; set; }
        public bool? ColocariaPotinho { get; set; }
        public DateTime Niver { get; set; }
    }
}