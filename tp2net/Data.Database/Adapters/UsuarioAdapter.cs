using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class UsuarioAdapter : Adapter
    {

        public List<Usuario> GetAll()
        {

            List<Usuario> usuarios = new List<Usuario>();

            try
            {
                this.OpenConnection();

                SqlCommand cmdUsuarios = new SqlCommand("select * from usuarios", SqlConn);

                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();

                while (drUsuarios.Read())
                {
                    Usuario usr = new Usuario();

                    usr.ID = (int)drUsuarios["id_usuario"];
                    usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    usr.Nombre = (string)drUsuarios["nombre"];
                    usr.Apellido = (string)drUsuarios["apellido"];
                    usr.Habilitado = (bool)drUsuarios["habilitado"];
                    usr.Email = (string)drUsuarios["email"];
                    usr.Clave = (string)drUsuarios["clave"];


                    usuarios.Add(usr);
                }

                drUsuarios.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al recuperar lista de usuarios", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return usuarios;
        }

        public Business.Entities.Usuario GetOne(int ID)
        {
            Usuario user = new Usuario();

            try
            {
                this.OpenConnection();

                SqlCommand cmdUsuarios = new SqlCommand("select * from usuarios where id_usuario=@id", SqlConn);
                cmdUsuarios.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();

                if (drUsuarios.Read())
                {
                    user.ID = (int)drUsuarios["id_usuario"];
                    user.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    user.Nombre = (string)drUsuarios["nombre"];
                    user.Apellido = (string)drUsuarios["apellido"];
                    user.Habilitado = (bool)drUsuarios["habilitado"];
                    user.Email = (string)drUsuarios["email"];
                    user.Clave = (string)drUsuarios["clave"];
                }
                drUsuarios.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
               new Exception("Error al recuperar lista de usuarios", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return user;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete = new SqlCommand("delete usuarios where id_usuario=@id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Update(Usuario usuario)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave = new SqlCommand("UPDATE usuarios set nombre_usuario=@nombre_usuario, clave=@clave, habilitado=@habilitado, nombre=@nombre, apellido=@apellido, email=@email WHERE id_usuario=@id", SqlConn);

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = usuario.ID;
                cmdSave.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;
                cmdSave.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = usuario.Clave;
                cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = usuario.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = usuario.Apellido;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = usuario.Email;

                cmdSave.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de usuario", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        protected void Insert(Usuario usuario)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave = new SqlCommand("INSERT INTO usuarios (nombre_usuario, clave, habilitado, nombre, apellido, email) VALUES (@nombre_usuario, @clave, @habilitado, @nombre, @apellido, @email) select @@identity", SqlConn);

                cmdSave.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;
                cmdSave.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = usuario.Clave;
                cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = usuario.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = usuario.Apellido;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = usuario.Email;

                usuario.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear usuario", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Usuario usuario)
        {

            if (usuario.State == BusinessEntity.States.Deleted)
            {
                this.Delete(usuario.ID);
            }
            else if (usuario.State == BusinessEntity.States.New)
            {
                this.Insert(usuario);
            }
            else if (usuario.State == BusinessEntity.States.Modified)
            {
                this.Update(usuario);
            }
            usuario.State = BusinessEntity.States.Unmodified;
        }

        public Business.Entities.Usuario GetOne(string usuario)
        {
            Usuario user = new Usuario();

            try
            {
                this.OpenConnection();

                SqlCommand cmdUsuarios = new SqlCommand("select * from usuarios where nombre_usuario=@usuario", SqlConn);
                cmdUsuarios.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario;
                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();

                if (drUsuarios.Read())
                {
                    user.ID = (int)drUsuarios["id_usuario"];
                    user.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    user.Nombre = (string)drUsuarios["nombre"];
                    user.Apellido = (string)drUsuarios["apellido"];
                    user.Habilitado = (bool)drUsuarios["habilitado"];
                    user.Email = (string)drUsuarios["email"];
                    user.Clave = (string)drUsuarios["clave"];
                }
                drUsuarios.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
               new Exception("Error al recuperar lista de usuarios", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return user;
        }

        public bool ValidarUser(string username, string pass)
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

        public Usuario GetOneByNombreUsuario(string username)
        {
            Usuario user = new Usuario();
            try
            {
                this.OpenConnection();

                SqlCommand cmdUsuarios = new SqlCommand("select * from usuarios where nombre_usuario = @nombre_usuario", SqlConn);
                cmdUsuarios.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = username;
                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();

                if (drUsuarios.Read())
                {
                    user.ID = (int)drUsuarios["id_usuario"];
                    user.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    user.Nombre = (string)drUsuarios["nombre"];
                    user.Apellido = (string)drUsuarios["apellido"];
                    user.Habilitado = (bool)drUsuarios["habilitado"];
                    user.Email = (string)drUsuarios["email"];
                    user.Clave = (string)drUsuarios["clave"];
                }
                drUsuarios.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return user;
        }

        public int BuscarTipoPersona(int id)
        {
            Usuario user = new Usuario();
            PersonaAdapter perAdap = new PersonaAdapter();
            Persona per = new Persona();
            int tipoUsuario = 0;

            try
            {
                this.OpenConnection();

                SqlCommand cmdUsuarios = new SqlCommand("select * from usuarios usu " +
                    "inner join personas per on per.id_persona = usu.id_persona " +
                    " where usu.id_usuario = @id", SqlConn);
                cmdUsuarios.Parameters.Add("@id", SqlDbType.Int).Value = id;
                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();

                if (drUsuarios.Read())
                {
                    tipoUsuario = (int)drUsuarios["tipo_persona"];
                    /*if (!String.IsNullOrEmpty(drUsuarios["id_persona"].ToString()))
                    {
                        tipoUsuario = (int)perAdap.GetOne((int)drUsuarios["id_persona"]).TipoPersona;
                    }*/
                }
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
               new Exception("Error al recuperar lista de usuarios", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return tipoUsuario;
        }
    }
}
