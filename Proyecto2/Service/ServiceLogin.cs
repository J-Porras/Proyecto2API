using Proyecto2.DAOs;
using Proyecto2.Models;
using System.Collections.Generic;

namespace Proyecto2.Service
{
    public class ServiceLogin
    {
        private UsuarioDAO usuarioDao;

        public ServiceLogin()
        {
            usuarioDao = new UsuarioDAO();
        }

        public Usuario GetUsuarioById(string id) 
        {

            return usuarioDao.GetUsuarioById(id);
        }

        public List<Usuario> GetAllUsuarios()
        {
            return usuarioDao.GetAllUsuario();
        }




        public Usuario login(Usuario u)
        {
            Usuario result = null;// de la database
            result = usuarioDao.GetUsuarioById(u.Id);

            if(result == null || (!result.Contrasenna.Equals(u.Contrasenna)))
            {
                return null;
            }
            result.Contrasenna = "";
            return result;
        }
    }
}