using AdminService.BO;
using AdminService.Services;
using Dapper;
using System;
using System.Data;

namespace AdminService.BL
{
    public class TareaService : ITareasServices
    {
        private readonly IDbConnection _connection;
        public TareaService(IDbConnection connection)
        {
            _connection = connection;
        }

        public int AddTarea(Tareas tarea)
        {
            string sql = string.Format("INSERT INTO tbTareas (Descripcion,Completada) VALUES ('{0}',{1})", tarea.Descripcion, Convert.ToInt32(tarea.Completada));
            int regAf = _connection.Execute(sql, commandType: CommandType.Text);
            return regAf;
        }

        public bool DeleteTareas(int id)
        {
            string sql = string.Format("DELETE FROM tbTareas WHERE TareaId ={0}", id);
            int regAf = _connection.Execute(sql, commandType: CommandType.Text);
            return regAf > 0;
        }

        public List<Tareas> GetTareas()
        {
            string sql = "SELECT TareaId,Descripcion,Completada FROM tbTareas";
            List<Tareas> tareas = new List<Tareas>();
            tareas = _connection.Query<Tareas>(sql, null, commandType:CommandType.Text).ToList();
            return tareas;
        }

        public Tareas? GetTareasById(int id)
        {
            string sql = string.Format("SELECT TareaId,Descripcion,Completada FROM tbTareas WHERE TareaId = {0}", id);
            Tareas? tarea = _connection.Query<Tareas>(sql,null ,commandType: CommandType.Text)?.FirstOrDefault();
            return tarea;
        }

        public bool UpdateTarea(Tareas tarea)
        {
            string sql = string.Format("UPDATE tbTareas SET Descripcion = '{0}',Completada = {1}",tarea.Descripcion,Convert.ToInt32(tarea.Completada));
            int regAf = _connection.Execute( sql,null, commandType: CommandType.Text);
            return regAf > 0;
        }
    }
}
