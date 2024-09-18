using DotNetTask_PersonalInfo.DAO;
using DotNetTask_PersonalInfo.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNetTask_PersonalInfo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PeronalInfoController : ControllerBase
    {
        private readonly IPersonalinfo _personalinfo;
        public PeronalInfoController(IPersonalinfo personalinfo)
        {
            _personalinfo = personalinfo;
        }

        [HttpGet]
        public async Task<ActionResult<List<PersonalInformation>>> GetPersonalInfo()
        {
            var info = await _personalinfo.GetPersonalInfo();
            if (info == null)
            {
                return NotFound();
            }
            return Ok(info);
        }

        [HttpGet("{id:int}", Name = "GetInsertInfo")]
        public async Task<ActionResult<PersonalInformation>> GetInsertInfo(int id)
        {
            var info = await _personalinfo.GetInsertInfo(id);
            if (info == null)
            {
                return NotFound();
            }
            return Ok(info);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<int>> DeleteInfo(int id)
        {
            int res = await _personalinfo.DeleteInfo(id);
            if (res != 0) return Ok(id);
            else return NotFound($"Id {id} not found");
        }

        [HttpPost]
        public async Task<ActionResult<int>> InsertInfo(PersonalInformation info)
        {
            Console.WriteLine("Hey");
            Console.WriteLine(info.Name);
            //var rowAffected = await _personalinfo.InsertInfo(info);
            if (info != null)
            {
                if (ModelState.IsValid)
                {
                    int res = await _personalinfo.InsertInfo(info);
                    //if (res > 0)
                    //{
                    //    return CreatedAtRoute(nameof(GetInsertInfo), new { id = info.Id }, info);

                    //}
                    return Ok("Okkkk");
                }
                return BadRequest("Failed to add product");

            }

            else
            {
                return BadRequest();
            }

        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<int>> UpdateInfo(int id, [FromBody] string name)
        {
            int? row = null;
            row = await _personalinfo.UpdateInfo(id, name);
            if (row != null) return NoContent();
            else return NotFound($"Id {id} Not Found");
        }
    }
}
