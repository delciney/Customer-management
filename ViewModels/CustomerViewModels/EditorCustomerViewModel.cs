using System;
using Flunt.Notifications;
using Flunt.Validations;

namespace CustomerManagement.ViewModels.CustomerViewModels
{
    public class EditorCustomerViewModel : Notifiable, IValidatable
    {

        public int Id { get; set; }
        public string CNPJ { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string NomeContato { get; set; }
        public string EnderecoCep { get; set; }
        public string EnderecoLogradouro { get; set; }
        public string EnderecoNro { get; set; }
        public string EnderecoBairro { get; set; }
        public string EnderecoCidade { get; set; }
        public string EnderecoEstado { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .HasMaxLen(RazaoSocial, 120, "RazaoSocial", "A razao social deve conter até 120 caracteres")
                    .HasMinLen(RazaoSocial, 3, "RazaoSocial", "A razao social deve conter pelo menos 3 caracteres")
                    .HasMaxLen(CNPJ, 14, "CNPJ", "O CNPJ deve conter 14 caracteres")
                    .HasMinLen(CNPJ, 14, "CNPJ", "O CNPJ deve conter 14 caracteres")
            );
        }
    }
}