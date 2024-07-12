using Microsoft.AspNetCore.Mvc;
using Amazon.DynamoDBv2.DataModel;
using bjj_encyclopedia_api.Models;
using System.Web;

namespace bjj_encyclopedia_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TechniquesController : ControllerBase
    {
        private readonly IDynamoDBContext _context;

        public TechniquesController(IDynamoDBContext context)
        {
            _context = context;
        }

        [HttpGet(Name = "GetTechniques")]
        public async Task<IActionResult> GetTechniques()
        {
            var techniques = await _context.ScanAsync<Technique>(default).GetRemainingAsync();
            return Ok(techniques);
        }

        [HttpPost(Name = "CreateTechnique")]
        public async Task<IActionResult> CreateTechnique(TechniqueRequest techniqueRequest)
        {
            var request = new Technique
            {
                Id = Guid.NewGuid().ToString(),
                Created = DateTime.Now.ToString(),
                Name = techniqueRequest.Name,
                Coach = techniqueRequest.Coach,
                Description = techniqueRequest.Description,
                Tags = techniqueRequest.Tags,
            };

            await _context.SaveAsync(request);

            return Ok(techniqueRequest);
        }

        [HttpPut(Name = "EditTechnique")]
        public async Task<IActionResult> EditTechnique(Technique technique)
        {
            var request = new Technique
            {
                Id = technique.Id,
                Created = technique.Created,
                Name = technique.Name,
                Coach = technique.Coach,
                Description = technique.Description,
                Tags = technique.Tags,
            };

            await _context.SaveAsync(request);

            return Ok(technique);
        }

        [HttpDelete("{id}/{created}")]
        public async Task<IActionResult> DeleteTechnique(string id, string created)
        {
            try
            {
                var technique = await _context.LoadAsync<Technique>(id, HttpUtility.UrlDecode(created));

                await _context.DeleteAsync(technique);

                return NoContent();
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
