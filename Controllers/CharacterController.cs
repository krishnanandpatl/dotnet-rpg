using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_rpg.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        private static List<Character> characters= new List<Character>{
            new Character(),
            new Character{Id=1,Name="Sam"}
        };
        [HttpGet]
        [Route("GetAll")] //instead of route we could have directly used [HttpGet("GetAll)] would have worked fine
        public ActionResult<List<Character>> Get()
        {
            return Ok(characters);
        }
        //we want now a single character from the list
        [HttpGet("{id}")]
        public ActionResult<Character> GetSingle(int id)
        {
            return Ok(characters.FirstOrDefault(c=>c.Id==id));
        }
    }
}