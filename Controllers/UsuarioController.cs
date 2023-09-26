using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositorios.Interfaces;
using System.Runtime.CompilerServices;

namespace SistemaDeTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio; //atributo

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio) //construtor
        {
            _usuarioRepositorio = usuarioRepositorio;
        }


        //Método para buscar todos os usuários
        [HttpGet]
        public async Task<ActionResult<List<UsuarioModel>>> BuscarTodosUsuarios()//nome do nosso endpoint
        {
           List<UsuarioModel> usuarios = await _usuarioRepositorio.BuscarTodosUsuarios();
            return Ok(usuarios);
        }

        //Método para buscar um único usuário através do Id
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioModel>> BuscarPorId(int id)
        {
            UsuarioModel usuario = await _usuarioRepositorio.BuscarPorId(id);
            return Ok(usuario);
        }

        //Método para cadastrar um usuário no nosso banco
        [HttpPost]
        public async Task<ActionResult<UsuarioModel>> Cadastrar([FromBody] UsuarioModel usuarioModel)//nós vamos receber via body, ou seja, pelo corpo dessa requisição, uma UsuarioModel
        {
            UsuarioModel usuario = await _usuarioRepositorio.Adicionar(usuarioModel);
            return Ok(usuario);
        }


        //Método para atualizar um usuário no banco
        [HttpPut("{id}")]
        public async Task<ActionResult<UsuarioModel>> Ataulizar([FromBody] UsuarioModel usuarioModel, int id)
        {
            usuarioModel.Id = id;
            UsuarioModel usuario = await _usuarioRepositorio.Atualizar(usuarioModel, id);
            return Ok(usuario);
        }


        //Método para apagar um usuário do banco
        [HttpDelete("{id}")]
        public async Task<ActionResult<UsuarioModel>> Apagar(int id)
        {
            bool usuarioApagado = await _usuarioRepositorio.Apagar(id);
            return Ok(usuarioApagado);
        }
    }
}
