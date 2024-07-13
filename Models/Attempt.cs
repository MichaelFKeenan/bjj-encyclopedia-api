using Amazon.DynamoDBv2.DataModel;

namespace bjj_encyclopedia_api.Models
{
    [DynamoDBTable("BjjAttempts")]
    public class Attempt
    {
        [DynamoDBHashKey("Id")]
        public string? Id { get; set; }

        [DynamoDBGlobalSecondaryIndexHashKey("Created")]
        public string? Created { get; set; }

        [DynamoDBProperty("IsSuccessful")]
        public bool? IsSuccessful { get; set; }

        [DynamoDBProperty("Thoughts")]
        public string? Thoughts { get; set; }

        [DynamoDBProperty("TechniqueId")]
        public string? TechniqueId { get; set; }
    }
}
