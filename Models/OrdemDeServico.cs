using System;
using System.ComponentModel.DataAnnotations;

namespace MvcHelpDesk.Models
{
    public class OrdemDeServico
    {
        public int Id { get; set; }
        public string Endereco { get; set; }
        public string TipoServico { get; set; }
        public string CategoriaServico{ get; set; }
        public string DescricaoProblema { get; set; }
        public string Status { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataSolicitacao { get; set; }
        // Uma Serviço pode ter apensas um denuncia
        public Denunciar Denunciar {get; set;}
        // Um serviço pode ter apenas um feedback
        public FeedBack FeedBack {get; set;}
    }
}