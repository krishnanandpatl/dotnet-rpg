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
        public async Task<ActionResult<ServiceResponse<List<Character>>>> Get()
        {
            return Ok(await this.characterService.GetAllCharacters());
        }
        //we want now a single character from the list
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Character>>> GetSingle(int id)
        {
            return Ok(await this.characterService.GetCharacterById(id));
        }
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<Character>>>> AddCharacter(Character newCharacter)
        {
            return Ok(await this.characterService.AddCharacter(newCharacter));
        }
    }
}