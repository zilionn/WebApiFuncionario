using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using WEBAPI_Funcionario.DataContent;
using WEBAPI_Funcionario.Models;

namespace WEBAPI_Funcionario.Service.FuncionarioService {
    public class FuncionarioService : IFuncionarioInterface {

        private readonly AppDbContext context;

        public FuncionarioService(AppDbContext context) { 
            this.context = context;
        }
        public async Task<ServiceResponse<List<FuncionarioModel>>> CreateFuncionario(FuncionarioModel newFuncionario) {
            ServiceResponse<List<FuncionarioModel>> response = new ServiceResponse<List<FuncionarioModel>>();
           
            try {

                if (newFuncionario == null) {
                    response.Mensagem = "Informe dados";
                    response.Sucesso = false;
                    response.Dados = null;

                    return response;
                }

                context.Add(newFuncionario);
                await context.SaveChangesAsync();

                response.Dados = context.Funcionarios.ToList();
            } catch (Exception ex) {

                response.Mensagem = ex.Message;
                response.Sucesso = false;

            }
            return response;
        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> DeleteFuncionario(int id) {
            ServiceResponse<List<FuncionarioModel>> response = new ServiceResponse<List<FuncionarioModel>>();
            
            try {
                FuncionarioModel? func = context.Funcionarios.FirstOrDefault(x => x.Id == id);

                if (func == null) {
                    response.Mensagem = "Usuário não localizado ou inexistente";
                    response.Dados = null;
                    response.Sucesso = false;

                    return response;
                }

                context.Funcionarios.Remove(func);
                await context.SaveChangesAsync();

                response.Dados = context.Funcionarios.ToList();

            }catch(Exception e){ 
                response.Mensagem = e.Message;
                response.Sucesso=false;
            }
            return response; 
        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> GetFuncionario() {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

            try {
                serviceResponse.Dados = context.Funcionarios.ToList();
                if(serviceResponse.Dados.Count == 0){
                    serviceResponse.Mensagem = "Não há dados de nenhum funcionário";
                }



            }catch(Exception ex) {

                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<FuncionarioModel>> GetFuncionarioById(int ID) {

            ServiceResponse<FuncionarioModel> response = new ServiceResponse<FuncionarioModel>();
            try {

                FuncionarioModel func = context.Funcionarios.FirstOrDefault(x => x.Id == ID);
                if(func == null) {
                    response.Dados = null;
                    response.Mensagem = "Usuário não localizado ou inexistente";
                    response.Sucesso = false;
                }
                response.Dados = func;

            } catch(Exception e) {
                response.Mensagem = e.Message;
                response.Sucesso = false;
            }

            return response;
        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> InativaFuncionario(int id) {
            ServiceResponse<List<FuncionarioModel>> response = new ServiceResponse<List<FuncionarioModel>>();

            try{

                FuncionarioModel funcionario = context.Funcionarios.FirstOrDefault(x =>x.Id == id);

                if(funcionario  == null) { 
                    response.Dados=null;
                    response.Mensagem = "Usuário não encontrado ou inexistente";
                }

                funcionario.Ativo = false;
                funcionario.DataAlteracao = DateTime.Now.ToLocalTime();

                context.Funcionarios.Update(funcionario);
                await context.SaveChangesAsync();

                response.Dados = context.Funcionarios.ToList();

            } catch(Exception e) {

                response.Mensagem = e.Message;
                response.Sucesso = false;   
            }

            return response;
        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> UpdateFuncionario(FuncionarioModel editFuncionario) {
            ServiceResponse<List<FuncionarioModel>> response = new ServiceResponse<List<FuncionarioModel>>();

            try {
                FuncionarioModel funcionario = context.Funcionarios.AsNoTracking().FirstOrDefault(x => x.Id == editFuncionario.Id);
                if(funcionario == null) {
                    response.Dados=null;
                    response.Mensagem = "Usuário não encontrado ou inexistente";
                    response.Sucesso = false;    
                }

                funcionario.DataAlteracao = DateTime.Now.ToLocalTime();
                context.Funcionarios.Update(editFuncionario);
                await context.SaveChangesAsync();

                response.Dados = context.Funcionarios.ToList();

            } catch (Exception e) {
                response.Mensagem = e.Message;
                response.Sucesso = false;

            }

            return response;
        }
    }
}
