using EmpresaApp.Domain.Entities;
using EmpresaApp.Domain.Interfaces.Repositories;
using EmpresaApp.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaApp.Domain.Services
{
    public class FuncionarioDomainService : IFuncionarioDomainService
    {
        private readonly IFuncionarioRepository _funcionarioRepository;
        private readonly IEmpresaRepository _empresaRepository;

        public FuncionarioDomainService(IFuncionarioRepository funcionarioRepository, IEmpresaRepository empresaRepository)
        {
            _funcionarioRepository = funcionarioRepository;
            _empresaRepository = empresaRepository;
        }

        public void AtualizarFuncionario(Funcionario funcionario)
        {
          
            if (_funcionarioRepository.GetById(funcionario.IdFuncionario.Value) == null)
                throw new ApplicationException("ID inexistente. Por favor, informe outro.");

            _funcionarioRepository.Update(funcionario);
        }

        public void CadastrarFuncionario(Funcionario funcionario)
        {
            var empresa = _empresaRepository.GetById(funcionario.IdEmpresa.Value);

            if (empresa == null)
                throw new ApplicationException("ID inexistente. Por favor, informe outro.");


            if (_funcionarioRepository.GetMatricula(funcionario.Matricula) != null)
                throw new ApplicationException("Matrícula já existente. Por favor, informe outro");

            if (_funcionarioRepository.GetCpf(funcionario.Cpf) != null)
                throw new ApplicationException("CPF´já existente. Por favor, informe outro.");

            _funcionarioRepository.Add(funcionario);
        }

        public List<Funcionario> ConsultarFuncionarios()
        {
            return _funcionarioRepository.GetAll();
        }

        public Funcionario ObterPorId(Guid id)
        {
            var funcionario = _funcionarioRepository.GetById(id);

            if (funcionario == null)
                throw new ApplicationException("ID inexistente. Por favor, informe outro.");

            return _funcionarioRepository.GetById(id);
        }

        public void RemoverFuncionario(Guid id)
        {
            var funcionario = _funcionarioRepository.GetById(id);

            if (funcionario == null)
                throw new ApplicationException("ID inexistente. Por favor, informe outro.");

            _funcionarioRepository.Delete(funcionario);
        }
    }
}
