using AdminService.BO;

namespace AdminService.Services
{
    public interface ITareasServices
    {
        List<Tareas> GetTareas();
        int AddTarea(Tareas tarea);
        bool UpdateTarea(Tareas tarea);
        bool DeleteTareas(int id);
        Tareas? GetTareasById(int id);
    }
}
