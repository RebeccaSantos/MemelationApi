using System;
using System.Collections.Generic;
using System.Linq;


namespace backend.Business
{
    public class ListaNegraBusiness
    {
        Database.ListaNegraDatabase db =new Database.ListaNegraDatabase();

        public Models.TbListaNegra Salvar(Models.TbListaNegra ln)
        {
            if (string.IsNullOrEmpty(ln.NmPessoa))
                throw new Exception("Nome é obrigatório");
            if (string.IsNullOrEmpty(ln.DsMotivo))
                throw new Exception("Motivo é obrigatório");
            if (string.IsNullOrEmpty(ln.DsLocal))
                throw new Exception("Local é obrigatório");

            return db.Salvar(ln);
        }

        public List<Models.TbListaNegra> Listar()
        {
            return db.Listar();
        }

        public Models.TbListaNegra Deletar(int id)
        {
            return db.Deletar(id);
        }

        public Models.TbListaNegra Alterar(int id, Models.TbListaNegra novo)
        {
            if (novo.NmPessoa == string.Empty)
                throw new Exception("Nome é obrigatório");
            if (novo.DsMotivo == string.Empty)
                throw new Exception("Motivo é obrigatório");
            if (novo.DsLocal == string.Empty)
                throw new Exception("Local é obrigatório");


            return db.Alterar(id, novo);
        }
    }
}