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
            get { return _CursoData; }
            set { _CursoData = value; }
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
        public List<Curso> GetAllCursosConCupos()
        {
            return CursoData.GetAllCursosConCupos();
        }

        public List<Curso> GetAllForDoc(int id_doc)
        {
            return CursoData.GetAllForDoc(id_doc);
        }
        public List<Curso> GetAllForAlum(int id_alum)
        {
            return CursoData.GetAllForAlum(id_alum);
        }

        public List<Curso> GetAllDoc(int id_doc)
        {
            return CursoData.GetAllDoc(id_doc);
        }

        public List<Curso> GetAllYearAlum(int idAlumno, int year)
        {
            return CursoData.GetAllYearAlum(idAlumno, year);
        }

    }
}
