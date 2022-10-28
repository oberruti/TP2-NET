using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class UsuarioLogic : BusinessLogic
    {
        private UsuarioAdapter _UsuarioData;

        public UsuarioAdapter UsuarioData { get => _UsuarioData; set => _UsuarioData = value; }

        public UsuarioLogic()
        {

            UsuarioData = new UsuarioAdapter();

        }

        public Usuario GetOne(int id) { return UsuarioData.GetOne(id); }

        public Usuario GetOne(string usuario) { return UsuarioData.GetOne(usuario); }

        public List<Usuario> GetAll() { return UsuarioData.GetAll(); }

        public void Save(Usuario u) { UsuarioData.Save(u); }

        public void Delete(int id) { UsuarioData.Delete(id); }

    }
}
