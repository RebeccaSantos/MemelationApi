using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace backend.Database
{
    public class MemeDatabase
    {
        Models.lndbContext db = new Models.lndbContext();

        public Models.TbMemelation Salvar (Models.TbMemelation tb)
        {
            db.Add(tb);
            db.SaveChanges();

            return tb;
        }

        public List<Models.TbMemelation> Listar ()
        {
            return db.TbMemelation.ToList();
        }

        public Models.TbMemelation Deletar (int id)
        {
            Models.TbMemelation tb = 
                db.TbMemelation.FirstOrDefault(x => x.IdMemelation == id);
        
            if (tb != null)
            {
                db.TbMemelation.Remove(tb);
                db.SaveChanges();
            }

            return tb;
        }

        public Models.TbMemelation Alterar (int id, Models.TbMemelation novaTb)
        {
            Models.TbMemelation tb = 
                db.TbMemelation.FirstOrDefault(x => x.IdMemelation == id);

            if (tb != null)
            {
                tb.NmAutor = novaTb.NmAutor;
                tb.DsCategoria = novaTb.DsCategoria;
                tb.DsHashtags = novaTb.DsHashtags;
                tb.BtMaior = novaTb.BtMaior;
                tb.DtInclusao = novaTb.DtInclusao;
                tb.ImgMeme=novaTb.ImgMeme;
                
                db.SaveChanges();
            }

            return tb;
        }
        public Models.TbMemelation AtualizarCurtidas(int id)
        {
              Models.TbMemelation atual=db.TbMemelation.First(x=>x.IdMemelation==id);
              atual.QtdCurtidas=atual.QtdCurtidas+1;
              db.SaveChanges();
              return atual;
        }
        public Models.TbComentario Comentario(Models.TbComentario tb)
        {
            db.Add(tb);
            db.SaveChanges();

            return tb;
        }
        public List<Models.TbMemelation> ConsultarTudo()
        {
            List<Models.TbMemelation> meme = db.TbMemelation.Include(x=>x.TbComentario).ToList();

            return meme;
        }
        
    }
}