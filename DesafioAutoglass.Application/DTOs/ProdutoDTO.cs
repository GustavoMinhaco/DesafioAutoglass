using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAutoglass.Application.DTOs
{
    public  class ProdutoDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "A Descricao é requerido!")]
        [MinLength(3)]
        [MaxLength(200)]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "A Situacao é requerida!")]
        public bool Situacao { get; set; }

        [Required(ErrorMessage = "A DataFabricacao é requerida!")]
        public DateTime DataFabricacao { get; set; }

        [Required(ErrorMessage = "A DataValidade é requerida!")]
        public DateTime DataValidade { get; set; }

        public int CodigoFornecedor { get; set; }

        [MaxLength(200)]
        public string DescricaoFornecedor { get; set; }

        [MaxLength(18)]
        public string CNPJFornecedor { get; set; }

    }
}
