using System;
using System.ComponentModel.DataAnnotations;

namespace MvcHelpDesk.Models
{
    public class Denunciar
    {
        public int Id { get; set; }

        // Um denuncia deve conter apenas um usuário denunciante.
        public string Usuario {get; set;}   

        // Um denuncia deve conter apenas um técnico denunciado.
        public string Tecnico {get; set;}

        public string Descricao{get; set;}
    }
}
