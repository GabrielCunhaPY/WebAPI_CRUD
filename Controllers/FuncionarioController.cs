using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_Estudo.Models;
using WebAPI_Estudo.Service.FuncionarioService;

namespace WebAPI_Estudo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly IfuncionarioInterface _funcionarioInterface;
        public FuncionarioController(IfuncionarioInterface funcionarioInterface)
        {
            _funcionarioInterface = funcionarioInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServicesResponse<List<FuncionarioModel>>>> GetFuncionario()
        {

            return Ok(await _funcionarioInterface.GetFuncionario());

        }

        [HttpPost]

        public async Task<ActionResult<ServicesResponse<List<FuncionarioModel>>>> CreateFuncionario(FuncionarioModel novoFuncionario)
        {
            return Ok(await _funcionarioInterface.CreateFuncionario(novoFuncionario));
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<ServicesResponse<FuncionarioModel>>> GetFuncionarioByID(int id)
        {
            ServicesResponse<FuncionarioModel> servicesResponse = await _funcionarioInterface.GetFuncionarioByID(id);

            return Ok(servicesResponse);
        }

        public async Task<ActionResult<ServicesResponse<List<FuncionarioModel>>>> UpdateFuncionario(FuncionarioModel editadoFuncionario)
        {
            ServicesResponse<List<FuncionarioModel>> servicesResponse = await _funcionarioInterface.UpdateFuncionario(editadoFuncionario);

            return Ok(servicesResponse);

        }

        [HttpPut("InativaFuncionario")]

        public async Task<ActionResult<ServicesResponse<List<FuncionarioModel>>>> InativaFuncionario(int id)
        {
            ServicesResponse<List<FuncionarioModel>> servicesResponse = await _funcionarioInterface.InativaFuncionario(id);

            return Ok(servicesResponse);
        }



    }
}
