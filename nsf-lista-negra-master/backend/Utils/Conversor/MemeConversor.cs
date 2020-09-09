using System;
using System.Collections.Generic;
using System.Linq;

namespace backend.Utils
{
    public class MemeConversor
    {
        public Models.TbMemelation ParaTabela (Models.Request.MemeRequest req)
        {
            Models.TbMemelation tb = new Models.TbMemelation();
            tb.NmAutor = req.Autor;
            tb.DsCategoria = req.Categoria;
            tb.DsHashtags = req.Hashtags;
            tb.BtMaior = req.Maior;
            tb.QtdCurtidas=0;
            tb.DtInclusao = DateTime.Now;

            return tb;
        }

        public Models.Response.MemeResponse ParaResponse (Models.TbMemelation tb)
        {
            Models.Response.MemeResponse resp = new Models.Response.MemeResponse();
            resp.ID = tb.IdMemelation;
            resp.Autor = tb.NmAutor;
            resp.Categoria = tb.DsCategoria;
            resp.Hashtags = tb.DsHashtags;
            resp.Maior = tb.BtMaior;
            resp.Curtidas=tb.QtdCurtidas;
            resp.Imagem = tb.ImgMeme;
            resp.Inclusao = tb.DtInclusao;

            return resp;
        }

        public List<Models.Response.MemeResponse> ParaResponse (List<Models.TbMemelation> tbs)
        {
            List<Models.Response.MemeResponse> resp = new List<Models.Response.MemeResponse>();

            tbs.ForEach(x => 
                resp.Add(this.ParaResponse(x))
            );

            return resp;
        }
         public Models.TbComentario ParaTabelaComentario(Models.Request.ComentarioRequest req)
        {
            Models.TbComentario a = new Models.TbComentario();
            a.DsComentario = req.Texto;
            a.IdMemelation = req.IdDoMeme;
            return a;
        }

        public Models.Response.ComentarioResponse ParaRespostaComentario(Models.TbComentario req)
        {
            Models.Response.ComentarioResponse a = new Models.Response.ComentarioResponse();
            a.Id = req.IdComentario;
            a.Texto = req.DsComentario;
            a.IdDoMeme = req.IdMemelation;
            return a;
        }
        

        public Models.Response.MemeResponse ParaCompletoResponse (Models.TbMemelation tb)
        {
            Models.Response.MemeResponse resp = new Models.Response.MemeResponse();

            resp.ID = tb.IdMemelation;
            resp.Autor = tb.NmAutor;
            resp.Categoria = tb.DsCategoria;
            resp.Hashtags = tb.DsHashtags;
            resp.Maior = tb.BtMaior;
            resp.Imagem = tb.ImgMeme;
            resp.Inclusao = tb.DtInclusao;
            resp.Curtidas = tb.QtdCurtidas;

            resp.Comentarios= tb.TbComentario.Select(x => new Models.Response.ComentarioResponse(){
                Id = x.IdComentario,
                Texto = x.DsComentario,
                IdDoMeme = x.IdMemelation
            }).ToList();

            return resp;
        }
    public List<Models.Response.MemeResponse> ParaCompletoListaResponse (List<Models.TbMemelation> tbs)
        {
            List<Models.Response.MemeResponse> resp = new List<Models.Response.MemeResponse>();

            tbs.ForEach(x => 
                resp.Add(this.ParaCompletoResponse(x))
            );

            return resp;
        }
        
    }
}