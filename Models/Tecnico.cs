using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;  

namespace MvcHelpDesk.Models
{
    public class Tecnico: Usuario
    {
        public string Escolaridade { get; set; }
        public string Experiencia { get; set; }
        
        // Um técnico pode atender vários serviços
        public List <OrdemDeServico> AtenderServico {get; set;}
    }
}
