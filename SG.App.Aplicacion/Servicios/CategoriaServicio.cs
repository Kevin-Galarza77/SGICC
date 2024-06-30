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
    public class CategoriaServicio
    {
        readonly ICategoriaRepositorio categoriaRepositorio;
        public CategoriaServicio()
        {
            categoriaRepositorio = new CategoriaRepositorioimpl();
        }

        public void InsertarCategoria(categories categoria)
        {
            try
            {
                categoriaRepositorio.Add(categoria);
            }
            catch (Exception ex)
            {
                throw new Exception("Error Servicio: No se pudo insertar registro,", ex);
            }
        }
        public void ModificarCategoria(categories categoria)
        {
            try
            {
                categoriaRepositorio.Modify(categoria);
            }
            catch (Exception ex)
            {
                throw new Exception("Error Servicio: No se pudo actualizar el registro,", ex);
            }
        }

        public void EliminarCategoria(int id)
        {
            try
            {
                categoriaRepositorio.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error Servicio: No se pudo eliminar el registro,", ex);
            }
        }

        public IEnumerable<categories> listarTodo()
        {
            try
            {
                return categoriaRepositorio.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception("Error Servicio: No se pudo traer los registros,", ex);
            }
        }

        public IEnumerable<categories> categoriasPorEstado(Boolean estado)
        {
            try
            {
                return categoriaRepositorio.categoriasPorEstado(estado);
            }
            catch (Exception ex)
            {
                throw new Exception("Error Servicio: No se pudo traer los registros,", ex);
            }
        }
    }
}
