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
    public class CustomerServicio
    {
        readonly ICustomerRepositorio customerRepositorio;
        public CustomerServicio()
        {
            customerRepositorio = new CustomerRepositorioImpl();
        }

        public void InsertarCustomer(customer customer)
        {
            try
            {
                customerRepositorio.Add(customer);
            }
            catch (Exception ex)
            {
                throw new Exception("Error Servicio: No se pudo insertar registro,", ex);
            }
        }
        public void ModificarCustomer(customer customer)
        {
            try
            {
                customerRepositorio.Modify(customer);
            }
            catch (Exception ex)
            {
                throw new Exception("Error Servicio: No se pudo actualizar el registro,", ex);
            }
        }

        public void EliminarCustomer(int id)
        {
            try
            {
                customerRepositorio.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error Servicio: No se pudo eliminar el registro,", ex);
            }
        }

        public IEnumerable<customer> listarCustomers()
        {
            try
            {
                return customerRepositorio.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception("Error Servicio: No se pudo traer los registros,", ex);
            }
        }
    }
}
