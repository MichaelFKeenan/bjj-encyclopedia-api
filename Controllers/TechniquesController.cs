using Microsoft.AspNetCore.Mvc;
using Amazon.DynamoDBv2.DataModel;
using bjj_encyclopedia_api.Models;

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
        public async Task<IEnumerable<Technique>> Get()
        {
            try
            {

                var techniques = await _context.ScanAsync<Technique>(default).GetRemainingAsync();
                return techniques;
            }
            catch (Exception e)
            {

                throw;
            }
        }

        [HttpPost(Name = "CreateTechnique")]
        public async Task AddItem(TechniqueRequest techniqueRequest)
        {
            try
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
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
