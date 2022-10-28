using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class PlanAdapter : Adapter
    {

        public List<Plan> GetAll()
        {
            List<Plan> planes = new List<Plan>();

            try
            {
                this.OpenConnection();

                SqlCommand cmdPlan = new SqlCommand("select * from planes", SqlConn);

                SqlDataReader drPlanes = cmdPlan.ExecuteReader();

                while (drPlanes.Read())
                {
                    Plan plan = new Plan();

                    plan.ID = (int)drPlanes["id_plan"];
                    plan.Descripcion = (string)drPlanes["plan"];
                    plan.IDEspecialidad = (int)drPlanes["id_especialidad"];
                    
                    planes.Add(plan);
                }

                drPlanes.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al recuperar lista de planes", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return planes;
        }

        public Business.Entities.Plan GetOne(int ID)
        {
            Plan plan = new Plan();

            try
            {
                this.OpenConnection();

                SqlCommand cmdPlanes = new SqlCommand("select * from planes where id_plan=@id", SqlConn);
                cmdPlanes.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drPlanes = cmdPlanes.ExecuteReader();

                while (drPlanes.Read())
                {
                    plan.ID = (int)drPlanes["id_plan"];
                    plan.Descripcion = (string)drPlanes["plan"];
                    plan.IDEspecialidad = (int)drPlanes["id_especialidad"];
                }

                drPlanes.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar plan", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return plan;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete = new SqlCommand("delete planes where id_plan=@id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar plan", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Update(Plan plan)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave = new SqlCommand(
                    "UPDATE materias SET desc_plan=@desc_plan, id_especiliadad=@id_especialidad," +
                    "WHERE id_materia=@id", SqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = plan.ID;
                cmdSave.Parameters.Add("@desc_plan", SqlDbType.VarChar, 50).Value = plan.Descripcion;
                cmdSave.Parameters.Add("@id_especialidad", SqlDbType.Int, 50).Value = plan.IDEspecialidad;

                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos del plan", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Insert(Plan plan)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave = new SqlCommand(
                    "INSERT INTO planes ( desc_plan, id_especialidad) " +
                    "values(@desc_plan, @id_especialidad) " +
                    "SELECT @@identity", SqlConn);
                cmdSave.Parameters.Add("@desc_plan", SqlDbType.VarChar, 50).Value = plan.Descripcion;
                cmdSave.Parameters.Add("@id_especialidad", SqlDbType.VarChar, 50).Value = plan.IDEspecialidad;

                plan.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear Plan", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Plan plan)
        {
            if (plan.State == BusinessEntity.States.New)
            {
                this.Insert(plan);
            }
            else if (plan.State == BusinessEntity.States.Deleted)
            {
                this.Delete(plan.ID);
            }
            else if (plan.State == BusinessEntity.States.Modified)
            {
                this.Update(plan);
            }
            plan.State = BusinessEntity.States.Unmodified;
        }
    }
}
