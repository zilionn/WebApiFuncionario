using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WEBAPI_Funcionario.Models;
using WEBAPI_Funcionario.Service.FuncionarioService;

namespace WEBAPI_Funcionario.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase {
        private readonly IFuncionarioInterface _funcionarioInterface;
        
        public FuncionarioController(IFuncionarioInterface funcionarioInterface) {
            _funcionarioInterface = funcionarioInterface;
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> GetFuncionario() {
            return Ok( await _funcionarioInterface.GetFuncionario());      
        }

        [HttpGet("id")]
        public async Task<ActionResult<ServiceResponse<FuncionarioModel>>> GetFuncionarioById(int ID) {
            ServiceResponse<FuncionarioModel> response = await _funcionarioInterface.GetFuncionarioById(ID);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> CreateFuncionario(FuncionarioModel funcionario) {
            return Ok( await _funcionarioInterface.CreateFuncionario(funcionario));

        }

        [HttpPut("inativaFuncionario")]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> InativaFuncionario(int ID) {
            ServiceResponse<List<FuncionarioModel>> response = await _funcionarioInterface.InativaFuncionario(ID);
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> UpdateFuncionario(FuncionarioModel funcionario) {
            ServiceResponse<List<FuncionarioModel>> response = await _funcionarioInterface.UpdateFuncionario(funcionario);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> DeleteFuncionario(int id) {
            ServiceResponse<List<FuncionarioModel>> response = await _funcionarioInterface.DeleteFuncionario(id);
            return Ok(response);
        }
    }
}
