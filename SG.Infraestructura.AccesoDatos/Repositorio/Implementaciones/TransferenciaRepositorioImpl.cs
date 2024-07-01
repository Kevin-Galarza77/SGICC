using SG.Dominio.Modelo.Abstracciones;
using SG.Dominio.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG.Infraestructura.AccesoDatos.Repositorio.Implementaciones
{
    public class TransferenciaRepositorioImpl : BaseRepositorioimpl<transfers>, ITransferenciaRepositorio
    {
        public IEnumerable<transfers> transferenciasPorFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                using (var context = new depositoEntities())
                {
                    var resultado = from transferencia in context.transfers
                                    where transferencia.transfer_date >= fechaInicio && transferencia.transfer_date <= fechaFin
                                    select transferencia;
                    return resultado.ToList<transfers>();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error Repositorio: No se pudo obtener los registros,", ex);
            }
        }
    }
}
