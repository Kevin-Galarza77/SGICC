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
    public class ProductoServicio
    {
        readonly IProductoRepositorio productoRepositorio;
        public ProductoServicio()
        {
            productoRepositorio = new ProductoRepositorioimpl();
        }

        public void InsertarProducto(products producto)
        {
            try
            {
                productoRepositorio.Add(producto);
            }
            catch (Exception ex)
            {
                throw new Exception("Error Servicio: No se pudo insertar registro,", ex);
            }
        }
        public void ModificarProducto(products producto)
        {
            try
            {
                productoRepositorio.Modify(producto);
            }
            catch (Exception ex)
            {
                throw new Exception("Error Servicio: No se pudo actualizar el registro,", ex);
            }
        }

        public void EliminarProducto(int id)
        {
            try
            {
                productoRepositorio.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error Servicio: No se pudo eliminar el registro,", ex);
            }
        }

        public IEnumerable<products> listarProductos()
        {
            try
            {
                return productoRepositorio.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception("Error Servicio: No se pudo traer los registros,", ex);
            }
        }
    }
}
