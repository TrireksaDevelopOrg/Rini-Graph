using Penjadwalan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Penjadwalan.Controllers
{
    public class JadwalController : ApiController
    {
        // GET: api/Jadwal
        public IHttpActionResult Get()
        {

            try
            {
                Domains.JadwalDomain domain = new Domains.JadwalDomain();
                var result = domain.GetPeriode();
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // GET: api/Jadwal/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                Domains.JadwalDomain domain = new Domains.JadwalDomain();
                var result = domain.GetJadwal(id);
                return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Jadwal
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Jadwal/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Jadwal/5
        public void Delete(int id)
        {
        }
    }
}
