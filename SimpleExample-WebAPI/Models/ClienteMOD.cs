using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleExample_WebAPI.Models
{
    public class ClienteMOD
    {
        public int Id { get; set; }
        public String Nome { get; set; }
        public String NomeFantasia { get; set; }
        public String Email { get; set; }
        public String Telefone { get; set; }
        public String Cnpj { get; set; }
    }
}