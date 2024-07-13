namespace bjj_encyclopedia_api.Models
{
    public class ConceptRequest
    {
        public string? Description { get; set; }
        public string? Name { get; set; }
        public List<string>? Tags { get; set; }
    }
}
