using SG.Dominio.Modelo.Abstracciones;
using SG.Dominio.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG.Infraestructura.AccesoDatos.Repositorio.Implementaciones
{
    public class CustomerRepositorioImpl : BaseRepositorioimpl<customer>, ICustomerRepositorio
    {
        public customer buscarPorNombre(string primerNombre)
        {
            try
            {
                using (var context = new depositoEntities())
                {
                    var resultado = from pasc in context.customer
                                    where pasc.customer_first_name == primerNombre
                                    select pasc;
                    return resultado.Single();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("EROR :  No se encontro el nombre", ex);

            }
        }
    }
}
