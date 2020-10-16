using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CustomerManagement.Data;
using CustomerManagement.Models;
using CustomerManagement.Repositories;
using Microsoft.AspNetCore.Cors;
using CustomerManagement.ViewModels.CustomerViewModels;
namespace CustomerManagement.Controllers
{
    public class CustomerController : Controller
    {
        private readonly CustomerRepository _repository;

        public CustomerController(CustomerRepository repository)
        {
            _repository = repository;
        }

        [Route("v1/customers")]
        [HttpGet]
        public IEnumerable<ListCustomerViewModel> Get()
        {
            return _repository.Get();
        }

        [Route("v1/customers/{id}")]
        [HttpGet]
        public Customer Get(int id)
        {
            return _repository.Get(id);
        }

        [Route("v1/customers")]
        [HttpPost]
        public ResultViewModel Post([FromBody] Customer customer)
        {
            _repository.Save(customer);

            return new ResultViewModel
            {
                Success = true,
                Message = "Cliente cadastrado com sucesso!",
                Data = customer
            };
        }

        [Route("v1/customers")]
        [HttpPut]
        public ResultViewModel Put([FromBody] EditorCustomerViewModel model)
        {
            model.Validate();
            if (model.Invalid)
                return new ResultViewModel
                {
                    Success = false,
                    Message = "Não foi possível alterar o cliente",
                    Data = model.Notifications
                };

            var customer = _repository.Get(model.Id);

            customer.CNPJ = model.CNPJ;
            customer.RazaoSocial = model.RazaoSocial;
            customer.NomeFantasia = model.NomeFantasia;
            customer.Email = model.Email;
            customer.Telefone = model.Telefone;
            customer.NomeContato = model.NomeContato;
            customer.EnderecoCep = model.EnderecoCep;
            customer.EnderecoLogradouro = model.EnderecoLogradouro;
            customer.EnderecoNro = model.EnderecoNro;
            customer.EnderecoBairro = model.EnderecoBairro;
            customer.EnderecoCidade = model.EnderecoCidade;
            customer.EnderecoEstado = model.EnderecoEstado;

            _repository.Update(customer);

            return new ResultViewModel
            {
                Success = true,
                Message = "Cliente alterado com sucesso!",
                Data = customer
            };
        }

        [Route("v1/customers/{id}")]
        [HttpDelete]
        public ResultViewModel Delete(int id)
        {
            var customer = _repository.Get(id);
            
            _repository.Remove(customer);

            return new ResultViewModel
            {
                Success = true,
                Message = "Cliente excluído com sucesso!",
                Data = customer
            };
        }
    }
}