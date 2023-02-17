using Microsoft.AspNetCore.Mvc;
using TanksAPI.Models;
using TanksAPI.Repositories;

namespace TanksAPI.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class TanksController : ControllerBase
    {
        private readonly ITanksRepository _tankRepository;

        public TanksController(ITanksRepository tankRepository)
        {
            _tankRepository = tankRepository;
        }
        [HttpGet]
        public async Task<IEnumerable<Tank>> GetTanks()
        {
            return await _tankRepository.Get();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Tank>> GetTanks(int id)
        {
            return await _tankRepository.Get(id);
        }
        [HttpPost]
        public async Task<ActionResult<Tank>> Create([FromBody]Tank tank)
        {
            var NewTank = await _tankRepository.Create(tank);
            return CreatedAtAction(nameof(GetTanks), new { id = NewTank.Id }, NewTank);
        }
        [HttpPut]
        public async Task<ActionResult<Tank>> PutTanks([FromBody]Tank tank, int id)
        {
            if(id != tank.Id)
                return BadRequest();
            await _tankRepository.Update(tank);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTanks(int id)
        {
            var DelTank = await _tankRepository.Get(id);
            if(DelTank.Id==null)
                return NotFound();
            await _tankRepository.Delete(DelTank.Id);
            return NoContent();
        }
    }
}
