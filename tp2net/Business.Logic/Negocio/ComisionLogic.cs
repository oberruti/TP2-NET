using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class ComisionLogic : BusinessLogic
    {
        public ComisionLogic()
        {
            this.ComisionData = new ComisionAdapter();
        }


        protected ComisionAdapter _ComisionData;
        public ComisionAdapter ComisionData
        {
            get { return _ComisionData; }
            set { _ComisionData = value; }
        }


        public Comision GetOne(int id)
        {
            return ComisionData.GetOne(id);
        }

        public List<Comision> GetAll()
        {
            return ComisionData.GetAll();
        }

        public void Delete(int id)
        {
            ComisionData.Delete(id);
        }

        public void Save(Comision materia)
        {
            ComisionData.Save(materia);
        }

        public int GetIndex(int id)
        {
            List<Comision> comisiones = ComisionData.GetAll();
            int i = 0;
            foreach (Comision com in comisiones)
            {
                if (com.ID == id)
                {
                    break;
                }
                ++i;
            }
            return i;
        }
        public List<Comision> GetAllByMateria(int idMateria)
        {
            return ComisionData.GetAllByMateria(idMateria);
        }
    }
}
