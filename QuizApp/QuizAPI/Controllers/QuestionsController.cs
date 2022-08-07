using BussinessLogic.IRepository;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuizAPI.Controllers
{
    [Route("api/quesions")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IRepository<Questions> _groupRepository;
        public QuestionsController(IRepository<Questions> groupRepository)
        {
            _groupRepository = groupRepository;
        }
        [HttpPost]
        public async Task<ActionResult<IEnumerable<Questions>>> PostAsync([FromBody] Questions entity)
        {
            var result = await _groupRepository.CreateAsync(entity);
            return Created("~/api/quesions", new { id = result.Id, result.QnInWord });
        }

        [HttpGet]
        public async Task<IEnumerable<Questions>> GetQuestionsAsync()
        {
            return await _groupRepository.GetAllAsync();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<Questions> GetQuestionsAsynch([FromBody] Guid id)
        {
            return await _groupRepository.GetAsync(id);
        }

        [HttpPut]
        public async Task<Questions> UpdateAsync([FromBody] Questions entity)
        {
            var result = await _groupRepository.UpdateAsync(entity);
            return result;
        }

        [HttpDelete]
        [Route("{id}")]
        public NoContentResult Delete([FromRoute]Guid id)
        {
            _groupRepository.Delete(id);
            return NoContent();
        }
    }
}
