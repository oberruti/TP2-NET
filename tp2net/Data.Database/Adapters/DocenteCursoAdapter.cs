using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data.SqlClient;
using System.Data;

namespace Data.Database
{
    public class DocenteCursoAdapter : Adapter
    {

        public List<DocenteCurso> GetByCurso(int IDCurso)
        {
            List<DocenteCurso> listDC = new List<DocenteCurso>();

            try
            {
                this.OpenConnection();

                SqlCommand cmdDocCur = new SqlCommand("select * from docentes_cursos where id_curso=@id_curso", SqlConn);
                cmdDocCur.Parameters.Add("@id_curso", SqlDbType.Int).Value = IDCurso;
                SqlDataReader drDocCur = cmdDocCur.ExecuteReader();

                while (drDocCur.Read())
                {
                    DocenteCurso dc = new DocenteCurso();

                    dc.ID = (int)drDocCur["id_dictado"];
                    dc.IDCurso = (int)drDocCur["id_curso"];
                    dc.IDDocente = (int)drDocCur["id_docente"];
                    int cargo = (int)drDocCur["cargo"];
                    if (cargo == 0)
                        dc.Cargo = TiposCargo.Jefe;
                    else if (cargo == 1)
                        dc.Cargo = TiposCargo.Docente;
                    else dc.Cargo = TiposCargo.Ayudante;

                    listDC.Add(dc);
                }

                drDocCur.Close();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
               new Exception("Error al recuperar lista de dictados", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }

            return listDC;
        }


        public void Insert(DocenteCurso dictado)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave = new SqlCommand("INSERT INTO docentes_cursos (id_curso, id_docente, cargo) VALUES (@id_curso, @id_docente, @cargo) select @@identity", SqlConn);

                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int).Value = dictado.IDCurso;
                cmdSave.Parameters.Add("@id_docente", SqlDbType.Int).Value = dictado.IDDocente;
                if (dictado.Cargo == TiposCargo.Jefe)
                {
                    cmdSave.Parameters.Add("@cargo", SqlDbType.Int).Value = 0;
                }
                else if (dictado.Cargo == TiposCargo.Docente)
                {
                    cmdSave.Parameters.Add("@cargo", SqlDbType.Int).Value = 1;
                }
                else { cmdSave.Parameters.Add("@cargo", SqlDbType.Int).Value = 2; }

                dictado.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear dictado", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Update(DocenteCurso dictado)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave = new SqlCommand("UPDATE docentes_cursos set id_curso=@id_curso, id_docente=@id_docente, cargo=@cargo WHERE id_dictado=@id_dictado", SqlConn);

                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int).Value = dictado.IDCurso;
                cmdSave.Parameters.Add("@id_docente", SqlDbType.Int).Value = dictado.IDDocente;
                cmdSave.Parameters.Add("@id_dictado", SqlDbType.Int).Value = dictado.ID;
                if (dictado.Cargo == TiposCargo.Jefe)
                    cmdSave.Parameters.Add("@cargo", SqlDbType.Int).Value = 0;
                else if (dictado.Cargo == TiposCargo.Docente)
                    cmdSave.Parameters.Add("@cargo", SqlDbType.Int).Value = 1;
                else cmdSave.Parameters.Add("@cargo", SqlDbType.Int).Value = 2;

                cmdSave.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de dictado", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete = new SqlCommand("delete docentes_curso where id_dictado=@id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar dictado", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(DocenteCurso dictado)
        {
            if (dictado.State == BusinessEntity.States.Deleted)
            {
                this.Delete(dictado.ID);
            }
            else if (dictado.State == BusinessEntity.States.New)
            {
                this.Insert(dictado);
            }
            else if (dictado.State == BusinessEntity.States.Modified)
            {
                this.Update(dictado);
            }
            dictado.State = BusinessEntity.States.Unmodified;
        }

