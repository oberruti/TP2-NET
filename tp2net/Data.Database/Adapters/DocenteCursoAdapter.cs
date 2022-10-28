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

                SqlCommand cmdDocCur = new SqlCommand("select * from docentes_cursos where id_curso=@id_curso", sqlConn);
                cmdDocCur.Parameters.Add("@id_curso", SqlDbType.Int).Value = IDCurso;
                SqlDataReader drDocCur = cmdDocCur.ExecuteReader();

                while (drDocCur.Read())
                {
                    DocenteCurso dc = new DocenteCurso();

                    dc.ID = (int)drDocCur["id_dictado"];
                    dc.IdCurso = (int)drDocCur["id_curso"];
                    dc.IdDocente = (int)drDocCur["id_docente"];
                    int cargo = (int)drDocCur["cargo"];
                    if (cargo == 0)
                        dc.Cargo = DocenteCurso.TiposCargo.Titular;
                    else
                        dc.Cargo = DocenteCurso.TiposCargo.Ayudante;

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

                SqlCommand cmdSave = new SqlCommand("INSERT INTO docentes_cursos (id_curso, id_docente, cargo) VALUES (@id_curso, @id_docente, @cargo) select @@identity", sqlConn);

                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int).Value = dictado.IdCurso;
                cmdSave.Parameters.Add("@id_docente", SqlDbType.Int).Value = dictado.IdDocente;
                if (dictado.Cargo == DocenteCurso.TiposCargo.Titular)
                    cmdSave.Parameters.Add("@cargo", SqlDbType.Int).Value = 0;
                else
                    cmdSave.Parameters.Add("@cargo", SqlDbType.Int).Value = 1;

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

                SqlCommand cmdSave = new SqlCommand("UPDATE docentes_cursos set id_curso=@id_curso, id_docente=@id_docente, cargo=@cargo WHERE id_dictado=@id_dictado", sqlConn);

                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int).Value = dictado.IdCurso;
                cmdSave.Parameters.Add("@id_docente", SqlDbType.Int).Value = dictado.IdDocente;
                cmdSave.Parameters.Add("@id_dictado", SqlDbType.Int).Value = dictado.ID;
                if (dictado.Cargo == DocenteCurso.TiposCargo.Titular)
                    cmdSave.Parameters.Add("@cargo", SqlDbType.Int).Value = 0;
                else
                    cmdSave.Parameters.Add("@cargo", SqlDbType.Int).Value = 1;

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

                SqlCommand cmdDelete = new SqlCommand("delete docentes_curso where id_dictado=@id", sqlConn);
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

    }
}