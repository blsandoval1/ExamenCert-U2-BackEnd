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
    public class MateriaController : ApiController
    {
        public IHttpActionResult Post(Materia materia)
        {
            try
            {
                MateriaBLL.Create(materia);
                return Content(HttpStatusCode.Created, "Materia creado correctamente");
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }
                       
        public IHttpActionResult Get()
        {
            try
            {
                List<Materia> todos = MateriaBLL.List();
                return Content(HttpStatusCode.OK, todos);
            }
            catch (Exception ex) {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }

        public IHttpActionResult Put(Materia materia)
        {
            try
            {
                MateriaBLL.Update(materia);
                return Content(HttpStatusCode.OK, "Materia actualizado correctamente");

            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        public IHttpActionResult Get(int id)
        {
            try
            {
                Materia result = MateriaBLL.Get(id);
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
                MateriaBLL.Delete(id);
                return Ok("Materia eliminado correctamente");
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }

    }
}