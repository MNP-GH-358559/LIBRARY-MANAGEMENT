using MAchineTest.Data;
using MAchineTest.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MAchineTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatogoryController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public CatogoryController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult Allregcus()
        {
            var objuser = dbContext.categories.ToList();
            return Ok(objuser);
        }
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult Registercusbyid(int id)

        {
            var objuser1 = dbContext.categories.Find(id);
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
        public IActionResult Resgisternow(Category newregistrationdto)
        {
            var objuser2 = dbContext.categories.FirstOrDefault(x => x.Name == newregistrationdto.Name);
            if (objuser2 == null)
            {
                dbContext.categories.Add(new Category

                {
                    Name = newregistrationdto.Name,
                    Description = newregistrationdto.Description,
                   
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
