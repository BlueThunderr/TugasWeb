using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using backEnd.Models;

namespace backEnd.Controllers
{
    [Route ("api/[controller]")]
    [ApiController]
    public class UserController: ControllerBase 
    {
        public Context _db;

        public UserController(Context db)
        {
            _db = db;
        }

        [HttpGet]     
        [DisableCors]    
        public ActionResult<IEnumerable<string>> Get () {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet ("{id}")]
        public ActionResult<string> Get (int id) {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post ([FromBody] User user) {             
            var message = VerifyUser(user);
            if (!string.IsNullOrWhiteSpace(message)) return BadRequest(message);

            user.UserId = Guid.NewGuid();
            _db.Users.Add(user);
            _db.SaveChanges();

            return Ok();
        }

        // PUT api/values/5
        [HttpPut ("{id}")]
        public void Put (int id, [FromBody] string value) { }

        // DELETE api/values/5
        [HttpDelete ("{id}")]
        public void Delete (int id) { }

        [HttpGet] 
        [Route("login")]
        public ActionResult Login(string userName, string password)
        {
            var cekUser = _db.Users.SingleOrDefault(x=>x.userName == userName && x.password == password);
            if (cekUser == null)  return BadRequest();
            
            return Ok(cekUser);            
        }
        

        [NonAction]
        public string VerifyUser (User user){
            var message = "";

            if (_db.Users.Any(x=>x.userName == user.userName)) 
                message+= "Username sudah sudah pernah dipakai! \n";

            if (user.password != user.confirmPassword) 
                message+= "Password tidak sama";

            return message;
        }
    }
}