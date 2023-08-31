using System.Data;
using backend.connection;
using backend.entidades;
using Dapper;

namespace backend.servicios
{
    public static class OrdenReparacionServicios
    {
        public static IEnumerable<T> ObtenerTodo<T>()
        {
            const string sql = "select top 5 * from ORDEN_REPARACION order by id desc";
            return BDManager.GetInstance.GetData<T>(sql);//Dapper
        }

        public static T ObtenerById<T>(int id)
        {
            const string sql = "select * from ORDEN_REPARACION where ID = @Id and estado_registro = 1";

            var parameters = new DynamicParameters();
            parameters.Add("id", id, DbType.Int64);

            var result = BDManager.GetInstance.GetDataWithParameters<T>(sql, parameters);

            return result.FirstOrDefault();
        }

        public static int InsertOrdenReparacion(OrdenReparacion ordenReparacion)
        {
            const string sql = "INSERT INTO [dbo].[ORDEN_REPARACION]([NUMERO_ORDEN], [COSTO_ESTIMADO], [ID_EQUIPO_MEDICO], [ID_USUARIO]) VALUES (@numero_orden, @costo_estimado, @id_equipo_medico, @id_usuario)";

            var parameters = new DynamicParameters();
            parameters.Add("numero_orden", ordenReparacion.NumeroOrden, DbType.String);
            parameters.Add("costo_estimado", ordenReparacion.CostoEstimado, DbType.String);
            parameters.Add("id_equipo_medico", ordenReparacion.IdEquipoMedico, DbType.Int64);
            parameters.Add("id_usuario", ordenReparacion.IdUsuario, DbType.Int64);

            var result = BDManager.GetInstance.SetData(sql, parameters);
            return result;
        }
        public static int UpdateOrdenReparacion(OrdenReparacion ordenReparacion)
        {
            const string sql = "UPDATE [ORDE_REPARACION] SET [NUMERO_ORDEN] = @numero_orden, [COSTO_ESTIMADO] = @costo_estimado, [ID_EQUIPO_MEDICO] = @id_equipo_medico, [ID_USUARIO] = @id_usuario WHERE [ID] = @id";
            
            var parameter = new DynamicParameters();
            parameter.Add("id", ordenReparacion.Id, DbType.Int32);
            parameter.Add("numero_orden", ordenReparacion.NumeroOrden, DbType.String);
            parameter.Add("costo_estimado", ordenReparacion.CostoEstimado, DbType.String);
            parameter.Add("id_equipo_medico", ordenReparacion.IdEquipoMedico, DbType.Int64);
            parameter.Add("id_usuario", ordenReparacion.IdUsuario, DbType.Int64);
            
            var result = BDManager.GetInstance.SetData(sql, parameter);
            return result;
        }

        public static int DeleteOrdenReparacion(int id)
        {
            const string sql = "DELETE FROM [ORDEN_REPARACION] WHERE [ID] = @id";
            
            var parameter = new DynamicParameters();
            parameter.Add("id", id, DbType.Int32);
            
            var result = BDManager.GetInstance.SetData(sql, parameter);
            return result;
        } 

    }
}