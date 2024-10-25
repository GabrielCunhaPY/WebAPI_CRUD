using WebAPI_Estudo.Models;

namespace WebAPI_Estudo.Service.FuncionarioService
{
    public interface IfuncionarioInterface
    {
        Task<ServicesResponse<List<FuncionarioModel>>> GetFuncionario();

        Task<ServicesResponse<List<FuncionarioModel>>> CreateFuncionario(FuncionarioModel novoFuncionario);

        Task<ServicesResponse<FuncionarioModel>> GetFuncionarioByID(int id);

        Task<ServicesResponse<List<FuncionarioModel>>> UpdateFuncionario(FuncionarioModel editadoFuncionario);

        Task DeleteFuncionario(int id);

        Task<ServicesResponse<List<FuncionarioModel>>> InativaFuncionario(int id);
    }
}
