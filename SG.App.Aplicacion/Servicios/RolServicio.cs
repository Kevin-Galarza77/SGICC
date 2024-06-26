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
    public class RolServicio
    {
        readonly IRolRepositorio rolRepositorio;

        public RolServicio()
        {
            rolRepositorio = new RolRepositorioImpl();
        }

        public void InsertarRol(roles roles)
        {
            try
            {
                rolRepositorio.Add(roles);
            }
            catch (Exception ex)
            {
                throw new Exception("Error Servicio: No se pudo insertar registro ROL,", ex);
            }
        }

        public void ModificarRol(roles rol)
        {
            try
            {
                rolRepositorio.Modify(rol);
            }
            catch (Exception ex)
            {
                throw new Exception("Error Servicio: No se pudo actualizar el registro ROL,", ex);
            }
        }

        public void EliminarRol(int id)
        {
            try
            {
                rolRepositorio.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error Servicio: No se pudo eliminar el registro ROL,", ex);
            }
        }

        public IEnumerable<roles> listarTodo()
        {
            try
            {
                return rolRepositorio.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception("Error Servicio: No se pudo traer los registros ROL,", ex);
            }
        }


    }

}
