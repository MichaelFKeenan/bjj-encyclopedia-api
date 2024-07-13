using Microsoft.AspNetCore.Mvc;
using Amazon.DynamoDBv2.DataModel;
using bjj_encyclopedia_api.Models;
using System.Web;

namespace bjj_encyclopedia_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AttemptsController : ControllerBase
    {
        private readonly IDynamoDBContext _context;

        public AttemptsController(IDynamoDBContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAttemptsByTechnique(string techniqueId)
        {
            //obviously find a better way to do this!
            var attempts = await _context.ScanAsync<Attempt>(default).GetRemainingAsync();
            var attemptsForTechnique = attempts.Where(x => x.TechniqueId == techniqueId);
            if (!attemptsForTechnique.Any())
            {
                return NotFound();
            }
            return Ok(attemptsForTechnique);
        }

        [HttpPost(Name = "CreateAttempt")]
        public async Task<IActionResult> CreateAttempt(AttemptRequest attemptRequest)
        {
            var request = new Attempt
            {
                Id = Guid.NewGuid().ToString(),
                Created = DateTime.Now.ToString(),
                IsSuccessful = attemptRequest.IsSuccessful,
                Thoughts = attemptRequest.Thoughts,
                TechniqueId = attemptRequest.TechniqueId
            };

            await _context.SaveAsync(request);

            return Ok(attemptRequest);
        }
    }
}
