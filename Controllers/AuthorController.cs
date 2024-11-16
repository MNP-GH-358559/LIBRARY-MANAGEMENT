using MAchineTest.Data;
using MAchineTest.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MAchineTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public AuthorController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult Allregcus()
        {
            var objuser = dbContext.authers.ToList();
            return Ok(objuser);
        }
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult Registercusbyid(int id)

        {
            var objuser1 = dbContext.authers.Find(id);
            if (objuser1 == null)
            {
                return BadRequest(false);

            }
            else
            {
                return Ok(objuser1);
            }

        }
        [HttpPost]
        [Route("Insert")]
        public IActionResult Resgisternow(Auther newregistrationdto)
        {
            var objuser2 = dbContext.authers.FirstOrDefault(x => x.Name == newregistrationdto.Name);
            if (objuser2 == null)
            {
                dbContext.authers.Add(new Auther

                {
                    Name = newregistrationdto.Name,
                    Bio = newregistrationdto.Bio,

                });
                dbContext.SaveChanges();
                return Ok(true);
            }
            else
            {
                return BadRequest(false);
            }
        }
    }
}
