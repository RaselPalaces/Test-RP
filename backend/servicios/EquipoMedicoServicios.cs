using System.Data;
using backend.connection;
using backend.entidades;
using Dapper;

namespace backend.servicios
{
    public static class EquipoMedicoServicios
    {
        public static IEnumerable<T> ObtenerTodo<T>()
        {
            const string sql = "select top 5 * from EQUIPO_MEDICO order by id desc";
            return BDManager.GetInstance.GetData<T>(sql);//Dapper
        }

        public static T ObtenerById<T>(int id)
        {
            const string sql = "select * from equipo_medico where ID = @Id and estado_registro = 1";

            var parameters = new DynamicParameters();
            parameters.Add("id", id, DbType.Int64);

            var result = BDManager.GetInstance.GetDataWithParameters<T>(sql, parameters);

            return result.FirstOrDefault();
        }

        public static int InsertEquipoMedico(EquipoMedico equipoMedico)
        {
            const string sql = "INSERT INTO [dbo].[EQUIPO_MEDICO]([NOMBRE_EQUIPO], [DESCRIPCION_PROBLEMA], [ESTADO_REPARACION]) VALUES (@nombre_equipo, @descripcion_problema, @estado_reparacion) ";

            var parameters = new DynamicParameters();
            parameters.Add("nombre_equipo", equipoMedico.NombreEquipo, DbType.String);
            parameters.Add("descripcion_problema", equipoMedico.DescripcionProblema, DbType.String);
            parameters.Add("estado_reparacion", equipoMedico.EstadoReparacion, DbType.String);

            var result = BDManager.GetInstance.SetData(sql, parameters);
            return result;
        }

        public static int UpdateEquipoMedico(EquipoMedico equipoMedico)
        {
            const string sql = "UPDATE [dbo].[EQUIPO_MEDICO] SET [NOMBRE_EQUIPO] = @nombre_equipo, [DESCRIPCION_PROBLEMA] = @descripcion_problema, [ESTADO_REPARACION] = @estado_reparacion WHERE [ID] = @id";
            
            var parameter = new DynamicParameters();
            parameter.Add("id", equipoMedico.Id, DbType.Int32);
            parameter.Add("nombre_equipo", equipoMedico.NombreEquipo, DbType.String);
            parameter.Add("descripcion_problema", equipoMedico.DescripcionProblema, DbType.String);
            parameter.Add("estado_reparacion", equipoMedico.EstadoReparacion, DbType.String);
            
            var result = BDManager.GetInstance.SetData(sql, parameter);
            return result;
        }

        public static int DeleteEquipoMedico(int id)
        {
            const string sql = "DELETE FROM [dbo].[EQUIPO_MEDICO] WHERE [ID] = @id";
            
            var parameter = new DynamicParameters();
            parameter.Add("id", id, DbType.Int32);
            
            var result = BDManager.GetInstance.SetData(sql, parameter);
            return result;
        }   

    }
}