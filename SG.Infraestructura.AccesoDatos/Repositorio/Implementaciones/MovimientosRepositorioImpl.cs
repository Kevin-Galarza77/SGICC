using SG.Dominio.Modelo.Abstracciones;
using SG.Dominio.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG.Infraestructura.AccesoDatos.Repositorio.Implementaciones
{
    public class MovimientosRepositorioImpl : BaseRepositorioimpl<stock_moves>, IMovimientosRepositorio
    {
        public IEnumerable<stock_moves> movimientosPorTransferencia(int idTransferencia)
        {
            try
            {
                using (var context = new depositoEntities())
                {
                    var resultado = from movimiento in context.stock_moves
                                    where movimiento.transfer_id == idTransferencia
                                    select movimiento;
                    return resultado.ToList<stock_moves>();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error IMPLEMENTACIÓN: No se pudo filtrar los registros de movimientos,", ex);
            }
        }
    }
}
