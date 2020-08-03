using BEUEjercicio;
using BEUEjercicio.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using System.Web.Mvc;

namespace WebApiEscolastico.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class BecaController : ApiController
    {
        public IHttpActionResult Post(Beca beca)
        {
            try
            {
                BecaBLL.Create(beca);
                return Content(HttpStatusCode.Created, "Beca creado correctamente");
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }
                       
        public IHttpActionResult Get()
        {
            try
            {
                List<Beca> todos = BecaBLL.List();
                return Content(HttpStatusCode.OK, todos);
            }
            catch (Exception ex) {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }

        public IHttpActionResult Put(Beca beca)
        {
            try
            {
                BecaBLL.Update(beca);
                return Content(HttpStatusCode.OK, "Beca actualizado correctamente");

            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        public IHttpActionResult Get(int id)
        {
            try
            {
                Beca result = BecaBLL.Get(id);
                if (result == null) {
                    return NotFound();
                }
                return Content(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }

        public IHttpActionResult Delete(int id)
        {
            try
            {
                BecaBLL.Delete(id);
                return Ok("Beca eliminado correctamente");
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }

    }
}