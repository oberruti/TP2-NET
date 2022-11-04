using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;


namespace Data.Database
{
    public class CursoAdapter : Adapter
    {
        
        public List<Curso> GetAll()
        {
            List<Curso> cursos = new List<Curso>();

            try
            {
                this.OpenConnection();
                SqlCommand cmdCurso = new SqlCommand("SELECT * FROM cursos", SqlConn);
                SqlDataReader drCursos = cmdCurso.ExecuteReader();

                while (drCursos.Read())
                {
                    Curso cur = new Curso();

                    cur.ID = (int)drCursos["id_curso"];
                    cur.Año_calendario = (int)drCursos["anio_calendario"];
                    cur.Descripcion = (string)drCursos["descripcion"];
                    cur.Cupo = (int)drCursos["cupo"];
                    cur.IDComision = (int)drCursos["id_comision"];
                    cur.IDMateria = (int)drCursos["id_materia"];

                    cursos.Add(cur);
                }
                drCursos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de cursos", Ex);
                throw ExcepcionManejada;
            }
            finally { this.CloseConnection(); }

            return cursos;
        }

        public List<Curso> GetAllCursosConCupos()
        {
            List<Curso> cursos = new List<Curso>();
            List<Curso> cursosSinRepetir = new List<Curso>();

            try
            {
                this.OpenConnection();
                SqlCommand cmdCurso = new SqlCommand("SELECT * FROM cursos c WHERE c.cupo > 0", SqlConn);
                SqlDataReader drCursos = cmdCurso.ExecuteReader();

                while (drCursos.Read())
                {
                    Curso cur = new Curso();

                    cur.ID = (int)drCursos["id_curso"];
                    cur.Año_calendario = (int)drCursos["anio_calendario"];
                    cur.Descripcion = (string)drCursos["descripcion"];
                    cur.Cupo = (int)drCursos["cupo"];
                    cur.IDComision = (int)drCursos["id_comision"];
                    cur.IDMateria = (int)drCursos["id_materia"];

                    cursos.Add(cur);
                }
                drCursos.Close();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de cursos", Ex);
                throw ExcepcionManejada;
            }
            finally { this.CloseConnection(); }

            return cursos;
        }

        public Curso GetOne(int ID)
        {
            Curso cur = new Curso();

            try
            {
                this.OpenConnection();
                SqlCommand cmdCurso = new SqlCommand("SELECT * FROM cursos WHERE id_curso=@id", SqlConn);
                cmdCurso.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drCursos = cmdCurso.ExecuteReader();

                while (drCursos.Read())
                {
                    

                    cur.ID = (int)drCursos["id_curso"];
                    cur.Año_calendario = (int)drCursos["anio_calendario"];
                    cur.Descripcion = (string)drCursos["descripcion"];
                    cur.Cupo = (int)drCursos["cupo"];
                    cur.IDComision = (int)drCursos["id_comision"];
                    cur.IDMateria = (int)drCursos["id_materia"];

                }
                drCursos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de cursos", Ex);
                throw ExcepcionManejada;
            }
            finally { this.CloseConnection(); }

            return cur;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete = new SqlCommand("DELETE cursos WHERE id_curso=@id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Update(Curso curso)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave = new SqlCommand(
                    "UPDATE cursos SET anio_calendario=@anio_calendario, descripcion=@descripcion ,cupo=@cupo, id_Materia=@id_materia, id_comision=@id_comision " +
                    "WHERE id_curso=@id", SqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = curso.ID;
                cmdSave.Parameters.Add("@anio_calendario", SqlDbType.VarChar, 50).Value = curso.Año_calendario;
                cmdSave.Parameters.Add("@cupo", SqlDbType.VarChar, 50).Value = curso.Cupo;
                cmdSave.Parameters.Add("@id_materia", SqlDbType.VarChar, 50).Value = curso.IDMateria;
                cmdSave.Parameters.Add("@id_comision", SqlDbType.VarChar, 50).Value = curso.IDComision;
                cmdSave.Parameters.Add("@descripcion", SqlDbType.VarChar, 50).Value = curso.Descripcion;


                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos del usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Insert(Curso curso)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave = new SqlCommand(
                    "INSERT INTO cursos( anio_calendario, descripcion ,cupo, id_materia, id_comision) " +
                    "values( @anio_calendario, @cupo, @id_materia, @id_comision, @descripcion) " +
                    "SELECT @@identity", SqlConn);
                cmdSave.Parameters.Add("@anio_calendario", SqlDbType.VarChar, 50).Value = curso.Año_calendario;
                cmdSave.Parameters.Add("@cupo", SqlDbType.VarChar, 50).Value = curso.Cupo;
                cmdSave.Parameters.Add("@id_materia", SqlDbType.VarChar, 50).Value = curso.IDMateria;
                cmdSave.Parameters.Add("@id_comision", SqlDbType.VarChar, 50).Value = curso.IDComision;
                cmdSave.Parameters.Add("@descripcion", SqlDbType.VarChar, 50).Value = curso.Descripcion;

                curso.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
           

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al Crear Curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Save(Curso curso)
        {
            if (curso.State == BusinessEntity.States.New)
            {
                this.Insert(curso);
            }
            else if (curso.State == BusinessEntity.States.Deleted)
            {
                this.Delete(curso.ID);
            }
            else if (curso.State == BusinessEntity.States.Modified)
            {
                this.Update(curso);
            }
            curso.State = BusinessEntity.States.Unmodified;
        }
    }
}
