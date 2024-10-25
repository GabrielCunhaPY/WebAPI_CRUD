using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Collections.Generic;
using WebAPI_Estudo.DataContext;
using WebAPI_Estudo.Models;

namespace WebAPI_Estudo.Service.FuncionarioService
{
    public class FuncionarioService : IfuncionarioInterface
    {
        private readonly ApplicationDbContext _context;


        public FuncionarioService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServicesResponse<List<FuncionarioModel>>> CreateFuncionario(FuncionarioModel novoFuncionario)
        {
            ServicesResponse<List<FuncionarioModel>> servicesResponse = new ServicesResponse<List<FuncionarioModel>>();

            try
            {
                if (novoFuncionario == null)
                {
                    servicesResponse.Mensagem = "InformarDados";
                    servicesResponse.Sucesso = false;
                    servicesResponse.Dados = null;
                }
                _context.Add(novoFuncionario);
                await _context.SaveChangesAsync();

                servicesResponse.Dados = _context.Funcionarios.ToList();

            }
            catch (Exception ex)
            {
                servicesResponse.Mensagem = ex.Message;
                servicesResponse.Sucesso = false;
            }

            return servicesResponse;

        }

        public Task DeleteFuncionario(int id)
        {
            throw new NotImplementedException();
        }

            public async Task<ServicesResponse<List<FuncionarioModel>>> GetFuncionario()
            {
                ServicesResponse<List<FuncionarioModel>> servicesResponse = new ServicesResponse<List<FuncionarioModel>>();

                try
                {
                    servicesResponse.Dados = _context.Funcionarios.ToList();
                    
                    if (servicesResponse.Dados.Count == 0)
                    {
                    servicesResponse.Mensagem = "Nenhum dado Encontrado!";
                    }
                }
                catch (Exception ex)
                {
                    servicesResponse.Mensagem = ex.Message;
                    servicesResponse.Sucesso = false;
                }

                return servicesResponse;

            }


        public async Task<ServicesResponse<FuncionarioModel>> GetFuncionarioByID(int id)
        {
            ServicesResponse<FuncionarioModel> servicesResponse = new ServicesResponse<FuncionarioModel>();

            try
            {


                FuncionarioModel funcionario = _context.Funcionarios.FirstOrDefault(x=> x.Id == id);

                servicesResponse.Dados = funcionario;

                if (funcionario != null)
                {
                    servicesResponse.Mensagem = "Usuário não localizado";
                    servicesResponse.Dados = null;
                    servicesResponse.Sucesso = false ;
                }


            }catch (Exception ex)
            {
                servicesResponse.Mensagem = ex.Message;
                servicesResponse.Sucesso = false;
            }
            return servicesResponse;
        }

        public async Task<ServicesResponse<List<FuncionarioModel>>> InativaFuncionario(int id)
        {
            ServicesResponse<List<FuncionarioModel>> servicesResponse = new ServicesResponse<List<FuncionarioModel>>();

            try
            {
                FuncionarioModel funcionario = _context.Funcionarios.FirstOrDefault(x => x.Id == id);

                if (funcionario != null)
                {
                    servicesResponse.Mensagem = "Usuário não localizado";
                    servicesResponse.Dados = null;
                    servicesResponse.Sucesso = false;
                }

                funcionario.Ativo = false;
                funcionario.DataDeAlteração = DateTime.Now.ToLocalTime();

                _context.Funcionarios.Update(funcionario);

                await _context.SaveChangesAsync();

                servicesResponse.Dados = _context.Funcionarios.ToList();


            }
            catch (Exception ex)
            {
                servicesResponse.Mensagem = ex.Message;
                servicesResponse.Sucesso = false;
            }
            return servicesResponse;
        }

        public async Task<ServicesResponse<List<FuncionarioModel>>> UpdateFuncionario(FuncionarioModel editadoFuncionario)
        {
            ServicesResponse<List<FuncionarioModel>> servicesResponse = new ServicesResponse<List<FuncionarioModel>>();

            try
            {


                FuncionarioModel funcionario = _context.Funcionarios.AsNoTracking().FirstOrDefault(x => x.Id == editadoFuncionario.Id);

                if (funcionario != null)
                {
                    servicesResponse.Mensagem = "Usuário não localizado";
                    servicesResponse.Dados = null;
                    servicesResponse.Sucesso = false;
                }

                funcionario.DataDeAlteração = DateTime.Now.ToLocalTime();

                _context.Funcionarios.Update(editadoFuncionario);
                await _context.SaveChangesAsync();

                servicesResponse.Dados= _context.Funcionarios.ToList();

            }
            catch (Exception ex)
            {
                servicesResponse.Mensagem = ex.Message;
                servicesResponse.Sucesso = false;
            }

            return servicesResponse;
        }
    }
}
