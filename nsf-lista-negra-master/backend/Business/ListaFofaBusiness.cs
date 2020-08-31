using System;
using System.Collections.Generic;
using System.Linq;


namespace backend.Business
{
    public class ListaFofaBusiness
    {
        Database.ListaFofaDatabase db =new Database.ListaFofaDatabase();

        public Models.TbListaFofa Salvar(Models.TbListaFofa ln)
        {
            if (ln.NmFofura == string.Empty)
                throw new Exception("Nome é obrigatório");
            if (ln.DsPorque == string.Empty)
                throw new Exception("Motivo é obrigatório");
            
            return db.Salvar(ln);
        }

        public List<Models.TbListaFofa> Listar()
        {
            return db.Listar();
        }

        public Models.TbListaFofa Deletar(int id)
        {
            return db.Deletar(id);
        }

        public Models.TbListaFofa Alterar(int id, Models.TbListaFofa novo)
        {
            if (novo.NmFofura == string.Empty)
                throw new Exception("Nome é obrigatório");
            if (novo.DsPorque == string.Empty)
                throw new Exception("Motivo é obrigatório");

            return db.Alterar(id, novo);
        }
    }
}