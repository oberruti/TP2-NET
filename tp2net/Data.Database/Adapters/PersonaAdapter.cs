using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class PersonaAdapter : Adapter
    {

        public List<Persona> GetAll()
        {
            List<Persona> personas = new List<Persona>();

            try
            {
                this.OpenConnection();

                SqlCommand cmdPersonas = new SqlCommand("select * from personas p inner join usuarios u on u.id_persona=p.id_persona ", SqlConn);

                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();

                while (drPersonas.Read())
                {
                    Persona per = new Persona();

                    per.ID = (int)drPersonas["id_persona"];
                    per.Nombre = (string)drPersonas["nombre"];
                    per.Apellido = (string)drPersonas["apellido"];
                    per.Direccion = (string)drPersonas["direccion"];
                    per.Email = (string)drPersonas["email"];
                    per.Telefono = (string)drPersonas["telefono"];
                    per.FechaNacimiento = (DateTime)drPersonas["fecha_nac"];
                    per.Legajo = (int)drPersonas["legajo"];
                    per.IDPlan = (int)drPersonas["id_plan"];
                    per.Clave = (string)drPersonas["clave"];
                    per.Habilitado = (bool)drPersonas["habilitado"];
                    per.NombreUsuario = (string)drPersonas["nombre_usuario"];

                    if ((int)drPersonas["tipo_persona"] == (int)TiposPersonas.Alumno)
                        per.TipoPersona = TiposPersonas.Alumno;
                    else
                        per.TipoPersona = TiposPersonas.Docente;

                    personas.Add(per);
                }

                drPersonas.Close();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
               new Exception("Error al recuperar lista de personas", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }

            return personas;
        }

        public Persona GetOne(int ID)
        {
            Persona per = new Persona();

            try
            {
                this.OpenConnection();

                SqlCommand cmdPersonas = new SqlCommand("select DISTINCT * from personas p inner join usuarios u on u.id_persona=p.id_persona where p.id_persona=@id", SqlConn);
                cmdPersonas.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();

                if (drPersonas.Read())
                {
                    per.ID = (int)drPersonas["id_persona"];
                    per.Nombre = (string)drPersonas["nombre"];
                    per.Apellido = (string)drPersonas["apellido"];
                    per.Direccion = (string)drPersonas["direccion"];
                    per.Email = (string)drPersonas["email"];
                    per.Telefono = (string)drPersonas["telefono"];
                    per.FechaNacimiento = (DateTime)drPersonas["fecha_nac"];
                    per.Legajo = (int)drPersonas["legajo"];
                    per.IDPlan = (int)drPersonas["id_plan"];
                    per.Clave = (string)drPersonas["clave"];
                    per.Habilitado = (bool)drPersonas["habilitado"];
                    per.NombreUsuario = (string)drPersonas["nombre_usuario"];

                    if ((int)drPersonas["tipo_persona"] == (int)TiposPersonas.Alumno)
                        per.TipoPersona = TiposPersonas.Alumno;
                    else
                        per.TipoPersona = TiposPersonas.Docente;
                }

                drPersonas.Close();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
               new Exception("Error al recuperar lista de personas", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }

            return per;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete = new SqlCommand("delete usuarios where id_persona=@id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                cmdDelete.ExecuteNonQuery();

                SqlCommand cmdDeletePersona = new SqlCommand("delete personas where id_persona=@id", SqlConn);
                cmdDeletePersona.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                cmdDeletePersona.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar persona", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Persona persona)
        {

            if (persona.State == BusinessEntity.States.Deleted)
            {
                this.Delete(persona.ID);
            }
            else if (persona.State == BusinessEntity.States.New)
            {
                this.Insert(persona);
            }
            else if (persona.State == BusinessEntity.States.Modified)
            {
                this.Update(persona);
            }
            persona.State = BusinessEntity.States.Unmodified;
        }

        protected void Update(Persona persona)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave = new SqlCommand("UPDATE personas set nombre=@nombre, apellido=@apellido, direccion=@direccion, email=@email, telefono=@telefono, fecha_nac=@fecha_nac, legajo=@legajo, tipo_persona=@tipo_persona, id_plan=@id_plan WHERE id_persona=@id", SqlConn);

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = persona.ID;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = persona.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = persona.Apellido;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = persona.Email;
                cmdSave.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = persona.Direccion;
                cmdSave.Parameters.Add("@telefono", SqlDbType.VarChar, 50).Value = persona.Telefono;
                cmdSave.Parameters.Add("@fecha_nac", SqlDbType.DateTime).Value = persona.FechaNacimiento;
                cmdSave.Parameters.Add("@legajo", SqlDbType.Int).Value = persona.Legajo;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = persona.IDPlan;

                if (persona.TipoPersona == TiposPersonas.Alumno)
                    cmdSave.Parameters.Add("@tipo_persona", SqlDbType.Int).Value = 3;
                else
                    cmdSave.Parameters.Add("@tipo_persona", SqlDbType.Int).Value = 2;

                cmdSave.ExecuteNonQuery();

                SqlCommand cmdSaveUser = new SqlCommand("UPDATE usuarios set nombre=@nombre, apellido=@apellido, clave=@clave, email=@email, habilitado=@habilitado, nombre_usuario=@nombre_usuario WHERE id_persona=@id", SqlConn);

                cmdSaveUser.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = persona.Nombre;
                cmdSaveUser.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = persona.Apellido;
                cmdSaveUser.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = persona.Email;
                cmdSaveUser.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = persona.Clave;
                cmdSaveUser.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = persona.NombreUsuario;
                cmdSaveUser.Parameters.Add("@habilitado", SqlDbType.Bit).Value = persona.Habilitado;
                cmdSaveUser.Parameters.Add("@id", SqlDbType.Int).Value = persona.ID;


                cmdSaveUser.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de persona", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

        }

        protected void Insert(Persona persona)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave = new SqlCommand("INSERT INTO personas (nombre, apellido, email, direccion, telefono, fecha_nac, tipo_persona, id_plan, legajo) VALUES (@nombre, @apellido, @email, @direccion, @telefono, @fecha_nac, @tipo_persona, @id_plan, @legajo) select @@identity", SqlConn);

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = persona.ID;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = persona.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = persona.Apellido;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = persona.Email;
                cmdSave.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = persona.Direccion;
                cmdSave.Parameters.Add("@telefono", SqlDbType.VarChar, 50).Value = persona.Telefono;
                cmdSave.Parameters.Add("@legajo", SqlDbType.VarChar, 50).Value = persona.Legajo;
                cmdSave.Parameters.Add("@fecha_nac", SqlDbType.DateTime).Value = persona.FechaNacimiento;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = persona.IDPlan;

                if (persona.TipoPersona == TiposPersonas.Alumno)
                    cmdSave.Parameters.Add("@tipo_persona", SqlDbType.Int).Value = 3;
                else
                    cmdSave.Parameters.Add("@tipo_persona", SqlDbType.Int).Value = 2;

                persona.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear persona", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            try
            {
                this.OpenConnection();

                SqlCommand cmdSaveUser = new SqlCommand("INSERT INTO usuarios (nombre, apellido, email, clave, nombre_usuario, habilitado, id_persona) VALUES (@nombre, @apellido, @email, @clave, @nombre_usuario, @habilitado, @id_persona) select @@identity", SqlConn);

                cmdSaveUser.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = persona.Nombre;
                cmdSaveUser.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = persona.Apellido;
                cmdSaveUser.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = persona.Email;
                cmdSaveUser.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = persona.Clave;
                cmdSaveUser.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = persona.NombreUsuario;
                cmdSaveUser.Parameters.Add("@habilitado", SqlDbType.Bit).Value = persona.Habilitado;
                cmdSaveUser.Parameters.Add("@id_persona", SqlDbType.Int).Value = persona.ID;
                Decimal.ToInt32((decimal)cmdSaveUser.ExecuteScalar());

            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear persona", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

        }

        public List<Persona> GetAllAlumnos()
        {
            List<Persona> personas = new List<Persona>();

            try
            {
                this.OpenConnection();

                SqlCommand cmdPersonas = new SqlCommand("select * from personas p inner join usuarios u on u.id_persona = p.id_persona where tipo_persona=3", SqlConn);

                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();

                while (drPersonas.Read())
                {
                    Persona per = new Persona();

                    per.ID = (int)drPersonas["id_persona"];
                    per.Nombre = (string)drPersonas["nombre"];
                    per.Apellido = (string)drPersonas["apellido"];
                    per.Direccion = (string)drPersonas["direccion"];
                    per.Email = (string)drPersonas["email"];
                    per.Telefono = (string)drPersonas["telefono"];
                    per.FechaNacimiento = (DateTime)drPersonas["fecha_nac"];
                    per.Legajo = (int)drPersonas["legajo"];
                    per.IDPlan = (int)drPersonas["id_plan"];
                    per.Clave = (string)drPersonas["clave"];
                    per.Habilitado = (bool)drPersonas["habilitado"];
                    per.NombreUsuario = (string)drPersonas["nombre_usuario"];
                    per.TipoPersona = TiposPersonas.Alumno;

                    personas.Add(per);
                }

                drPersonas.Close();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
               new Exception("Error al recuperar lista de personas", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }

            return personas;
        }

        public List<Persona> GetAllDocentes()
        {
            List<Persona> personas = new List<Persona>();

            try
            {
                this.OpenConnection();

                SqlCommand cmdPersonas = new SqlCommand("select * from personas p inner join usuarios u on u.id_persona = p.id_persona where tipo_persona=2", SqlConn);

                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();

                while (drPersonas.Read())
                {
                    Persona per = new Persona();

                    per.ID = (int)drPersonas["id_persona"];
                    per.Nombre = (string)drPersonas["nombre"];
                    per.Apellido = (string)drPersonas["apellido"];
                    per.Direccion = (string)drPersonas["direccion"];
                    per.Email = (string)drPersonas["email"];
                    per.Telefono = (string)drPersonas["telefono"];
                    per.FechaNacimiento = (DateTime)drPersonas["fecha_nac"];
                    per.Legajo = (int)drPersonas["legajo"];
                    per.IDPlan = (int)drPersonas["id_plan"];
                    per.Clave = (string)drPersonas["clave"];
                    per.Habilitado = (bool)drPersonas["habilitado"];
                    per.NombreUsuario = (string)drPersonas["nombre_usuario"];
                    per.TipoPersona = TiposPersonas.Alumno;

                    personas.Add(per);
                }

                drPersonas.Close();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
               new Exception("Error al recuperar lista de personas", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }

            return personas;
        }

        public bool ValidarPersona(string username, string pass)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdUsuarios = new SqlCommand("select * from usuarios where nombre_usuario = @nomuser and clave = @clave", SqlConn);
                cmdUsuarios.Parameters.Add("@nomuser", SqlDbType.VarChar).Value = username;
                cmdUsuarios.Parameters.Add("@clave", SqlDbType.VarChar).Value = pass;

                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();

                if (drUsuarios.Read())
                {
                    drUsuarios.Close();
                    return true;
                }
                else
                {
                    drUsuarios.Close();
                    return false;
                }
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al validar el usuario", Ex);

                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();

            }
        }

        public Persona GetOneByNombreUsuario(string username)
        {
            Persona per = new Persona();

            try
            {
                this.OpenConnection();

                SqlCommand cmdPersonas = new SqlCommand("select * from personas p inner join usuarios u on u.id_persona=p.id_persona where u.nombre_usuario=@user", SqlConn);
                cmdPersonas.Parameters.Add("@user", SqlDbType.VarChar, 50).Value = username;
                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();

                if (drPersonas.Read())
                {
                    per.ID = (int)drPersonas["id_persona"];
                    per.Nombre = (string)drPersonas["nombre"];
                    per.Apellido = (string)drPersonas["apellido"];
                    per.Direccion = (string)drPersonas["direccion"];
                    per.Email = (string)drPersonas["email"];
                    per.Telefono = (string)drPersonas["telefono"];
                    per.FechaNacimiento = (DateTime)drPersonas["fecha_nac"];
                    per.Legajo = (int)drPersonas["legajo"];
                    per.IDPlan = (int)drPersonas["id_plan"];
                    per.Clave = (string)drPersonas["clave"];
                    per.Habilitado = (bool)drPersonas["habilitado"];
                    per.NombreUsuario = (string)drPersonas["nombre_usuario"];

                    if ((int)drPersonas["tipo_persona"] == (int)TiposPersonas.Alumno)
                        per.TipoPersona = TiposPersonas.Alumno;
                    else if ((int)drPersonas["tipo_persona"] == (int)TiposPersonas.Docente)
                    {
                        per.TipoPersona = TiposPersonas.Docente;
                    }
                    else
                    {
                        per.TipoPersona = TiposPersonas.Admin;
                    }
                }

                drPersonas.Close();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
               new Exception("Error al recuperar lista de personas", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }

            return per;
        }


        /*public List<DocenteCurso> GetDocentesByCurso(Curso curso)
        {
            List<DocenteCurso> docentesCursos = new List<DocenteCurso>();

            try
            {
                this.OpenConnection();

                SqlCommand cmdPersonas = new SqlCommand("select * from personas p inner join docentes_cursos dc on p.id_persona = dc.id_docente where id_curso=@id_curso", sqlConn);
                cmdPersonas.Parameters.Add("@id_curso", SqlDbType.Int).Value = curso.ID;
                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();

                while (drPersonas.Read())
                {
                    Persona per = new Persona();
                    DocenteCurso dictado = new DocenteCurso();
                    DocenteCurso DocCur = new DocenteCurso();

                    per.ID = (int)drPersonas["id_persona"];
                    per.Nombre = (string)drPersonas["nombre"];
                    per.Apellido = (string)drPersonas["apellido"];
                    per.Direccion = (string)drPersonas["direccion"];
                    per.Email = (string)drPersonas["email"];
                    per.Telefono = (string)drPersonas["telefono"];
                    per.FechaNacimiento = (DateTime)drPersonas["fecha_nac"];
                    per.Legajo = (int)drPersonas["legajo"];
                    per.IDPlan = (int)drPersonas["id_plan"];

                    if ((int)drPersonas["tipo_persona"] == 0)
                        per.TipoPersona = Persona.TiposPersonas.Alumno;
                    else
                        per.TipoPersona = Persona.TiposPersonas.Docente;

                    dictado.ID = (int)drPersonas["id_dictado"];
                    dictado.IdDocente = (int)drPersonas["id_docente"];
                    dictado.IdCurso = (int)drPersonas["id_curso"];
                    if ((int)drPersonas["cargo"] == 0)
                        dictado.Cargo = DocenteCurso.TiposCargo.Titular;
                    else
                        dictado.Cargo = DocenteCurso.TiposCargo.Ayudante;

                    DocCur.Docente = per;
                    DocCur.Dictado = dictado;

                    docentesCursos.Add(DocCur);
                }

                drPersonas.Close();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
               new Exception("Error al recuperar lista de docentes", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }

            return docentesCursos;
        }*/



    }
}
