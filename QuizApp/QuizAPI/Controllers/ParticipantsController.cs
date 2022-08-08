using BussinessLogic.IRepository;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuizAPI.Controllers
{
    [Route("api/participants")]
    [ApiController]
    public class ParticipantsController : ControllerBase
    {
        private readonly IRepository<Participant> _participant;
        public ParticipantsController(IRepository<Participant> participant)
        {
            _participant = participant;
        }
        [HttpPost]
        public async Task<ActionResult<Participant>> CreateAsync([FromBody] Participant entity)
        {
            var result = await _participant.CreateAsync(entity);
            return Created("~/api/participants", new { id = result.Name, result.Email });
        }
        [HttpGet]
        public async Task<IEnumerable<Participant>> Gets()
        {
            return await _participant.GetAllAsync();
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<Participant> Get(Guid id)
        {
            return await _participant.GetAsync(id);
        }
        [HttpPut]
        public async Task<Participant> UpdateAsync(Participant entity)
        {
            var result = await _participant.UpdateAsync(entity);
            return result;
        }

        [HttpDelete]
        [Route("{id}")]
        public NoContentResult Delete([FromRoute] Guid id)
        {
            _participant.Delete(id);
            return NoContent();
        }
    }
}
