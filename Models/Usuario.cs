using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;  

namespace MvcHelpDesk.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome{ get; set; }

        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }
        public decimal CPF { get; set; }
        public decimal Telefone { get; set; }
        public string Email { get; set; }

        // Um usuario pode solicitar vários servicos
        public List <OrdemDeServico> SolicitarServico {get; set;}
    }
    
}
