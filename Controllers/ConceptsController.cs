using Microsoft.AspNetCore.Mvc;
using Amazon.DynamoDBv2.DataModel;
using bjj_encyclopedia_api.Models;
using System.Web;

namespace bjj_encyclopedia_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConceptsController : ControllerBase
    {
        private readonly IDynamoDBContext _context;

        public ConceptsController(IDynamoDBContext context)
        {
            _context = context;
        }

        [HttpGet(Name = "GetConcepts")]
        public async Task<IActionResult> GetConcept()
        {
            var concepts = await _context.ScanAsync<Concept>(default).GetRemainingAsync();
            return Ok(concepts);
        }

        [HttpPost(Name = "CreateConcept")]
        public async Task<IActionResult> CreateConcept(ConceptRequest conceptRequest)
        {
            var request = new Concept
            {
                Id = Guid.NewGuid().ToString(),
                Created = DateTime.Now.ToString(),
                Name = conceptRequest.Name,
                Description = conceptRequest.Description,
                Tags = conceptRequest.Tags,
            };

            await _context.SaveAsync(request);

            return Ok(conceptRequest);
        }

        [HttpPut(Name = "EditConcept")]
        public async Task<IActionResult> EditConcept(Concept concept)
        {
            var request = new Concept
            {
                Id = concept.Id,
                Created = concept.Created,
                Name = concept.Name,
                Description = concept.Description,
                Tags = concept.Tags,
            };

            await _context.SaveAsync(request);

            return Ok(concept);
        }

        [HttpDelete("{id}/{created}")]
        public async Task<IActionResult> DeleteConcept(string id, string created)
        {
            try
            {
                var concept = await _context.LoadAsync<Concept>(id, HttpUtility.UrlDecode(created));

                await _context.DeleteAsync(concept);

                return NoContent();
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
