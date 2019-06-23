using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backEnd.Models;
using backEnd.Models.Types;

namespace backEnd.Controllers
{
    [Route ("api/[controller]")]
    [ApiController]

    public class LaporanController : ControllerBase
    {
        public Context db;

        public LaporanController(Context _db)
        {
            db = _db;
        }

        [HttpGet]  
        public ActionResult Get () 
        {
            var laporanHeaders = db.LaporanHeaders.Include(x => x.User).OrderBy(x=>x.TglBuat).AsNoTracking().ToList();

            foreach (var laporanHeader in laporanHeaders)
            {
                switch (laporanHeader.StatusLaporan)
                {
                    case StatusLaporan.Created:
                        laporanHeader.Status = "Pending";
                        break;
                    case StatusLaporan.Processing:
                        laporanHeader.Status = "Processing";
                        break;
                    case StatusLaporan.Done:
                        laporanHeader.Status = "Done";
                        break;
                }
            }

            return Ok(laporanHeaders);
        }

        // GET api/values/5
        [HttpGet ("{id}")]
        public ActionResult Get (Guid id) 
        {
            var laporanHeader = db.LaporanHeaders.
                Include(x => x.User).Include(x=> x.LaporanItems)
                .ThenInclude(x=>x.User).AsNoTracking().ToList();            
            
            return Ok();
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post (LaporanHeader laporanHeader) 
        { 
            laporanHeader.LaporanHeaderId = Guid.NewGuid();
            laporanHeader.StatusLaporan = StatusLaporan.Created;    

            db.LaporanHeaders.Add(laporanHeader);
            db.SaveChanges();

            return Ok();
        }

        // PUT api/values/5
        [HttpPut ("{id}")]
        public void Put (int id, [FromBody] string value) { }

        // DELETE api/values/5
        [HttpDelete ("{id}")]
        public void Delete (int id) { }

        [HttpGet, Route("changeStatus")]
        public ActionResult ChangeStatus(Guid laporanHeaderId, string statusLaporan)
        {
            var laporanHeader = db.LaporanHeaders.SingleOrDefault(x=>x.LaporanHeaderId == laporanHeaderId);

            switch (statusLaporan)
            {
                case StatusLaporan.Created:
                    laporanHeader.StatusLaporan = StatusLaporan.Processing;
                    laporanHeader.Status = "Processing";
                    break;
                case StatusLaporan.Processing:
                    laporanHeader.StatusLaporan = StatusLaporan.Done;
                    laporanHeader.TglSelesai = DateTime.Now;
                    laporanHeader.Status = "Done";
                    break;
            }

            db.LaporanHeaders.Update(laporanHeader);
            db.SaveChanges();

            return Ok(laporanHeader);
        }
    }
}