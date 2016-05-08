using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SimpleExample_WebAPI.Models;

namespace SimpleExample_WebAPI.Business
{
    public class ClientesBUS
    {

        /// <summary>
        /// GERA LISTA DE CLIENTES GENERICA QUE PODE SER RETORNADA DO BANCO DE DADOS
        /// </summary>
        /// <returns>LISTA DE CLIENTES CADASTRADOS</returns>
        public List<PedidoMOD> GeraListaPedidos()
        {

            var listaPedidos = new List<PedidoMOD>();

            for (int i = 0; i < 6; i++)
            {
                listaPedidos.Add(new PedidoMOD
                {
                    Id = 1,
                    Descricao = String.Format("Pedido Cliente {0}",i),
                    Moeda = "BRL",
                    NotaFiscal = "1234.1234.1234-2016",
                    ValorTotal = 10.00 * i,
                    Quantidade = 10 * i,
                    Cliente =
                        new ClienteMOD
                        {
                            Cnpj = "34.496.010/0001-81",
                            Email = "email@email.com",
                            Id = i,
                            Nome = String.Format("Cliente{0}",i),
                            NomeFantasia = String.Format("Cliente {0} - Fantasia", i),
                            Telefone = "101010-101010"
                        },
                    Status = new StatusPedidosMOD {Status = "Pendente", QuantidadeDias = 3 * i,}
                });
            }

            return listaPedidos;
        } 
    }
}