using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositorios.Interfaces;

namespace SistemaDeTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaRepositorio _tarefaRepositorio; //atributo

        public TarefaController(ITarefaRepositorio tarefaRepositorio)//construtor
        {
            _tarefaRepositorio = tarefaRepositorio;
        }

        //Método para listar todas as tarefas
        [HttpGet]
        public async Task<ActionResult<List<TarefaModel>>> ListarTodasTarefas()
        {
            List<TarefaModel> tarefas = await _tarefaRepositorio.BuscarTodasTarefas();
            return Ok(tarefas);
        }

        //Método para buscar uma tarefa por um Id
        [HttpGet("{id}")]
        public async Task<ActionResult<TarefaModel>> BuscarTarefaPorId(int id)
        {
            TarefaModel tarefa = await _tarefaRepositorio.BuscarPorId(id);
            return Ok(tarefa);
        }

        //Método para cadastarar uma tarefa
        [HttpPost]
        public async Task<ActionResult<TarefaModel>> Cadastrar([FromBody] TarefaModel tarefaModel)
        {
            TarefaModel tarefa = await _tarefaRepositorio.Adicionar(tarefaModel);
            return Ok(tarefa);
        }

        //Método para ataulizar uma tarefa
        [HttpPut("{id}")]
        public async Task<ActionResult<TarefaModel>> Atualizar([FromBody] TarefaModel tarefaModel, int id)
        {
            tarefaModel.Id = id;
            TarefaModel tarefa = await _tarefaRepositorio.Atualizar(tarefaModel, id);
            return Ok(tarefa);
        }


        //Método para apagar uma tarefa
        [HttpDelete("{id}")]
        public async Task<ActionResult<TarefaModel>> ApagarTarefa(int id)
        {
            bool tarefaApagada = await _tarefaRepositorio.Apagar(id);
            return Ok(tarefaApagada);
        }
    }
}
