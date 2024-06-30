using SG.Dominio.Modelo.Abstracciones;
using SG.Dominio.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG.Infraestructura.AccesoDatos.Repositorio.Implementaciones
{
    public class CategoriaRepositorioimpl : BaseRepositorioimpl<categories>, ICategoriaRepositorio
    {
        public IEnumerable<categories> categoriasPorEstado(Boolean estado)
        {
            try
            {

                using (var context = new depositoEntities())
                {
                    var resultado = from categoria in context.categories
                                    where categoria.category_state == estado
                                    select categoria;
                    return resultado.ToList<categories>();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error: No se pudo filtrar los registros,", ex);
            }

        }
    }
}
