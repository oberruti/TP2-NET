using Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Data.Database
{
    public class ReporteCursoAdapter : Adapter
    {
        public List<ReporteCurso> GetAll(int comisionId, int materiaId)
        {
            List<ReporteCurso> listaReporteCursos = new List<ReporteCurso>();


            try
            {
                this.OpenConnection();

                SqlCommand cmdReporteCurso = new SqlCommand("select p.* from personas as p " +
                                                            "inner join alumnos_inscripciones as ai on p.id_persona = ai.id_alumno " +
                                                            "inner join cursos as c on c.id_curso = ai.id_curso " +
                                                            "inner join comisiones com on com.id_comision = c.id_comision " +
                                                            "inner join materias as m on m.id_plan = p.id_plan " +
                                                            "where p.tipo_persona = 0 " +
                                                            "and com.id_comision = @comisionId " +
                                                            "and m.id_materia = @materiaId ", SqlConn);

                cmdReporteCurso.Parameters.Add("@comisionId", SqlDbType.Int).Value = comisionId;
                cmdReporteCurso.Parameters.Add("@materiaId", SqlDbType.Int).Value = materiaId;

                SqlDataReader drReporteCurso = cmdReporteCurso.ExecuteReader();

                while (drReporteCurso.Read())
                {
                    var alumno = new Persona();
                    var reporteCurso = new ReporteCurso();

                    alumno.ID = (int)drReporteCurso["id_persona"];
                    alumno.Nombre = (string)drReporteCurso["nombre"];
                    alumno.Apellido = (string)drReporteCurso["apellido"];
                    alumno.Direccion = (string)drReporteCurso["direccion"];
                    alumno.Email = (string)drReporteCurso["email"];
                    alumno.Telefono = (string)drReporteCurso["telefono"];
                    alumno.FechaNacimiento = (DateTime)drReporteCurso["fecha_nac"];
                    alumno.Legajo = (int)drReporteCurso["legajo"];
                    alumno.IDPlan = (int)drReporteCurso["id_plan"];
                    alumno.NombreUsuario = (string)drReporteCurso["nombre_usuario"];
                    alumno.Clave = (string)drReporteCurso["clave"];
                    alumno.Habilitado = (bool)drReporteCurso["habilitado"];



                    reporteCurso.persona = alumno;


                    listaReporteCursos.Add(reporteCurso);
                }

                drReporteCurso.Close();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
               new Exception("Error al recuperar lista de cursos", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }

            return listaReporteCursos;
        }
    }
}
