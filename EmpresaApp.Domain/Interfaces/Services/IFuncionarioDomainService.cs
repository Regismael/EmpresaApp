using EmpresaApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaApp.Domain.Interfaces.Services
{
    public interface IFuncionarioDomainService
    {
        void CadastrarFuncionario(Funcionario funcionario);
        void AtualizarFuncionario(Funcionario funcionario);
        void RemoverFuncionario(Guid id);
        List<Funcionario> ConsultarFuncionarios();
        Funcionario ObterPorId(Guid id);

    }
}
