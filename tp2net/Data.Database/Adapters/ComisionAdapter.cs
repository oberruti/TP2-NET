using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class ComisionAdapter : Adapter
    {
        public List<Comision> GetAll()
        {
            List<Comision> comisions = new List<Comision>();

            try
            {
                this.OpenConnection();

                SqlCommand cmdComisions = new SqlCommand("SELECT * FROM comisiones", SqlConn);

                SqlDataReader drComisions = cmdComisions.ExecuteReader();

                while (drComisions.Read())
                {
                    Comision com = new Comision();

                    com.ID = (int)drComisions["id_comision"];
                    com.Desc_comision = (string)drComisions["desc_comision"];
                    com.Anio_especialidad = (int)drComisions["anio_especialidad"];
                    com.IDPlan = (int)drComisions["id_plan"];

                    comisions.Add(com);

                }

                drComisions.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de Comisions", Ex);
                throw ExcepcionManejada;
            }
            finally { this.CloseConnection(); }

            return comisions;
        }


        public Business.Entities.Comision GetOne(int ID)
        {
            Comision com = new Comision();
            try
            {
                this.OpenConnection();

                SqlCommand cmdComisions = new SqlCommand("SELECT * FROM comisiones WHERE id_comision=@id", SqlConn);
                cmdComisions.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drComisions = cmdComisions.ExecuteReader();

                while (drComisions.Read())
                {
                    com.ID = (int)drComisions["id_comision"];
                    com.Desc_comision = (string)drComisions["desc_comision"];
                    com.Anio_especialidad = (int)drComisions["anio_especialidad"];
                    com.IDPlan = (int)drComisions["id_plan"];
                }

                drComisions.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar Comision", Ex);
                throw ExcepcionManejada;
            }
            finally { this.CloseConnection(); }

            return com;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete = new SqlCommand("DELETE comisiones WHERE id_comision=@id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar comision", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

        }

        public void Update(Comision comision)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave = new SqlCommand(
                    "UPDATE comisiones SET desc_comision=@desc_comision, anio_especialidad=@anio_especialidad, " +
                    "id_plan=@id_plan WHERE id_comision=@id", SqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = comision.ID;
                cmdSave.Parameters.Add("@desc_comision", SqlDbType.VarChar, 50).Value = comision.Desc_comision;
                cmdSave.Parameters.Add("@anio_especialidad", SqlDbType.VarChar, 50).Value = comision.Anio_especialidad;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.VarChar, 50).Value = comision.IDPlan;


                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de la comision", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Insert(Comision comision)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave = new SqlCommand(
                    "INSERT INTO comisiones(desc_comision, anio_especialidad, id_plan) " +
                    "values(@desc_comision, @anio_especialidad, @id_plan) " +
                    "SELECT @@identity", SqlConn);
                cmdSave.Parameters.Add("@desc_comision", SqlDbType.VarChar, 50).Value = comision.Desc_comision;
                cmdSave.Parameters.Add("@anio_especialidad", SqlDbType.VarChar, 50).Value = comision.Anio_especialidad;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.VarChar, 50).Value = comision.IDPlan;

                comision.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear comision", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Save(Comision com)
        {
            if (com.State == BusinessEntity.States.New)
            {
                this.Insert(com);
            }
            else if (com.State == BusinessEntity.States.Deleted)
            {
                this.Delete(com.ID);
            }
            else if (com.State == BusinessEntity.States.Modified)
            {
                this.Update(com);
            }
            com.State = BusinessEntity.States.Unmodified;
        }

        public List<Comision> GetAllByMateria(int idMateria)
        {
            List<Comision> comisiones = new List<Comision>();
            try
            {
                OpenConnection();

                SqlCommand cmdComisiones = new SqlCommand("SELECT c.*, p.*, e.* FROM comisiones c " +
                    "inner join planes p on p.id_plan = c.id_plan " +
                    "inner join especialidades e on e.id_especialidad= p.id_especialidad " +
                      " inner join materias m ON m.id_plan = p.id_plan " +
                    " WHERE m.id_materia  = @idMateria", SqlConn);

                cmdComisiones.Parameters.Add("@idMateria", SqlDbType.Int).Value = idMateria;

                SqlDataReader drComisiones = cmdComisiones.ExecuteReader();

                while (drComisiones.Read())
                {
                    Comision com = new Comision();

                    com.ID = (int)drComisiones["id_comision"];
                    com.Desc_comision = (string)drComisiones["desc_comision"];
                    com.Anio_especialidad = (int)drComisiones["anio_especialidad"];
                    com.IDPlan = (int)drComisiones["id_plan"];

                    comisiones.Add(com);
                }

                drComisiones.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de comisiones.", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
            return comisiones;
        }
    }
}
