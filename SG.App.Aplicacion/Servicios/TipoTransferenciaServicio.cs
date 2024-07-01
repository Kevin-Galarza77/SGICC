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
    public class TipoTransferenciaServicio
    {
        readonly ITiposTransferenciasRepositorio _tipoTransferenciaRepositorio;
        public TipoTransferenciaServicio()
        {
            _tipoTransferenciaRepositorio = new TiposTransferenciasRepositorioImpl();
        }

        public void InsertarTipoTransferencia(transfer_types tipoTransferencia)
        {
            try
            {
                _tipoTransferenciaRepositorio.Add(tipoTransferencia);
            }
            catch (Exception ex)
            {
                throw new Exception("Error Servicio: No se pudo insertar registro,", ex);
            }
        }
        public void ModificarTipoTransferencia(transfer_types tipoTransferencia)
        {
            try
            {
                _tipoTransferenciaRepositorio.Modify(tipoTransferencia);
            }
            catch (Exception ex)
            {
                throw new Exception("Error Servicio: No se pudo actualizar el registro,", ex);
            }
        }

        public void EliminarTipoTransferencia(int id)
        {
            try
            {
                _tipoTransferenciaRepositorio.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error Servicio: No se pudo eliminar el registro,", ex);
            }
        }

        public transfer_types buscarTipoTransferencia(int id)
        {
            try
            {
                return _tipoTransferenciaRepositorio.GetById(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error Servicio: No se pudo traer el registro,", ex);
            }
        }

        public IEnumerable<transfer_types> listarTipoTransferencias()
        {
            try
            {
                return _tipoTransferenciaRepositorio.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception("Error Servicio: No se pudo traer los registros,", ex);
            }
        }

        public IEnumerable<transfer_types> listarTipoTransferenciasPorEstado(bool estado)
        {
            try
            {
                return _tipoTransferenciaRepositorio.tiposTransferenciasPorEstado(estado);
            }
            catch (Exception ex)
            {
                throw new Exception("Error Servicio: No se pudo traer los registros,", ex);
            }
        }
    }
}
