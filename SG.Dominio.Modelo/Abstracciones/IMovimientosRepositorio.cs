using SG.Dominio.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG.Dominio.Modelo.Abstracciones
{
    public interface IMovimientosRepositorio : IBaseRepositorio<stock_moves>
    {
        IEnumerable<stock_moves> movimientosPorTransferencia(int idTransferencia);
    }
}
