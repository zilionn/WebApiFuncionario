using WEBAPI_Funcionario.Models;

namespace WEBAPI_Funcionario.Service.FuncionarioService {
    public interface IFuncionarioInterface {
        Task<ServiceResponse<List<FuncionarioModel>>> GetFuncionario();
        Task<ServiceResponse<List<FuncionarioModel>>> CreateFuncionario(FuncionarioModel newFuncionario);
        Task<ServiceResponse<FuncionarioModel>> GetFuncionarioById(int ID);
        Task<ServiceResponse<List<FuncionarioModel>>> UpdateFuncionario(FuncionarioModel editFuncionario);
        Task<ServiceResponse<List<FuncionarioModel>>> DeleteFuncionario(int id);
        Task<ServiceResponse<List<FuncionarioModel>>> InativaFuncionario(int id);

    }
}
