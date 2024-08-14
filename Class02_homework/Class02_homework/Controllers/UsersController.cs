using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Class02_homework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {


        [HttpGet("allUsers")] //http://localhost[port]/api/Users/allUsers
        public ActionResult<List<string>> GetAllUsers()
        {

            return Ok(StaticDb.Names);


        }

        [HttpGet("{index}")]  //http://localhost[port]/api/Users/1
        public ActionResult<string> GetUserByIndex(int index)
        {
            try
            {
                if(index < 0)
                {
                    return BadRequest($"There is no user with index {index}");
                }

                if (index >= StaticDb.Names.Count )
                {
                    return NotFound($"There is no user with index {index}");
                }

                return StaticDb.Names[index];   
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,ex.Message);

            }
        }


    }
}
