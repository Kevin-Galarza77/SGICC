using SG.Dominio.Modelo.Abstracciones;
using SG.Dominio.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG.Infraestructura.AccesoDatos.Repositorio.Implementaciones
{
    public class ProductoRepositorioimpl : BaseRepositorioimpl<products>, IProductoRepositorio
    {
        public IEnumerable<products> productosPorCategoria(int categoria_id)
        {
            try
            {

                using (var context = new depositoEntities())
                {
                    var resultado = from producto in context.products
                                    where producto.category_id == categoria_id
                                    select producto;
                    return resultado.ToList<products>();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error: No se pudo filtrar los registros,", ex);
            }

        }
    }
}
