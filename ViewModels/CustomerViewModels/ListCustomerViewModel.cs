namespace CustomerManagement.ViewModels.CustomerViewModels
{
    public class ListCustomerViewModel
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
    }
}