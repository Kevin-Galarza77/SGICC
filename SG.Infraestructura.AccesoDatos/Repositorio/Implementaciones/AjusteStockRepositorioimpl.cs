using SG.Dominio.Modelo.Abstracciones;
using SG.Dominio.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG.Infraestructura.AccesoDatos.Repositorio.Implementaciones
{
    public class AjusteStockRepositorioimpl : BaseRepositorioimpl<stock_adjusts>, IAjusteStockRepositorio
    {
        public IEnumerable<stock_adjusts> ajustesPorProducto(int product_id)
        {
            try
            {

                using (var context = new depositoEntities())
                {
                    var resultado = from ajuste in context.stock_adjusts
                                    where ajuste.product_id == product_id
                                    select ajuste;
                    return resultado.ToList<stock_adjusts>();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error: No se pudo filtrar los registros,", ex);
            }
        }

    }
}
