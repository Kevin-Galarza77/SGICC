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
    public class MovimientosServicio
    {
        readonly IMovimientosRepositorio _movimientoRepositorio;
        public MovimientosServicio()
        {
            _movimientoRepositorio = new MovimientosRepositorioImpl();
        }

        public void InsertarMovimiento(stock_moves stockMove)
        {
            try
            {
                _movimientoRepositorio.Add(stockMove);
            }
            catch (Exception ex)
            {
                throw new Exception("Error Servicio: No se pudo insertar registro,", ex);
            }
        }
        public void ModificarMovimiento(stock_moves stockMove)
        {
            try
            {
                _movimientoRepositorio.Modify(stockMove);
            }
            catch (Exception ex)
            {
                throw new Exception("Error Servicio: No se pudo actualizar el registro,", ex);
            }
        }

        public void EliminarMovimiento(int id)
        {
            try
            {
                _movimientoRepositorio.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error Servicio: No se pudo eliminar el registro,", ex);
            }
        }

        public stock_moves buscarMovimiento(int id)
        {
            try
            {
                return _movimientoRepositorio.GetById(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error Servicio: No se pudo encontrar el registro,", ex);
            }
        }

        public IEnumerable<stock_moves> listarMovimientos()
        {
            try
            {
                return _movimientoRepositorio.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception("Error Servicio: No se pudo traer los registros,", ex);
            }
        }
    }
}
