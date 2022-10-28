using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;


namespace Business.Logic
{
    public class CursoLogic : BusinessLogic
    {
        public CursoLogic()
        {
            this.CursoData = new CursoAdapter();

        }

        protected CursoAdapter _CursoData;
        public CursoAdapter CursoData
        {
            get{ return _CursoData;}
            set{ _CursoData = value;}
        }
        
        public Curso GetOne(int id)
        {
             return CursoData.GetOne(id);
        }

        public List<Curso> GetAll()
        {
            return CursoData.GetAll();
        }

        public void Delete(int id)
        {
            CursoData.Delete(id);
        }

        public void Save(Curso user)
        {
            CursoData.Save(user);
        }
    }
}
