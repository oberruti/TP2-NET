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

        public Curso GetOne(int idComision, int idMateria)
        {
            Curso cur = new Curso();

            try
            {
                this.OpenConnection();
                SqlCommand cmdCurso = new SqlCommand("SELECT * FROM cursos WHERE id_comision=@id_comision AND id_materia=@id_materia", SqlConn);
                cmdCurso.Parameters.Add("@id_comision", SqlDbType.Int).Value = idComision;
                cmdCurso.Parameters.Add("@id_materia", SqlDbType.Int).Value = idMateria;
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

        public List<Curso> GetAllForDoc(int id_doc)
        {
            List<Curso> cursos = new List<Curso>();
            try
            {
                OpenConnection();

                SqlCommand cmdCursos = new SqlCommand(" SELECT * FROM personas p  " +
                    " INNER JOIN materias m ON m.id_plan = p.id_plan " +
                    " INNER JOIN cursos c ON c.id_materia = m.id_materia  " +
                    " INNER JOIN comisiones com ON  c.id_comision = com.id_comision " +
                    " INNER JOIN planes pl ON pl.id_plan = p.id_plan " +
                    " INNER JOIN especialidades e on e.id_especialidad = pl.id_especialidad " +
                    " WHERE p.id_persona = @id_doc " +
                    " AND  c.id_curso NOT IN   " +
                    " (SELECT dc.id_curso FROM docentes_cursos dc" +
                    " WHERE dc.id_docente = @id_doc )", SqlConn);
                cmdCursos.Parameters.Add("@id_doc", SqlDbType.Int).Value = id_doc;
                SqlDataReader drCursos = cmdCursos.ExecuteReader();

                while (drCursos.Read())
                {
                    Curso cur = new Curso();

                    cur.ID = (int)drCursos["id_curso"];
                    cur.IDMateria = (int)drCursos["id_materia"];
                    cur.IDComision = (int)drCursos["id_comision"];
                    cur.Año_calendario = (int)drCursos["anio_calendario"];
                    cur.Cupo = (int)drCursos["cupo"];

                    cursos.Add(cur);
                }

                drCursos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de cursos GetAll()", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }

            return cursos;

        }

        public List<Curso> GetAllDoc(int id_doc)
        {
            List<Curso> cursos = new List<Curso>();
            try
            {
                OpenConnection();

                SqlCommand cmdCursos = new SqlCommand("select * from cursos c " +
                    "inner join materias m on m.id_materia = c.id_materia " +
                    "inner join docentes_cursos dc on c.id_curso = dc.id_curso " +
                    "inner join comisiones com on com.id_comision = c.id_comision " +
                    "inner join planes p on p.id_plan = com.id_plan " +
                    "inner join especialidades e on e.id_especialidad = p.id_especialidad " +
                    "where dc.id_docente = @id_doc ", SqlConn);
                cmdCursos.Parameters.Add("@id_doc", SqlDbType.Int).Value = id_doc;
                SqlDataReader drCursos = cmdCursos.ExecuteReader();

                while (drCursos.Read())
                {
                    Curso cur = new Curso();

                    cur.ID = (int)drCursos["id_curso"];
                    cur.IDMateria = (int)drCursos["id_materia"];
                    cur.IDComision = (int)drCursos["id_comision"];
                    cur.Año_calendario = (int)drCursos["anio_calendario"];
                    cur.Cupo = (int)drCursos["cupo"];

                    cursos.Add(cur);
                }

                drCursos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de cursos GetAll()", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }

            return cursos;

        }

        public List<Curso> GetAllYearAlum(int idAlumno, int year)
        {
            List<Curso> cursos = new List<Curso>();
            try
            {
                OpenConnection();

                SqlCommand cmdCursos = new SqlCommand("select * from cursos c " +
                    "inner join materias m on m.id_materia = c.id_materia " +
                    "inner join alumnos_inscripciones ai on c.id_curso = ai.id_curso " +
                    "inner join comisiones com on com.id_comision = c.id_comision " +
                    "inner join planes p on p.id_plan = com.id_plan " +
                    "inner join especialidades e on e.id_especialidad = p.id_especialidad " +
                    "where ai.id_alumno = @id_alumno " +
                    "and c.anio_calendario = @year ", SqlConn);
                cmdCursos.Parameters.Add("@id_alumno", SqlDbType.Int).Value = idAlumno;
                cmdCursos.Parameters.Add("@year", SqlDbType.Int).Value = year;
                SqlDataReader drCursos = cmdCursos.ExecuteReader();

                while (drCursos.Read())
                {
                    Curso cur = new Curso();

                    cur.ID = (int)drCursos["id_curso"];
                    cur.IDMateria = (int)drCursos["id_materia"];
                    cur.IDComision = (int)drCursos["id_comision"];
                    cur.Año_calendario = (int)drCursos["anio_calendario"];
                    cur.Cupo = (int)drCursos["cupo"];

                    cursos.Add(cur);
                }

                drCursos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de cursos GetAll()", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }

            return cursos;

        }

        public List<Curso> GetAllForAlum(int idAlumno)
        {
            List<Curso> cursos = new List<Curso>();
            try
            {
                OpenConnection();

                SqlCommand cmdCursos = new SqlCommand("select * from cursos c " +
                    "inner join materias m on m.id_materia = c.id_materia " +
                    "inner join personas per on per.id_plan = m.id_plan  " +
                    "inner join comisiones com on com.id_comision = c.id_comision " +
                    "inner join planes p on p.id_plan = com.id_plan  " +
                    "where per.id_persona = @id_alumno " +
                    "AND m.id_materia NOT IN" +
                    " ( " +
                    " SELECT curs.id_materia FROM alumnos_inscripciones  ai " +
                    " INNER JOIN cursos curs ON curs.id_curso = ai.id_curso	 " +
                    " WHERE  ai.id_alumno  = @id_alumno " +
                    " ) ", SqlConn);
                cmdCursos.Parameters.Add("@id_alumno", SqlDbType.Int).Value = idAlumno;

                SqlDataReader drCursos = cmdCursos.ExecuteReader();

                while (drCursos.Read())
                {
                    Curso cur = new Curso();

                    cur.ID = (int)drCursos["id_curso"];
                    cur.IDMateria = (int)drCursos["id_materia"];
                    cur.IDComision = (int)drCursos["id_comision"];
                    cur.Año_calendario = (int)drCursos["anio_calendario"];
                    cur.Cupo = (int)drCursos["cupo"];

                    cursos.Add(cur);
                }

                drCursos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de cursos GetAll()", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }

            return cursos;

        }

        public DataTable GetAllTabla(int idMateria, int idComision)
        {
            DataTable dt = new DataTable();

            try
            {
                this.OpenConnection();
                SqlCommand cmdCursos = new SqlCommand("SELECT id_curso AS 'ID Curso', c.anio_calendario AS 'Año Calendario', c.cupo AS 'Cupo', m.desc_materia as 'Materia', com.desc_comision AS 'Comision' FROM cursos c INNER JOIN materias m ON c.id_materia=m.id_materia INNER JOIN comisiones com ON com.id_comision=c.id_comision WHERE c.id_materia=@id_materia AND c.id_comision=@id_comision", SqlConn);
                cmdCursos.Parameters.Add("id_materia", SqlDbType.Int).Value = idMateria;
                cmdCursos.Parameters.Add("id_comision", SqlDbType.Int).Value = idComision;

                SqlDataAdapter adaptador = new SqlDataAdapter(cmdCursos);

                adaptador.Fill(dt);
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de cursos", Ex);
                throw ExcepcionManejada;
            }
            finally { this.CloseConnection(); }

            return dt;
        }
    }
}
