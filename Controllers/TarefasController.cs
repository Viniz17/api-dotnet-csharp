using System.Xml.Schema;
using ApiTarefas.Dto;
using ApiTarefas.Errors;
using ApiTarefas.ModelViews;
using ApiTarefas.Services;
using ApiTarefas.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiTarefas.Controllers
{
    [ApiController]
    [Route("/tarefas")]
    public class TarefasController : ControllerBase
    {
        public TarefasController(ITarefaService service)
        {
            _service = service;
        }

        private ITarefaService _service;

        [HttpGet]
        public IActionResult Index()
        {
            var tasks = _service.Lista();
            return StatusCode(200, tasks);
        }

        [HttpPost]
        public IActionResult Create([FromBody] TarefaDto taskDto)
        {
            try
            {
                var task = _service.Incluir(taskDto);
                return StatusCode(201, task);
            }
            catch(TarefaError error)
            {
                return StatusCode(400, new ErrorView { Message = error.Message });
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] TarefaDto taskDto)
        {
           try
            {
                var taskDb = _service.Update(id, taskDto);
                return StatusCode(200, taskDb);
            }
            catch(TarefaError error)
            {
                return StatusCode(400, new ErrorView { Message = error.Message });
            }
        }

        [HttpGet("{id}")]
        public IActionResult Show([FromRoute] int id)
        {
            try
            {
                var taskDb = _service.BuscaPorId(id);
                return StatusCode(200, taskDb);
            }
            catch(TarefaError error)
            {
                return StatusCode(400, new ErrorView { Message = error.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            try{
                _service.Delete(id);
                return StatusCode(204);
            }
            catch(TarefaError error){
                return StatusCode(400, new ErrorView { Message = error.Message });
            }
        }
    }
}
