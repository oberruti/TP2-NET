using System;
using System.Collections.Generic;
using System.Linq;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class MateriaAdapter : Adapter
    {
        public List<Materia> GetAll()
        {
            List<Materia> materias = new List<Materia>();

            try
            {
                this.OpenConnection();

                SqlCommand cmdMaterias = new SqlCommand("select * from materias", SqlConn);

                SqlDataReader drMaterias = cmdMaterias.ExecuteReader();

                while (drMaterias.Read())
                {
                    Materia mat = new Materia();

                    mat.ID = (int)drMaterias["id_materia"];
                    mat.Descripcion = (string)drMaterias["desc_materia"];
                    mat.HSSemanales = (int)drMaterias["hs_semanales"];
                    mat.HSTotales = (int)drMaterias["hs_totales"];
                    mat.IDPlan = (int)drMaterias["id_plan"];

                    materias.Add(mat);
                }

                

                drMaterias.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al recuperar lista de materias", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return materias;
        }

        public Business.Entities.Materia GetOne(int ID)
        {
            Materia mat = new Materia();

            try
            {
                this.OpenConnection();

                SqlCommand cmdMaterias = new SqlCommand("select * from materias where id_materia=@id", SqlConn);
                cmdMaterias.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drMaterias = cmdMaterias.ExecuteReader();

                while (drMaterias.Read())
                {

                    mat.ID = (int)drMaterias["id_materia"];
                    mat.Descripcion = (string)drMaterias["desc_materia"];
                    mat.HSSemanales = (int)drMaterias["hs_semanales"];
                    mat.HSTotales = (int)drMaterias["hs_totales"];
                    mat.IDPlan = (int)drMaterias["id_plan"];
                }

                drMaterias.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de materias", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return mat;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete = new SqlCommand("delete materias where id_materia=@id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar materia", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Update(Materia materia)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave = new SqlCommand(
                    "UPDATE materias SET desc_materia=@desc_materia, hs_semanales=@hs_semanales," +
                    "hs_totales=@hs_totales, id_plan=@id_plan " +
                    "WHERE id_materia=@id", SqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = materia.ID;
                cmdSave.Parameters.Add("@desc_materia", SqlDbType.VarChar, 50).Value = materia.Descripcion;
                cmdSave.Parameters.Add("@hs_semanales", SqlDbType.Int, 50).Value = materia.HSSemanales;
                cmdSave.Parameters.Add("@hs_totales", SqlDbType.Int, 50).Value = materia.HSTotales;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int, 50).Value = materia.IDPlan;


                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de la materia", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Insert(Materia materia)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave = new SqlCommand(
                    "INSERT INTO materias ( desc_materia, hs_semanales, hs_totales, id_plan) " +
                    "values(@desc_materia, @hs_semanales, @hs_totales, @id_plan) " +
                    "SELECT @@identity", SqlConn);
                cmdSave.Parameters.Add("@desc_materia", SqlDbType.VarChar, 50).Value = materia.Descripcion;
                cmdSave.Parameters.Add("@hs_semanales", SqlDbType.VarChar, 50).Value = materia.HSSemanales;
                cmdSave.Parameters.Add("@hs_totales", SqlDbType.VarChar, 50).Value = materia.HSTotales;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.VarChar, 50).Value = materia.IDPlan;

                materia.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear Materia", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Materia materia)
        {
            if (materia.State == BusinessEntity.States.New)
            {
                this.Insert(materia);
            }
            else if (materia.State == BusinessEntity.States.Deleted)
            {
                this.Delete(materia.ID);
            }
            else if (materia.State == BusinessEntity.States.Modified)
            {
                this.Update(materia);
            }
            materia.State = BusinessEntity.States.Unmodified;
        }

        public List<Materia> GetAllPlan(int idPlan)
        {
            List<Materia> materia = new List<Materia>();

            try
            {
                OpenConnection();

                SqlCommand cmdMaterias = new SqlCommand("SELECT * FROM materias m " +
                    "inner join planes p on p.id_plan = m.id_plan " +
                    "where m.id_plan = @id_plan", SqlConn);
                cmdMaterias.Parameters.Add("@id_plan", SqlDbType.Int).Value = idPlan;
                SqlDataReader drMaterias = cmdMaterias.ExecuteReader();

                while (drMaterias.Read())
                {
                    Materia mat = new Materia();

                    mat.ID = (int)drMaterias["id_materia"];
                    mat.Descripcion = (string)drMaterias["desc_materia"];
                    mat.HSSemanales = (int)drMaterias["hs_semanales"];
                    mat.HSTotales = (int)drMaterias["hs_totales"];
                    mat.IDPlan = (int)drMaterias["id_plan"];
                    
                    materia.Add(mat);
                }

                drMaterias.Close();


            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de materias.", e);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }

            return materia;
        }

        public object GetAllByComision(int idComision)
        {
            List<Materia> materia = new List<Materia>();

            try
            {
                OpenConnection();

                SqlCommand cmdMaterias = new SqlCommand("  SELECT m.*, p.*, e.* FROM materias m " +
                  " inner join planes p on p.id_plan = m.id_plan " +
                  " inner join especialidades e on e.id_especialidad = p.id_especialidad " +
                  "  INNER JOIN comisiones c ON c.id_plan = p.id_plan " +
                  "WHERE c.id_comision = @idComision", SqlConn);
                cmdMaterias.Parameters.Add("@idComision", SqlDbType.Int).Value = idComision;
                SqlDataReader drMaterias = cmdMaterias.ExecuteReader();

                while (drMaterias.Read())
                {
                    Materia mat = new Materia();

                    mat.ID = (int)drMaterias["id_materia"];
                    mat.Descripcion = (string)drMaterias["desc_materia"];
                    mat.HSSemanales = (int)drMaterias["hs_semanales"];
                    mat.HSTotales = (int)drMaterias["hs_totales"];
                    mat.IDPlan = (int)drMaterias["id_plan"];

                    materia.Add(mat);

                }

                drMaterias.Close();


            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de materias.", e);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }

            return materia;
        }
    }
}
