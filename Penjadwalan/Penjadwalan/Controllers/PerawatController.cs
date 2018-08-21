using Penjadwalan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Penjadwalan.Controllers
{
    [Authorize]
    public class PerawatController : ApiController
    {

        private Domains.PetugasDomain domain = new Domains.PetugasDomain();
        // GET: api/Perawat
        public async Task<IHttpActionResult> GetAsync()
        {
            try
            {
                var resul = await domain.GetPerawat();
                return Ok(resul);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());   
            }
        }

        // GET: api/Perawat/5
        public async Task<IHttpActionResult> Get(int id)
        {
            try
            {
                var result = await domain.GetPerawatById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message.ToString());
            }
        }

        // POST: api/Perawat
        public async Task<IHttpActionResult> PostAsync([FromBody]perawat value)
        {
            try
            {
                var result = await domain.SaveChange(value);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message.ToString());
            }
        }

        // PUT: api/Perawat/5
        public async Task<IHttpActionResult> Put(int id, [FromBody]perawat value)
        {
            try
            {
                var result = await domain.SaveChange(value);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message.ToString());
            }
        }

        // DELETE: api/Perawat/5
        public async  Task<IHttpActionResult> Delete(int id)
        {
            try
            {
                var result = await domain.DeletePerawat(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }
    }
}
