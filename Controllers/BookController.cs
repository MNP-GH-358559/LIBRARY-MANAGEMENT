using MAchineTest.Data;
using MAchineTest.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MAchineTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {

        private readonly ApplicationDbContext dbContext;
        public BookController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult Allregcus()
        {
            var objuser = dbContext.books.ToList();
            return Ok(objuser);
        }
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult Registercusbyid(int id)

        {
            var objuser1 = dbContext.books.Find(id);
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
        public IActionResult Resgisternow(Book newregistrationdto)
        {
            var objuser2 = dbContext.books.FirstOrDefault(x => x.Authorid == newregistrationdto.Authorid);
            if (objuser2 == null)
            {
                dbContext.books.Add(new Book

                {
                    Title = newregistrationdto.Title,
                    Description = newregistrationdto.Description,
                    Publitionyear = newregistrationdto.Publitionyear,
                    Authorid = newregistrationdto.Authorid,
                    Categoryid = newregistrationdto.Categoryid,

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
