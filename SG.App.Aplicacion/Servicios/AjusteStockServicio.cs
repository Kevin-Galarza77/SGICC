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
    public class AjusteStockServicio
    {
        readonly IAjusteStockRepositorio ajusteStockRepositorio;
        public AjusteStockServicio()
        {
            ajusteStockRepositorio = new AjusteStockRepositorioimpl();
        }

        public void InsertarAjusteStock(stock_adjusts ajusteStock)
        {
            try
            {
                ajusteStockRepositorio.Add(ajusteStock);
            }
            catch (Exception ex)
            {
                throw new Exception("Error Servicio: No se pudo insertar registro,", ex);
            }
        }
        public void ModificarAjusteStock(stock_adjusts ajusteStock)
        {
            try
            {
                ajusteStockRepositorio.Modify(ajusteStock);
            }
            catch (Exception ex)
            {
                throw new Exception("Error Servicio: No se pudo actualizar el registro,", ex);
            }
        }

        public void EliminarAjusteStock(int id)
        {
            try
            {
                ajusteStockRepositorio.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error Servicio: No se pudo eliminar el registro,", ex);
            }
        }

        public IEnumerable<stock_adjusts> listarTodo()
        {
            try
            {
                return ajusteStockRepositorio.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception("Error Servicio: No se pudo traer los registros,", ex);
            }
        }
    }
}
