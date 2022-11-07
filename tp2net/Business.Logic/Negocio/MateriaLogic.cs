using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;


namespace Business.Logic
{
    public class MateriaLogic : BusinessLogic
    {
        public MateriaLogic()
        {
            this.MateriaData = new MateriaAdapter();
        }


        protected MateriaAdapter _MateriaData;
        public MateriaAdapter MateriaData
        {
            get { return _MateriaData; }
            set { _MateriaData = value; }
        }


        public Materia GetOne(int id)
        {
            return MateriaData.GetOne(id);
        }

        public List<Materia> GetAll()
        {
            return MateriaData.GetAll();
        }

        public void Delete(int id)
        {
            MateriaData.Delete(id);
        }

        public void Save(Materia materia)
        {
            MateriaData.Save(materia);
        }
        public int GetIndex(int id)
        {
            List<Materia> materias = MateriaData.GetAll();
            int i = 0;
            foreach (Materia m in materias)
            {
                if (m.ID == id)
                {
                    break;
                }
                ++i;
            }
            return i;
        }
        public List<Materia> GetAllPlan(int idPlan)
        {
            return MateriaData.GetAllPlan(idPlan);
        }
        public object GetAllByComision(int idComision)
        {
            return MateriaData.GetAllByComision(idComision);
        }
    }
}
