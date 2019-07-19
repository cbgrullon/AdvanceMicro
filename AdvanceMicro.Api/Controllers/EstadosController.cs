using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AdvanceMicro.Api.Controllers
{
    using Services;
    public class EstadosController : ApiController
    {
        private AdvanceDb Db = new AdvanceDb();
        [Route("api/Estados")]
        public IHttpActionResult GetEstados()
        {
            return Json(Db.Estados);
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            Db.Dispose();
        }
    }
}
