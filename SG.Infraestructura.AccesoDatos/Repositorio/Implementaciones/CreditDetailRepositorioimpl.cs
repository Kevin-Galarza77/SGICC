using SG.Dominio.Modelo.Abstracciones;
using SG.Dominio.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG.Infraestructura.AccesoDatos.Repositorio.Implementaciones
{
    public class CreditDetailRepositorioimpl : BaseRepositorioimpl<credits_details>, ICreditDetailRepositorio
    {
        public credits_details buscarPorDescripcion(string descripcion)
        {
            try
            {
                using (var context = new depositoEntities())
                {
                    var resultado = from pasc in context.credits_details
                                    where pasc.credit_detail_description == descripcion
                                    select pasc;
                    return resultado.Single();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("EROR :  No se encontro la descripcion del cedito", ex);

            }
        }
    }
}
