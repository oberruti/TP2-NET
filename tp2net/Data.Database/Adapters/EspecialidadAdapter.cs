using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class EspecialidadAdapter : Adapter
    {

        public List<Especialidad> GetAll()
        {
            List<Especialidad> especialidades = new List<Especialidad>();

            try
            {
                this.OpenConnection();

                SqlCommand cmdEspecialidad = new SqlCommand("select * from especialidades", SqlConn);

                SqlDataReader drEspecialidades = cmdEspecialidad.ExecuteReader();

                while (drEspecialidades.Read())
                {
                    Especialidad especialidad = new Especialidad();

                    especialidad.ID = (int)drEspecialidades["id_especialidad"];
                    especialidad.Descripcion = (string)drEspecialidades["desc_especialidad"];

                    especialidades.Add(especialidad);
                }

                drEspecialidades.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al recuperar lista de especialidades", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return especialidades;
        }

        public Especialidad GetOne(int ID)
        {
            Especialidad especialidad = new Especialidad();

            try
            {
                this.OpenConnection();

                SqlCommand cmdEspecialidad = new SqlCommand("select * from especialidades where id_especialidad=@id", SqlConn);
                cmdEspecialidad.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drPlanes = cmdEspecialidad.ExecuteReader();

                while (drPlanes.Read())
                {
                    especialidad.ID = (int)drPlanes["id_especialidad"];
                    especialidad.Descripcion = (string)drPlanes["desc_especialidad"];
                }

                drPlanes.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar especialidad", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return especialidad;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete = new SqlCommand("delete especialidades where id_especialidad=@id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar especialidad", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Update(Especialidad esp)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave = new SqlCommand("UPDATE especialidades set desc_especialidad=@desc WHERE id_especialidad=@id", SqlConn);

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = esp.ID;
                cmdSave.Parameters.Add("@desc", SqlDbType.VarChar, 50).Value = esp.Descripcion;

                cmdSave.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de especialidad", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

        }

        protected void Insert(Especialidad esp)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave = new SqlCommand("INSERT INTO especialidades (desc_especialidad) VALUES (@desc) select @@identity", SqlConn);

                cmdSave.Parameters.Add("@desc", SqlDbType.VarChar, 50).Value = esp.Descripcion;

                esp.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear especialidad", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

        }

        public void Save(Especialidad esp)
        {
            if (esp.State == BusinessEntity.States.New)
            {
                this.Insert(esp);
            }
            else if (esp.State == BusinessEntity.States.Deleted)
            {
                this.Delete(esp.ID);
            }
            else if (esp.State == BusinessEntity.States.Modified)
            {
                this.Update(esp);
            }
            esp.State = BusinessEntity.States.Unmodified;
        }
    }
}
