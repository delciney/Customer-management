using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using CustomerManagement.Data;
using CustomerManagement.Models;
using CustomerManagement.ViewModels.CustomerViewModels;

namespace CustomerManagement.Repositories
{
    public class CustomerRepository
    {
        private readonly StoreDataContext _context;

        public CustomerRepository(StoreDataContext context)
        {
            _context = context;
        }
        public IEnumerable<ListCustomerViewModel> Get()
        {
            return _context
                .Customer
                .Select(x => new ListCustomerViewModel
                {
                    Id = x.Id,
                    CNPJ = x.CNPJ,
                    RazaoSocial = x.RazaoSocial,
                    NomeFantasia = x.NomeFantasia,
                    Email = x.Email,
                    Telefone = x.Telefone,
                    NomeContato = x.NomeContato,
                    EnderecoCep = x.EnderecoCep,
                    EnderecoLogradouro = x.EnderecoLogradouro,
                    EnderecoNro = x.EnderecoNro,
                    EnderecoBairro = x.EnderecoBairro,
                    EnderecoCidade = x.EnderecoCidade,
                    EnderecoEstado = x.EnderecoEstado,
                })
                .AsNoTracking()
                .ToList();
        }
        public Customer Get(int id)
        {
            return _context.Customer.Find(id);
        }
        public void Save(Customer customer)
        {
            _context.Customer.Add(customer);
            _context.SaveChanges();
        }
        public void Update(Customer customer)
        {
            _context.Entry<Customer>(customer).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public void Remove(Customer customer)
        {
            _context.Customer.Remove(customer);
            _context.SaveChanges();
        }
    }
}