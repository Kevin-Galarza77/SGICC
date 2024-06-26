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
    public class CreditServicio
    {
        readonly ICreditRepositorio creditServicio;

        public CreditServicio()
        {
            creditServicio = new CreditRepositorioImpl();
        }

        public void InsertarCredit(credit credit)
        {
            try
            {
                creditServicio.Add(credit);
            }
            catch (Exception ex)
            {

                throw new Exception("Error Servicio: No se pudo insertar registro CREDIT,", ex);
            }
        }

        public void ModificarCredit(credit credit)
        {
            try
            {
                creditServicio.Modify(credit);
            }
            catch (Exception ex)
            {
                throw new Exception("Error Servicio: No se pudo actualizar el registro CREDIT,", ex);
            }
        }

        public void EliminarCredit(int id)
        {
            try
            {
                creditServicio.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error Servicio: No se pudo eliminar el registro CREDIT,", ex);
            }
        }

        public IEnumerable<credit> listarTodo()
        {
            try
            {
                return creditServicio.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception("Error Servicio: No se pudo traer los registros CREDIT,", ex);
            }
        }
    }
}

