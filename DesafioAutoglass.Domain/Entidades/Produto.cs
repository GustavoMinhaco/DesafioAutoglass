using DesafioAutoglass.Domain.Validacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAutoglass.Domain.Entidades
{
    public  class Produto : Entity
    {
        public string Descricao { get; private set; }
        public bool Situacao { get; set; }
        public DateTime DataFabricacao { get; private set; }
        public DateTime DataValidade { get; private set; }
        public int CodigoFornecedor { get; private set; }
        public string DescricaoFornecedor { get; private set; }
        public string CnpjFornecedor { get; private set; }


        public Produto(int id, string descricao, bool situacao, DateTime dataFabricacao, DateTime dataValidade, int codigoFornecedor, string descricaoFornecedor, string cnpjFornecedor)
        {
            DomainExceptionValidation.When(id < 0, "Campo obrigatório 'Id' inválido.");
            Id = id;

            ValidationDomain(descricao, situacao, dataFabricacao, dataValidade, codigoFornecedor, descricaoFornecedor, cnpjFornecedor);
        }

        public Produto(string descricao, bool situacao, DateTime dataFabricacao, DateTime dataValidade, int codigoFornecedor, string descricaoFornecedor, string cnpjFornecedor)
        {
            ValidationDomain(descricao, situacao, dataFabricacao, dataValidade, codigoFornecedor, descricaoFornecedor, cnpjFornecedor);
        }

        public void ValidationDomain(string descricao, bool situacao, DateTime dataFabricacao, DateTime dataValidade, int codigoFornecedor, string descricaoFornecedor, string cnpjFornecedor)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(descricao), "Campo obrigatório 'Descricao' inválido.");
            DomainExceptionValidation.When(descricao.Length < 3, "Campo obrigatório 'Descricao' inválido, muito curto, mínimo 3 characters");

            DomainExceptionValidation.When(dataFabricacao == DateTime.MinValue, "Campo obrigatório 'DataFabricacao' inválido.");
            DomainExceptionValidation.When(dataValidade == DateTime.MinValue, "Campo obrigatório 'DataValidade' inválido.");
            
            DomainExceptionValidation.When(dataFabricacao > DateTime.Now, "Campo obrigatório 'DataFabricacao' não pode ser maior que a data atual.");
            DomainExceptionValidation.When(dataFabricacao >= dataValidade, "Campo obrigatório 'DataFabricacao' não pode ser maior que o campo obrigatório 'DataValidade'.");

            Descricao = descricao;
            Situacao = situacao;
            DataFabricacao = dataFabricacao;
            DataValidade = dataValidade;
            CodigoFornecedor = codigoFornecedor;
            DescricaoFornecedor = descricaoFornecedor;
            CnpjFornecedor = cnpjFornecedor;
        }
    }
}
