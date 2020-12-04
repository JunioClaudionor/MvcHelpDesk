using System;
using System.ComponentModel.DataAnnotations;

namespace MvcHelpDesk.Models
{
    public class FeedBack
    {
        public int Id { get; set; }
        public decimal Nota { get; set; }
        public string Comentário { get; set; }

    }
}