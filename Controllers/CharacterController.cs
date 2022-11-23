using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_rpg.Services.CharacterService;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_rpg.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {   
        private readonly ICharacterService characterService;
        public CharacterController(ICharacterService characterService)
        {
            this.characterService = characterService;
            
        }
        [HttpGet]
        [Route("GetAll")] //instead of route we could have directly used [HttpGet("GetAll)] would have worked fine
        public ActionResult<List<Character>> Get()
        {
            return Ok(this.characterService.GetAllCharacters());
        }
        //we want now a single character from the list
        [HttpGet("{id}")]
        public ActionResult<Character> GetSingle(int id)
        {
            return Ok(this.characterService.GetCharacterById(id));
        }
        [HttpPost]
        public ActionResult<List<Character>> AddCharacter(Character newCharacter)
        {
            return Ok(this.characterService.AddCharacter(newCharacter));
        }
    }
}