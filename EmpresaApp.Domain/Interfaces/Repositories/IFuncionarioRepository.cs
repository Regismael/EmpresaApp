using EmpresaApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaApp.Domain.Interfaces.Repositories
{
    public interface IFuncionarioRepository
    {
        void Add(Funcionario funcionario);
        void Update(Funcionario funcionario);
        void Delete(Funcionario funcionario);
        List<Funcionario> GetAll();
        Funcionario GetById(Guid id);
        Funcionario GetMatricula(string matricula);
        Funcionario GetCpf(string cpf);
    }
}
