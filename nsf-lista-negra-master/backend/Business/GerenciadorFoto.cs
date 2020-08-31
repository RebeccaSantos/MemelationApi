using System;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace backend.Business
{
    public class GerenciadorFoto
    {
        
        public string GerarNovoNome(string nome)
        {
            string novoNome = Guid.NewGuid().ToString(); // "f0342-234239"
            novoNome = novoNome + Path.GetExtension(nome); // "f0342-234239.jpg"
            return novoNome;
        }

        public void SalvarFoto(string nome, IFormFile foto)
        {
            string caminhoFoto = Path.Combine(AppContext.BaseDirectory, "Storage", "Fotos", nome);

            using (FileStream fs = new FileStream(caminhoFoto, FileMode.Create))
            {
                foto.CopyTo(fs);
            }
        }

        public byte[] LerFoto(string nome)
        {
            string caminhoFoto = Path.Combine(AppContext.BaseDirectory, "Storage", "Fotos", nome);
            byte[] foto = File.ReadAllBytes(caminhoFoto);

            return foto;
        }

        public string GerarContentType(string nome)
        {
            string extensao = System.IO.Path.GetExtension(nome).Replace(".", "");
            string contentType = "image/" + extensao;
            return contentType;
        }

    }
}