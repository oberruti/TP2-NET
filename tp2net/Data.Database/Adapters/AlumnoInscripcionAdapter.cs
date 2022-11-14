using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class AlumnoInscripcionAdapter : Adapter
    {

        public List<AlumnoInscripcion> GetAll()
        {
            List<AlumnoInscripcion> alumnos = new List<AlumnoInscripcion>();

            this.OpenConnection();

            SqlCommand cmdAlumnos = new SqlCommand("select * from alumnos_inscripciones", SqlConn);

            SqlDataReader drAlumnos = cmdAlumnos.ExecuteReader();

            while (drAlumnos.Read())
            {
                AlumnoInscripcion alumno = new AlumnoInscripcion();

                alumno.ID = (int)drAlumnos["id_inscripcion"];
                alumno.IdAlumno = (int)drAlumnos["id_alumno"];
                alumno.IdCurso = (int)drAlumnos["id_curso"];
                alumno.Condicion = (string)drAlumnos["condicion"];
                alumno.Nota = (int)drAlumnos["nota"];

                alumnos.Add(alumno);
            }

            drAlumnos.Close();
            this.CloseConnection();
            return alumnos;
        }

        public AlumnoInscripcion GetOne(int ID)
        {
            AlumnoInscripcion alumno = new AlumnoInscripcion();

            this.OpenConnection();

            SqlCommand cmdAlumnos = new SqlCommand("select * from alumnos_inscripciones where id_inscripcion=@id", SqlConn);
            cmdAlumnos.Parameters.Add("@id", SqlDbType.Int).Value = ID;

            SqlDataReader drAlumnos = cmdAlumnos.ExecuteReader();

            if (drAlumnos.Read())
            {
                alumno.ID = (int)drAlumnos["id_inscripcion"];
                alumno.IdAlumno = (int)drAlumnos["id_alumno"];
                alumno.IdCurso = (int)drAlumnos["id_curso"];
                alumno.Condicion = (string)drAlumnos["condicion"];
                alumno.Nota = (int)drAlumnos["nota"];
            }

            drAlumnos.Close();
            this.CloseConnection();
            return alumno;
        }

        public void Delete(int ID)
        {
            this.OpenConnection();

            SqlCommand cmdDelete = new SqlCommand("delete alumnos_inscripciones where id_inscripcion=@id", SqlConn);
            cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;

            cmdDelete.ExecuteNonQuery();

            this.CloseConnection();
        }

        protected void Update(AlumnoInscripcion alumno)
        {
            this.OpenConnection();
            SqlCommand cmdSave = new SqlCommand(
                "UPDATE alumnos_inscripciones SET id_alumno = @id_alumno, id_curso = @id_curso, condicion = @condicion, nota = @nota WHERE id_inscripcion=@id", SqlConn);

            cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = alumno.ID;
            cmdSave.Parameters.Add("@id_alumno", SqlDbType.Int).Value = alumno.IdAlumno;
            cmdSave.Parameters.Add("@id_curso", SqlDbType.Int).Value = alumno.IdCurso;
            cmdSave.Parameters.Add("@condicion", SqlDbType.VarChar, 50).Value = alumno.Condicion;
            cmdSave.Parameters.Add("@nota", SqlDbType.Int).Value = alumno.Nota;

            cmdSave.ExecuteNonQuery();

            this.CloseConnection();
        }

        protected void Insert(AlumnoInscripcion alumno)
        {
            this.OpenConnection();
            SqlCommand cmdSave = new SqlCommand(
                "insert into alumnos_inscripciones (id_alumno,id_curso,condicion,nota) " +
                "values(@id_alumno,@id_curso,@condicion,@nota) " +
                "select @@identity", SqlConn);

            cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = alumno.ID;
            cmdSave.Parameters.Add("@id_alumno", SqlDbType.Int).Value = alumno.IdAlumno;
            cmdSave.Parameters.Add("@id_curso", SqlDbType.Int).Value = alumno.IdCurso;
            cmdSave.Parameters.Add("@condicion", SqlDbType.VarChar, 50).Value = "Cursando";
            cmdSave.Parameters.Add("@nota", SqlDbType.Int).Value = alumno.Nota;
            alumno.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());

            this.CloseConnection();
        }

        public void Save(AlumnoInscripcion alumno)
        {
            if (alumno.State == BusinessEntity.States.New)
            {
                this.Insert(alumno);
            }
            else if (alumno.State == BusinessEntity.States.Deleted)
            {
                this.Delete(alumno.ID);
            }
            else if (alumno.State == BusinessEntity.States.Modified)
            {
                this.Update(alumno);
            }
            alumno.State = BusinessEntity.States.Unmodified;
        }

        public List<AlumnoInscripcion> GetAllCurso(int idCurso)
        {
            List<AlumnoInscripcion> inscrip = new List<AlumnoInscripcion>();
            try
            {
                OpenConnection();

                SqlCommand cmdInscrip = new SqlCommand("select ai.id_inscripcion, ai.id_alumno, ai.id_curso, ai.condicion, isnull(ai.nota, -1) nota, m.desc_materia, com.desc_comision, concat(p.nombre, p.apellido) nombre, p.legajo  " +
                    "from alumnos_inscripciones ai " +
                    "inner join cursos c on c.id_curso = ai.id_curso " +
                    "inner join materias m on m.id_materia = c.id_materia " +
                    "inner join comisiones com on com.id_comision = c.id_comision " +
                    "inner join personas p on p.id_persona = ai.id_alumno " +
                    "where c.id_curso = @id_curso ", SqlConn);
                cmdInscrip.Parameters.Add("@id_curso", SqlDbType.Int).Value = idCurso;
                SqlDataReader drInscrip = cmdInscrip.ExecuteReader();

                while (drInscrip.Read())
                {
                    AlumnoInscripcion inscrAl = new AlumnoInscripcion();

                    inscrAl.ID = (int)drInscrip["id_inscripcion"];
                    inscrAl.IdAlumno = (int)drInscrip["id_alumno"];
                    inscrAl.IdCurso = (int)drInscrip["id_curso"];
                    inscrAl.Condicion = (string)drInscrip["condicion"];
                    inscrAl.Nota = (int)drInscrip["nota"];

                    inscrip.Add(inscrAl);
                }

                drInscrip.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de las inscripciones de alumnos.", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }

            return inscrip;

        }

        public List<AlumnoInscripcion> GetAllAlum(int idAlumno)
        {
            List<AlumnoInscripcion> inscrip = new List<AlumnoInscripcion>();
            try
            {
                OpenConnection();

                SqlCommand cmdInscrip = new SqlCommand("select ai.id_inscripcion, ai.id_alumno, ai.id_curso, ai.condicion, isnull(ai.nota, -1) nota, m.desc_materia, com.desc_comision, concat(p.nombre, p.apellido) nombre, p.legajo  " +
                    "from alumnos_inscripciones ai " +
                    "inner join cursos c on c.id_curso = ai.id_curso " +
                    "inner join materias m on m.id_materia = c.id_materia " +
                    "inner join comisiones com on com.id_comision = c.id_comision " +
                    "inner join personas p on p.id_persona = ai.id_alumno " +
                    "where ai.id_alumno = @id_alumno ", SqlConn);
                cmdInscrip.Parameters.Add("@id_alumno", SqlDbType.Int).Value = idAlumno;
                SqlDataReader drInscrip = cmdInscrip.ExecuteReader();

                while (drInscrip.Read())
                {
                    AlumnoInscripcion inscrAl = new AlumnoInscripcion();

                    inscrAl.ID = (int)drInscrip["id_inscripcion"];
                    inscrAl.IdAlumno = (int)drInscrip["id_alumno"];
                    inscrAl.IdCurso = (int)drInscrip["id_curso"];
                    inscrAl.Condicion = (string)drInscrip["condicion"];
                    inscrAl.Nota = (int)drInscrip["nota"];

                    inscrip.Add(inscrAl);
                }

                drInscrip.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de las inscripciones de alumnos.", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }

            return inscrip;

        }

        public List<AlumnoInscripcion> GetInscripcionesByCursoId(int cursoId)
        {
            List<AlumnoInscripcion> alumnos = new List<AlumnoInscripcion>();

            try
            {
                this.OpenConnection();

                SqlCommand cmdAlumnos = new SqlCommand("select * from alumnos_inscripciones where id_curso=@id", SqlConn);
                cmdAlumnos.Parameters.Add("@id", SqlDbType.Int).Value = cursoId;

                SqlDataReader drAlumnos = cmdAlumnos.ExecuteReader();

                while (drAlumnos.Read())
                {
                    AlumnoInscripcion alumno = new AlumnoInscripcion();

                    alumno.ID = (int)drAlumnos["id_inscripcion"];
                    alumno.IdAlumno = (int)drAlumnos["id_alumno"];
                    alumno.IdCurso = (int)drAlumnos["id_curso"];
                    alumno.Condicion = (string)drAlumnos["condicion"];
                    alumno.Nota = (int)drAlumnos["nota"];

                    alumnos.Add(alumno);
                }

                drAlumnos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de las inscripciones de alumnos.", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
            return alumnos;
        }
    } 
}


