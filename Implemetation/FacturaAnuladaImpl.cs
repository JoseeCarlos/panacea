using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Dao;
using System.Data;
using Oracle.DataAccess.Client;

namespace Implemetation
{
    public class FacturaAnuladaImpl : FacturaAnuladaDao
    {
        public int delete(FacturaAnulada t)
        {
            throw new NotImplementedException();
        }

        public int insert(FacturaAnulada t)
        {
            throw new NotImplementedException();
        }

        public void insertFactura(FacturaAnulada fac,List<Productos> productos)
        {
            string queryDosificacion = @"UPDATE VENTAFACTURA SET razonSocial='Anulado', total=0, estado='A' , fechaactualizacion=CURRENT_TIMESTAMP
                                         WHERE idventafactura=:idventafactura";

            string queryInsert = @"INSERT INTO FacturaAnulada(idVentaFactura,motivo)
                                    VALUES(:idVentaFactura,:motivo)";

            string quertUpdate = @"UPDATE PRODUCTO SET STOCK=STOCK+:STOCK, FECHAACTUALIZACION=CURRENT_TIMESTAMP, IDUSUARIO=:IDUSUARIO
                                    WHERE IDPRODUCTO=:IDPRODUCTO";

            try
            {

                List<OracleCommand> cmds = DBImplementation2.CreateNBasicCommand(2+(productos.Count));

                int num = 2;


                cmds[0].CommandText = queryDosificacion;
                cmds[0].Parameters.Add(":idventafactura", fac.IdVentaFactura);

                cmds[1].CommandText = queryInsert;
                cmds[1].Parameters.Add(":idVentaFactura", fac.IdVentaFactura);
                cmds[1].Parameters.Add(":motivo", fac.Motivo);

                foreach (var item in productos)
                {
                    cmds[num].CommandText = quertUpdate;
                    cmds[num].Parameters.Add(":STOCK", item.Cantidad);
                    cmds[num].Parameters.Add(":IDUSUARIO", Session.SessionId);
                    cmds[num].Parameters.Add(":IDPRODUCTO", item.IdProducto);
                    num++;
                }
                

                DBImplementation2.ExecuteNBasicCommand(cmds);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataTable select()
        {
            throw new NotImplementedException();
        }

        public int update(FacturaAnulada t)
        {
            throw new NotImplementedException();
        }
    }
}
