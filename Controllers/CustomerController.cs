using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CustomerManagement.Data;
using CustomerManagement.Models;
using Microsoft.AspNetCore.Cors;

namespace CustomerManagement.Controllers
{
    public class CustomerController : Controller
    {
        private readonly CustomerRepository _repository;

        public CustomerController(CustomerRepository _repository)
        {
            _repository = repository;
        }

        [Route("v1/customers")]
        [HttpGet]
        public IEnumerable<Customer> Get()
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
        public Customer Post([FromBody] Customer customer)
        {
            customer.Validate();
            if (customer.Invalid)
                return new ResultViewModel
                {
                    Success = false,
                    Message = "Não foi possível cadastrar o cliente",
                    Data = model.Notifications
                };

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
        public Customer Put([FromBody] Customer customer)
        {
            customer.Validate();
            if (customer.Invalid)
                return new ResultViewModel
                {
                    Success = false,
                    Message = "Não foi possível alterar o cliente",
                    Data = model.Notifications
                };

            _repository.Update(customer);

            return new ResultViewModel
            {
                Success = true,
                Message = "Cliente alterado com sucesso!",
                Data = customer
            };
        }

        [Route("v1/customers")]
        [HttpDelete]
        public Customer Delete([FromBody] Customer customer)
        {
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