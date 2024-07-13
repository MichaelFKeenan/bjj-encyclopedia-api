namespace bjj_encyclopedia_api.Models
{
    public class TechniqueRequest
    {
        public string? Coach { get; set; }
        public string? Description { get; set; }
        public string? Name { get; set; }
        public List<string>? Tags { get; set; }
    }
}
