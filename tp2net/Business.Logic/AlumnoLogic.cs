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
    public class AlumnoLogic : BusinessLogic
    {
        public AlumnoLogic()
        {
            this.AlumnoData = new AlumnoAdapter();
        }

        private AlumnoAdapter _AlumnoData;
        public AlumnoAdapter AlumnoData
        {
            get { return _AlumnoData; }
            set { _AlumnoData = value; }
        }

        public List<AlumnoInscripcion> GetAll()
        {
            return this.AlumnoData.GetAll();
        }

        public Business.Entities.AlumnoInscripcion GetOne(int ID)
        {
            return this.AlumnoData.GetOne(ID);
        }

        public void Delete(int ID)
        {
            this.AlumnoData.Delete(ID);
        }

        public void Save(AlumnoInscripcion alumno)
        {
            this.AlumnoData.Save(alumno);
        }
    }
}
