using System;

namespace SimpleExample_WebAPI.Models
{
    public class PedidoMOD
    {
        public Int32 Id { get; set; }
        public String NotaFiscal { get; set; }
        public String Descricao { get; set; }
        public String Moeda { get; set; }
        public Double ValorTotal { get; set; }
        public Int32 Quantidade { get; set; }
        public ClienteMOD Cliente { get; set; }
        public StatusPedidosMOD Status { get; set; }

    }
}