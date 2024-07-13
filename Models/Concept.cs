using Amazon.DynamoDBv2.DataModel;

namespace bjj_encyclopedia_api.Models
{
    [DynamoDBTable("BjjConcepts")]
    public class Concept
    {
        [DynamoDBHashKey("Id")]
        public string? Id { get; set; }

        [DynamoDBGlobalSecondaryIndexHashKey("Created")]
        public string? Created { get; set; }

        [DynamoDBProperty("Description")]
        public string? Description { get; set; }

        [DynamoDBProperty("Name")]
        public string? Name { get; set; }

        [DynamoDBProperty("Tags")]
        public List<string>? Tags { get; set; }
    }
}
