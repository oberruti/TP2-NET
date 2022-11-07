using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;
using static Business.Entities.BusinessEntity;

namespace Business.Logic
{
    public class DocenteCursoLogic : BusinessLogic
    {
        public DocenteCursoLogic()
        {
            this.DocenteCursoData = new DocenteCursoAdapter();
        }

        private DocenteCursoAdapter _DocenteCursoData;
        public DocenteCursoAdapter DocenteCursoData
        {
            get { return _DocenteCursoData; }
            set { _DocenteCursoData = value; }
        }

        public List<DocenteCurso> GetByCurso(int IDCurso)
        {
            return this.DocenteCursoData.GetByCurso(IDCurso);
        }

        public void Delete(int ID)
        {
            this.DocenteCursoData.Delete(ID);
        }

        public void Save(DocenteCurso docente)
        {
            this.DocenteCursoData.Save(docente);
        }

        public List<DocenteCurso> GetAll()
        {
            return DocenteCursoData.GetAll();
        }

        public List<DocenteCurso> GetAllYearDoc(int idDoc, int year)
        {
            return DocenteCursoData.GetAllYearDoc(idDoc, year);
        }

        public DocenteCurso GetOne(int id_dictado)
        {
            return DocenteCursoData.GetOne(id_dictado);
        }
    }
}
