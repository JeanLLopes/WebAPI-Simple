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


        public HttpResponseMessage ConsultaCnpj(String cnpj)
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


        public HttpResponseMessage ConsultaCnpj(Int32 dias)
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


        public HttpResponseMessage ConsultaCnpjDias(String cnpj, Int32 dias)
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
