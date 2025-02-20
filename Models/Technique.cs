﻿using Amazon.DynamoDBv2.DataModel;

namespace bjj_encyclopedia_api.Models
{
    [DynamoDBTable("BjjTechniques")]
    public class Technique
    {
        [DynamoDBHashKey("Id")]
        public string? Id { get; set; }

        [DynamoDBGlobalSecondaryIndexHashKey("Created")]
        public string? Created { get; set; }

        [DynamoDBProperty("Coach")]
        public string? Coach { get; set; }

        [DynamoDBProperty("Description")]
        public string? Description { get; set; }

        [DynamoDBProperty("Name")]
        public string? Name { get; set; }

        [DynamoDBProperty("Tags")]
        public List<string>? Tags { get; set; }

        [DynamoDBProperty("Attempts")]
        public List<TechnniqueAttempt>? Attempts { get; set; }
    }

    public class TechnniqueAttempt
    {
        public bool IsSuccessful { get; set; }
        public string? Notes { get; set; }
        public string? Created { get; set; }
    }
}
