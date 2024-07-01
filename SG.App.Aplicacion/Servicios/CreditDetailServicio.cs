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
    public class CreditDetailServicio
    {
        readonly ICreditDetailRepositorio creditDetailRepositorio;
        public CreditDetailServicio()
        {
            creditDetailRepositorio = new CreditDetailRepositorioimpl();
        }

        public void InsertarCreditDetail(credits_details credits_details)
        {
            try
            {
                creditDetailRepositorio.Add(credits_details);
            }
            catch (Exception ex)
            {
                throw new Exception("Error Servicio: No se pudo insertar registro,", ex);
            }
        }
        public void ModificarCreditDetail(credits_details credits_details)
        {
            try
            {
                creditDetailRepositorio.Modify(credits_details);
            }
            catch (Exception ex)
            {
                throw new Exception("Error Servicio: No se pudo actualizar el registro,", ex);
            }
        }

        public void EliminarCreditDetail(int id)
        {
            try
            {
                creditDetailRepositorio.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error Servicio: No se pudo eliminar el registro,", ex);
            }
        }

        public IEnumerable<credits_details> listarCreditDetails()
        {
            try
            {
                return creditDetailRepositorio.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception("Error Servicio: No se pudo traer los registros,", ex);
            }
        }

        public credits_details buscarPorDescripcion(string descripcion)
        {
            try
            {
                return creditDetailRepositorio.buscarPorDescripcion(descripcion);
            }
            catch (Exception ex)
            {
                throw new Exception("Error. No se pudo encontrar la descripcion", ex);
            }
        }
    }
}
