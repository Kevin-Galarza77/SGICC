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
    public class TransferenciaServicio
    {
        readonly ITransferenciaRepositorio _transferenciaRepositorio;
        public TransferenciaServicio()
        {
            _transferenciaRepositorio = new TransferenciaRepositorioImpl();
        }

        public void InsertarTransferencia(transfers transferencia)
        {
            try
            {
                _transferenciaRepositorio.Add(transferencia);
            }
            catch (Exception ex)
            {
                throw new Exception("Error Servicio: No se pudo insertar registro,", ex);
            }
        }
        public void ModificarTransferencia(transfers transferencia)
        {
            try
            {
                _transferenciaRepositorio.Modify(transferencia);
            }
            catch (Exception ex)
            {
                throw new Exception("Error Servicio: No se pudo actualizar el registro,", ex);
            }
        }

        public void EliminarTransferencia(int id)
        {
            try
            {
                _transferenciaRepositorio.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error Servicio: No se pudo eliminar el registro,", ex);
            }
        }

        public transfers buscarTransferencia(int id)
        {
            try
            {
                return _transferenciaRepositorio.GetById(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error Servicio: No se pudo traer el registro,", ex);
            }
        }

        public IEnumerable<transfers> listarTransferencias()
        {
            try
            {
                return _transferenciaRepositorio.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception("Error Servicio: No se pudo traer los registros,", ex);
            }
        }
    }
}
