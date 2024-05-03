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
    public class EmpresaRepository : IEmpresaRepository
    {

        public void Add(Empresa empresa)
        {
            using (var context = new DataContext())
            {
                context.Add(empresa);
                context.SaveChanges();
            }
        }

        public void Delete(Empresa empresa)
        {
            using (var context = new DataContext())
            {
                context.Remove(empresa);
                context.SaveChanges();

            }
        }

        public List<Empresa> GetAll()
        {
            using (var context = new DataContext())
            {
                return context.Set<Empresa>()
                    .Include(e => e.Funcionarios) 
                    .OrderBy(e => e.NomeFantasia)
                    .ToList();
            }
        }

        public Empresa GetById(Guid id)
        {
            using (var context = new DataContext())
            {
                return context.Set<Empresa>()
                    .Where(e => e.IdEmpresa == id)
                    .FirstOrDefault();
            }
        }

        public Empresa GetCnpj(string cnpj)
        {
            using (var context = new DataContext())
            {
                return context.Set<Empresa>()
                    .Where(e => e.Cnpj.Equals(cnpj))
                    .FirstOrDefault();
            }
        }

        public Empresa GetRazaoSocial(string razaoSocial)
        {
            using (var context = new DataContext())
            {
                return context.Set<Empresa>()
                    .Where(e => e.RazaoSocial.Equals(razaoSocial))
                    .FirstOrDefault();
            }
        }

        public void Update(Empresa empresa)
        {
            using (var context = new DataContext())
            {
                context.Update(empresa);
                context.SaveChanges();
            }

        }

    }
}
