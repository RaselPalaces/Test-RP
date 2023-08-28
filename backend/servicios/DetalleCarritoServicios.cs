using System.Data;
using backend.connection;
using backend.entidades;
using Dapper;

namespace backend.servicios
{
    public static class DetalleCarritoServicios
    {
        public static IEnumerable<T> ObtenerTodo<T>()
        {
            const string sql = "select top 5 * from DETALLE_CARRITO";
            return BDManager.GetInstance.GetData<T>(sql);//Dapper
        }

        public static T ObtenerById<T>(int id)
        {
            const string sql = "select * from DETALLE_CARRITO where ID = @Id and estado_registro = 1";

            var parameters = new DynamicParameters();
            parameters.Add("id", id, DbType.Int64);

            var result = BDManager.GetInstance.GetDataWithParameters<T>(sql, parameters);

            return result.FirstOrDefault();
        }

        public static int InsertDetalleCarrito(DetalleCarrito detalleCarrito)
        {
            const string sql = "INSERT INTO [dbo].[DETALLE_CARRITO]([CANTIDAD], [ID_PRODUCTO], [ID_CARRITO_COMPRA]) VALUES (@cantidad, @id_producto, @id_carrito_compra)";

            var parameters = new DynamicParameters();
            parameters.Add("cantidad", detalleCarrito.Cantidad, DbType.Int64);
            parameters.Add("id_producto", detalleCarrito.IdProducto, DbType.Int64);
            parameters.Add("id_carrito_compra", detalleCarrito.IdCarritoCompra, DbType.Int64);

            var result = BDManager.GetInstance.SetData(sql, parameters);
            return result;
        }
        public static int UpdateDetalleCarrito(DetalleCarrito detalleCarrito)
        {
            const string sql = "UPDATE [DETALLE_CARRITO] SET [CANTIDAD] = @cantidad, [ID_PRODUCTO] = @id_producto, [ID_CARRITO_COMPRA] = @id_carrito_compra WHERE [ID] = @id";
            
            var parameter = new DynamicParameters();
            parameter.Add("id", detalleCarrito.Id, DbType.Int32);
            parameter.Add("cantidad", detalleCarrito.Cantidad, DbType.Int32);
            parameter.Add("id_producto", detalleCarrito.IdProducto, DbType.Int32);
            parameter.Add("id_carrito_compra", detalleCarrito.IdCarritoCompra, DbType.Int32);
            
            var result = BDManager.GetInstance.SetData(sql, parameter);
            return result;
        }

        public static int DeleteDetalleCarrito(int id)
        {
            const string sql = "DELETE FROM [DETALLE_CARRITO] WHERE [ID] = @id";
            
            var parameter = new DynamicParameters();
            parameter.Add("id", id, DbType.Int32);
            
            var result = BDManager.GetInstance.SetData(sql, parameter);
            return result;
        }

    }
}