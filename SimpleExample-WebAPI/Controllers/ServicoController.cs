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
    [RoutePrefix("Servico")]
    public class ServicoController : ApiController
    {
        private readonly ClientesBUS _clientesBus = new ClientesBUS();

        /// <summary>
        /// RETORNA A LISTA DE CLIENTES CADASTROS SEM NENHUM FILTRO APLICADO
        /// 
        /// GET /Servico/ListaClientes HTTP/1.1
        /// Host: localhost:35825
        /// Content-Type: application/json
        /// Cache-Control: no-cache
        /// Postman-Token: be1f87cb-40a6-52e2-ce39-e4f57e982c48
        /// </summary>
        /// <returns>LISTA DE CLIENTES CADASTRADOS</returns>
        [HttpGet]
        [Route("ListaClientes")] //http://localhost:35825/Servico/ListaClientes
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
        /// 
        /// POST /Servico/ConsultaDias HTTP/1.1
        /// Host: localhost:35825
        /// Content-Type: application/json
        /// Cache-Control: no-cache
        /// Postman-Token: 37773ca3-1366-75ca-12b3-979f1deaef06
        /// 1234.1234.1234-0001
        ///
        /// </summary>
        /// <returns>LISTA DE CLIENTES CADASTRADOS COM FILTRO APLICADO PELO CNPJ</returns>
        [HttpPost]
        [Route("ConsultaCnpj")] //http://localhost:35825/Servico/ConsultaCnpj
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
        /// 
        /// POST /Servico/ConsultaDias HTTP/1.1
        /// Host: localhost:35825
        /// Content-Type: application/json
        /// Cache-Control: no-cache
        /// Postman-Token: 37773ca3-1366-75ca-12b3-979f1deaef06
        /// 123
        /// 
        /// </summary>
        /// <returns>LISTA DE CLIENTES CADASTRADOS COM FILTRO APLICADO PELA QUANTIDADE DE DIAS DA SOLICITAÇÃO</returns>
        [HttpPost]
        [Route("ConsultaDias")] //http://localhost:35825/Servico/ConsultaDias
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
        /// 
        /// 
        /// POST /Servico/ConsultaCnpjDias HTTP/1.1
        /// Host: localhost:35825
        /// Content-Type: application/json
        /// Cache-Control: no-cache
        /// Postman-Token: 2ef7a664-8468-2d0b-2fe2-1a6c3c9aa47b
        /// {
        ///     'cnpj':'342342432',
        ///     'dias':12
        /// }
        /// 
        /// </summary>
        /// <returns>LISTA DE CLIENTES CADASTRADOS COM FILTRO APLICADO PELA QUANTIDADE DE DIAS DA SOLICITAÇÃO E PELO CNPJ</returns>
        [HttpPost]
        [Route("ConsultaCnpjDias")] //http://localhost:35825/Servico/ConsultaCnpjDias
        public HttpResponseMessage ConsultaCnpjDias([FromBody]RecebeCliente dadoCliente)
        {
            try
            {
                List<PedidoMOD> pedidosClientes = _clientesBus.GeraListaPedidos().FindAll(x => x.Cliente.Cnpj.Equals(dadoCliente.cnpj) && x.Status.QuantidadeDias.Equals(dadoCliente.dias));

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
