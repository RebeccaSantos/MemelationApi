using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace backend.Database
{
    public class ListaNegraDatabase
    {
        Models.lndbContext db = new Models.lndbContext();
            

        public Models.TbListaNegra Salvar(Models.TbListaNegra ln)
        {
            db.Add(ln);
            db.SaveChanges();

            return ln;
        }

        public List<Models.TbListaNegra> Listar()
        {
             List<Models.TbListaNegra> lns = db.TbListaNegra.ToList();
             return lns;
        }


        public Models.TbListaNegra Deletar(int id)
        {
             Models.TbListaNegra ln = 
                db.TbListaNegra.FirstOrDefault(x => x.IdListaNegra == id);

             if (ln != null)
             {
                 db.TbListaNegra.Remove(ln);
                 db.SaveChanges();
             }

             return ln;
        }

        public Models.TbListaNegra Alterar(int id, Models.TbListaNegra novo)
        {
             Models.TbListaNegra ln = 
                db.TbListaNegra.FirstOrDefault(x => x.IdListaNegra == id);

             if (ln != null)
             {
                 ln.NmPessoa = novo.NmPessoa;
                 ln.DsMotivo = novo.DsMotivo;
                 ln.DsLocal = novo.DsLocal;
                 ln.DtInclusao = novo.DtInclusao;
                 
                 db.SaveChanges();
             }

             return ln;
        }
    }
}