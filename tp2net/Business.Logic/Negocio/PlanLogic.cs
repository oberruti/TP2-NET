using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class PlanLogic : BusinessLogic
    {

        private PlanAdapter _PlanData;

        public PlanAdapter PlanData { get => _PlanData; set => _PlanData = value; }

        public PlanLogic()
        {

            PlanData = new PlanAdapter();

        }

        public Plan GetOne(int id) { return PlanData.GetOne(id); }

        public List<Plan> GetAll() { return PlanData.GetAll(); }

        public void Save(Plan plan) { PlanData.Save(plan); }

        public void Delete(int id) { PlanData.Delete(id); }

        public int GetIndex(int id)
        {
            List<Plan> planes = PlanData.GetAll();
            int i = 0;
            foreach (Plan pl in planes)
            {
                if (pl.ID == id)
                {
                    break;
                }
                ++i;
            }
            return i;
        }

    }
}
