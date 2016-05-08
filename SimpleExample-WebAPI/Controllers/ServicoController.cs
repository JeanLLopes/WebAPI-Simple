using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SimpleExample_WebAPI.Business;
using SimpleExample_WebAPI.Models;

namespace SimpleExample_WebAPI.Controllers
{
    public class ServicoController : ApiController
    {
        private readonly ClientesBUS _clientesBus = new ClientesBUS();

        /// <summary>
        /// RETORNA A LISTA DE CLIENTES CADASTROS SEM NENHUM FILTRO APLICADO
        /// </summary>
        /// <returns>LISTA DE CLIENTES CADASTRADOS</returns>
        [HttpGet]
        public HttpResponseMessage ListaClientes()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, _clientesBus.GeraListaPedidos());
            }

            catch (SqlException  exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, exception.Message);
            }

            catch (ApplicationException exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, exception.Message);
            }

            catch (Exception exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, exception.Message);
            }
        }


        /// <summary>
        /// RETORNA A LISTA DE CLIENTES CADASTROS COM FILTRO APLICADO PELO CNPJ
        /// </summary>
        /// <returns>LISTA DE CLIENTES CADASTRADOS COM FILTRO APLICADO PELO CNPJ</returns>
        [HttpPost]
        public HttpResponseMessage ConsultaCnpj([FromBody]String cnpj)
        {
            try
            {
                List<PedidoMOD> pedidosClientes = _clientesBus.GeraListaPedidos().FindAll(x => x.Cliente.Cnpj.Equals(cnpj));

                if (pedidosClientes.Count > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, pedidosClientes);
                }

                return Request.CreateResponse(HttpStatusCode.NotFound, pedidosClientes);

            }
            catch (SqlException exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, exception.Message);
            }

            catch (ApplicationException exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, exception.Message);
            }

            catch (Exception exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, exception.Message);
            }
        }


        /// <summary>
        /// RETORNA A LISTA DE CLIENTES CADASTROS COM FILTRO APLICADO PELA QUANTIDADE DE DIAS DA SOLICITAÇÃO
        /// </summary>
        /// <returns>LISTA DE CLIENTES CADASTRADOS COM FILTRO APLICADO PELA QUANTIDADE DE DIAS DA SOLICITAÇÃO</returns>
        [HttpPost]
        public HttpResponseMessage ConsultaDias([FromBody]Int32 dias)
        {
            try
            {
                List<PedidoMOD> pedidosClientes = _clientesBus.GeraListaPedidos().FindAll(x => x.Status.QuantidadeDias.Equals(dias));

                if (pedidosClientes.Count > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, pedidosClientes);
                }

                return Request.CreateResponse(HttpStatusCode.NotFound, pedidosClientes);

            }
            catch (SqlException exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, exception.Message);
            }

            catch (ApplicationException exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, exception.Message);
            }

            catch (Exception exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, exception.Message);
            }
        }


        /// <summary>
        /// RETORNA A LISTA DE CLIENTES CADASTROS COM FILTRO APLICADO PELA QUANTIDADE DE DIAS DA SOLICITAÇÃO E PELO CNPJ
        /// </summary>
        /// <returns>LISTA DE CLIENTES CADASTRADOS COM FILTRO APLICADO PELA QUANTIDADE DE DIAS DA SOLICITAÇÃO E PELO CNPJ</returns>
        [HttpPost]
        public HttpResponseMessage ConsultaCnpjDias([FromBody]String cnpj, [FromBody]Int32 dias)
        {
            try
            {
                List<PedidoMOD> pedidosClientes = _clientesBus.GeraListaPedidos().FindAll(x => x.Cliente.Cnpj.Equals(cnpj) && x.Status.QuantidadeDias.Equals(dias));

                if (pedidosClientes.Count > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, pedidosClientes);
                }

                return Request.CreateResponse(HttpStatusCode.NotFound, pedidosClientes);

            }
            catch (SqlException exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, exception.Message);
            }

            catch (ApplicationException exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, exception.Message);
            }

            catch (Exception exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, exception.Message);
            }
        }
    }
}
