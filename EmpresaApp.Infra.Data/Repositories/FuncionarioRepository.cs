  using EmpresaApp.Domain.Entities;
using EmpresaApp.Domain.Interfaces.Repositories;
using EmpresaApp.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaApp.Infra.Data.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        public void Add(Funcionario funcionario)
        {
            using (var context = new DataContext())
            {
                context.Add(funcionario);
                context.SaveChanges();
            }
        }

        public void Delete(Funcionario funcionario)
        {
            using (var context = new DataContext())
            {
                context.Remove(funcionario);
                context.SaveChanges();
            }
        }

        public List<Funcionario> GetAll()
        {
            using (var context = new DataContext())
            {
                return context.Set<Funcionario>()
                    .Include(f => f.Empresa)
                    .OrderBy(f => f.DataHoraCadastro)
                    .ToList();
            }
        }

        public Funcionario GetById(Guid id)
        {
            using (var context = new DataContext())
            {
                return context.Set<Funcionario>()
                    .Where(f => f.IdFuncionario == id)
                    .Include(f => f.Empresa)
                    .FirstOrDefault();
            }
        }

        public Funcionario GetCpf(string cpf)
        {
            using (var context = new DataContext())
            {
                return context.Set<Funcionario>()
                    .Where(e => e.Cpf.Equals(cpf))
                    .Include(f => f.Empresa)
                    .FirstOrDefault();
            }
        }

        public Funcionario GetMatricula(string matricula)
        {
            using (var context = new DataContext())
            {
                return context.Set<Funcionario>()
                    .Where(e => e.Matricula.Equals(matricula))
                    .Include(f => f.Empresa)
                    .FirstOrDefault();
            }
        }

        public void Update(Funcionario funcionario)
        {


            using (var context = new DataContext())
            {
                context.Update(funcionario);
                context.SaveChanges();
            }
        }
    }
}
