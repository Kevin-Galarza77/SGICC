using SG.Dominio.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG.Dominio.Modelo.Abstracciones
{
    public interface IProductoRepositorio: IBaseRepositorio <products>
    {
        IEnumerable<products> productosPorCategoria(int categoria_id);
    }
}
