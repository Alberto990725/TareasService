using AdminService.BO;
using AdminService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdminService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareasController : ControllerBase
    {

        private readonly ITareasServices _services;

        public TareasController(ITareasServices tareasServices) { 
            
            _services = tareasServices;
        }

        [HttpGet("tareas")]
        public ActionResult<Tareas> getTareas()
        {
            try
            {
                return Ok(_services.GetTareas());
            }catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("tareas")]
        public ActionResult<int> addTarea(Tareas tarea) {

            try
            {
                return Ok(_services.AddTarea(tarea));
            }catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("tareas/{id}")]
        public ActionResult<bool> updateTarea(int id)
        {
            try
            {
                Tareas? tarea = _services.GetTareasById(id);
                if (tarea != null)
                {
                    bool active = tarea.Completada ? false : true;
                    tarea.Completada = active;

                    return Ok(_services.UpdateTarea(tarea));
                }
                else
                {
                    return BadRequest(new { Message = "Tarea No encontrada" }) ;
                }
                
            }catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("tareas/{id}")]
        public ActionResult<bool> deleteTareas(int id)
        {
            try
            {
                return Ok(_services.DeleteTareas(id));
            }catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
