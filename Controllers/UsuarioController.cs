using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositórios.Interfaces;

namespace SistemaDeTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepositorio _iusuarioRepositorio;

        public UsuarioController(IUsuarioRepositorio iusuarioRepositorio)
        {
            _iusuarioRepositorio = iusuarioRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<UsuarioModel>>> BuscarTodosUsuarios() 
        {
            List<UsuarioModel> usuarios = await _iusuarioRepositorio.BuscarTodosUsuarios();    
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<UsuarioModel>>> BuscarPorId(int id)
        {
            UsuarioModel usuario = await _iusuarioRepositorio.BuscarPorId(id);
            return Ok(usuario);
        }

        [HttpPost]

        public async Task<ActionResult<UsuarioModel>> Cadastrar([FromBody] UsuarioModel usuarioModel)
        {
            UsuarioModel usuario = await _iusuarioRepositorio.Adicionar(usuarioModel);
            return Ok(usuario);
        }

        [HttpPut]

        public async Task<ActionResult<UsuarioModel>> Atualizar([FromBody] UsuarioModel usuarioModel, int id)
        {
            usuarioModel.Id = id;
            UsuarioModel usuario = await _iusuarioRepositorio.Atualizar(usuarioModel, id);
            return Ok(usuario);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<UsuarioModel>> Apagar(int id)
        {
           bool apagado = await _iusuarioRepositorio.Apagar(id);
            return Ok(apagado);
        }

    }
}