        public List<DocenteCurso> GetAll()
        {
            List<DocenteCurso> docentes_cursos = new List<DocenteCurso>();
            try
            {
                OpenConnection();

                SqlCommand cmdDocentes_Cursos = new SqlCommand("select * from docentes_cursos dc " +
                    "inner join cursos c on c.id_curso = dc.id_curso " +
                    "inner join materias m on m.id_materia = c.id_materia " +
                    "inner join comisiones com on com.id_comision = c.id_comision " +
                    "inner join personas p on p.id_persona = dc.id_docente ", SqlConn);

                SqlDataReader drDocentes_Cursos = cmdDocentes_Cursos.ExecuteReader();

                while (drDocentes_Cursos.Read())
                {
                    DocenteCurso dc = new DocenteCurso();

                    dc.ID = (int)drDocentes_Cursos["id_dictado"];
                    dc.IDCurso = (int)drDocentes_Cursos["id_curso"];
                    dc.IDDocente = (int)drDocentes_Cursos["id_docente"];

                    if ((int)drDocentes_Cursos["cargo"] == (int)TiposCargo.Jefe)
                    {
                        dc.Cargo = TiposCargo.Jefe;
                    }
                    else if ((int)drDocentes_Cursos["cargo"] == (int)TiposCargo.Docente)
                    {
                        dc.Cargo = TiposCargo.Docente;
                    }
                    else
                    {
                        dc.Cargo = TiposCargo.Ayudante;
                    }

                    docentes_cursos.Add(dc);
                }

                drDocentes_Cursos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de Docentes_cursos.", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }

            return docentes_cursos;

        }

        public List<DocenteCurso> GetAllYearDoc(int idDoc, int year)
        {
            List<DocenteCurso> docentes_cursos = new List<DocenteCurso>();
            try
            {
                OpenConnection();

                SqlCommand cmdDocentes_Cursos = new SqlCommand("select * from docentes_cursos dc " +
                    "inner join cursos c on c.id_curso = dc.id_curso " +
                    "inner join personas p on p.id_persona = dc.id_docente " +
                    "where dc.id_docente=@id_docente " +
                    "and c.anio_calendario = @year ", SqlConn);
                cmdDocentes_Cursos.Parameters.Add("@id_docente", SqlDbType.Int).Value = idDoc;
                cmdDocentes_Cursos.Parameters.Add("@year", SqlDbType.Int).Value = year;
                SqlDataReader drDocentes_Cursos = cmdDocentes_Cursos.ExecuteReader();

                while (drDocentes_Cursos.Read())
                {
                    DocenteCurso dc = new DocenteCurso();

                    dc.ID = (int)drDocentes_Cursos["id_dictado"];
                    dc.IDCurso = (int)drDocentes_Cursos["id_curso"];
                    dc.IDDocente = (int)drDocentes_Cursos["id_docente"];
                    if ((int)drDocentes_Cursos["cargo"] == (int)TiposCargo.Jefe)
                    {
                        dc.Cargo = TiposCargo.Jefe;
                    }
                    else if ((int)drDocentes_Cursos["cargo"] == (int)TiposCargo.Docente)
                    {
                        dc.Cargo = TiposCargo.Docente;
                    }
                    else
                    {
                        dc.Cargo = TiposCargo.Ayudante;
                    }

                    docentes_cursos.Add(dc);
                }

                drDocentes_Cursos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de Docentes_cursos.", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }

            return docentes_cursos;

        }

        public DocenteCurso GetOne(int id_dictado)
        {
            DocenteCurso dc = new DocenteCurso();
            try
            {
                OpenConnection();
                SqlCommand cmdDocentes_Cursos = new SqlCommand("select * from docentes_cursos dc " +
                    "inner join cursos c on c.id_curso = dc.id_curso " +
                    "inner join personas p on p.id_persona = dc.id_docente " +
                    "WHERE dc.id_dictado = @id_dictado", SqlConn);
                cmdDocentes_Cursos.Parameters.Add("@id_dictado", SqlDbType.Int).Value = id_dictado;
                SqlDataReader drDocentes_Cursos = cmdDocentes_Cursos.ExecuteReader();
                while (drDocentes_Cursos.Read())
                {
                    dc.ID = (int)drDocentes_Cursos["id_dictado"];
                    dc.IDCurso = (int)drDocentes_Cursos["id_curso"];
                    dc.IDDocente = (int)drDocentes_Cursos["id_docente"];
                    if ((int)drDocentes_Cursos["cargo"] == (int)TiposCargo.Jefe)
                    {
                        dc.Cargo = TiposCargo.Jefe;
                    }
                    else if ((int)drDocentes_Cursos["cargo"] == (int)TiposCargo.Docente)
                    {
                        dc.Cargo = TiposCargo.Docente;
                    }
                    else
                    {
                        dc.Cargo = TiposCargo.Ayudante;
                    }
                }
                drDocentes_Cursos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de docentes_cursos", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
            if (dc.ID != 0)
            {
                return dc;
            }
            else
            {
                throw new Exception("El curso no existe para ese docente");
            }
        }

    }
}