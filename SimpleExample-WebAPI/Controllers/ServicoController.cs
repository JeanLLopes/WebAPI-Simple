using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SimpleExample_WebAPI.Business;

namespace SimpleExample_WebAPI.Controllers
{
    public class ServicoController : ApiController
    {
        private readonly ClientesBUS _clientesBus = new ClientesBUS();

        [HttpGet]
        public HttpResponseMessage ConsultaCnpj()
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

    }
}
