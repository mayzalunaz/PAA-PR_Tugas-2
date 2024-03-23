using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Manajemen_Kelas_PR.Models;
using System;
using System.Collections.Generic;

namespace Manajemen_Kelas_PR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SiswaController : ControllerBase
    {
        private readonly string _constr;

        public SiswaController(IConfiguration configuration)
        {
            _constr = configuration.GetConnectionString("WebApiDatabase");
        }

        [HttpGet]
        public ActionResult<IEnumerable<Siswa>> ListPerson()
        {
            SiswaContext context = new SiswaContext(_constr);
            List<Siswa> listPerson = context.ListPerson();
            return Ok(listPerson);
        }

        [HttpGet("{id}")]
        public ActionResult<Siswa> GetSiswaByID(int id)
        {
            SiswaContext context = new SiswaContext(_constr);
            var siswa = context.GetSiswaByID(id);
            if (siswa == null)
            {
                return NotFound();
            }
            return Ok(siswa);
        }

        [HttpPost]
        public ActionResult<Siswa> PostSiswa(Siswa siswa)
        {
            try
            {
                SiswaContext context = new SiswaContext(_constr);
                context.AddSiswa(siswa);
                return CreatedAtAction(nameof(GetSiswaByID), new { id = siswa.id_siswa }, siswa);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpPut("{id}")]
        public IActionResult PutSiswa(int id, Siswa siswa)
        {
            SiswaContext context = new SiswaContext(_constr);
            // Implementasi tambahan untuk memperbarui siswa dalam database
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSiswa(int id)
        {
            SiswaContext context = new SiswaContext(_constr);
            // Implementasi tambahan untuk menghapus siswa dari database
            throw new NotImplementedException();
        }
    }
}
