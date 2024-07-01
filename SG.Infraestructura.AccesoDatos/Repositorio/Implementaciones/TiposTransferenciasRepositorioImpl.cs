using SG.Dominio.Modelo.Abstracciones;
using SG.Dominio.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG.Infraestructura.AccesoDatos.Repositorio.Implementaciones
{
    public class TiposTransferenciasRepositorioImpl : BaseRepositorioimpl<transfer_types>, ITiposTransferenciasRepositorio
    {
        public IEnumerable<transfer_types> tiposTransferenciasPorEstado(bool estado)
        {
            try
            {

                using (var context = new depositoEntities())
                {
                    var resultado = from tipoTransferencia in context.transfer_types
                                    where tipoTransferencia.TRANSFER_TYPE_STATE == estado
                                    select tipoTransferencia;
                    return resultado.ToList<transfer_types>();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error IMPLEMENTACIÓN: No se pudo filtrar los registros de tipo de Transferencias,", ex);
            }
        }
    }
}
