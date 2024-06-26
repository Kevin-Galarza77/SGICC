using SG.Dominio.Modelo.Abstracciones;
using SG.Dominio.Modelo.Entidades;
using SG.Infraestructura.AccesoDatos.Repositorio.Implementaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG.App.Aplicacion.Servicios
{
    public class UsuarioServicio 
    {
        readonly IUsuariosRepositorio usuariosRepositorio;

        public UsuarioServicio()
        {
            usuariosRepositorio = new UsuarioRepositorioImpl();
                
        }

        public void InsertarUsuario(users users)
        {
            try
            {
                usuariosRepositorio.Add(users);
            }
            catch (Exception ex)
            {

                throw new Exception("Error Servicio: No se pudo insertar registro USUARIO,", ex);
            }
        }


        public void ModificarUsuario(users users)
        {
            try
            {
                usuariosRepositorio.Modify(users);
            }
            catch (Exception ex)
            {
                throw new Exception("Error Servicio: No se pudo actualizar el registro USUARIO,", ex);
            }
        }

        public void EliminarUsuario(int id)
        {
            try
            {
                usuariosRepositorio.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error Servicio: No se pudo eliminar el registro USUARIO,", ex);
            }
        }

        public IEnumerable<users> listarTodo()
        {
            try
            {
                return usuariosRepositorio.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception("Error Servicio: No se pudo traer los registros USUARIO,", ex);
            }
        }

    }
}
