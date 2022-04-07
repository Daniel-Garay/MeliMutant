using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.Model;
using Amazon.Runtime;
using Amazon.Runtime.CredentialManagement;
using MLMutant.Models;
namespace MLMutant.Services
{
    public class DynamoDB : IDynamoDB
    {
        private DynamoDBContext context;
        private AmazonDynamoDBClient client;
        public DynamoDB()
        {
            string accessKey = Environment.GetEnvironmentVariable("accessKey");
            string secretKey = Environment.GetEnvironmentVariable("secretKey");

            var credentials = new BasicAWSCredentials(accessKey, secretKey);
            var config = new AmazonDynamoDBConfig()
            {
                RegionEndpoint = RegionEndpoint.SAEast1
            };
            client = new AmazonDynamoDBClient(credentials, config);
            context = new DynamoDBContext(client);
        }
        public async void CreateMutant(Mutant mutant)
        {
            await context.SaveAsync(mutant);
        }
        public async Task<MLMutant.Models.ApiModels.Stats> GetMutantStats()
        {
            Stats Mutant = await context.LoadAsync<Stats>("Mutant");
            Stats Human = await context.LoadAsync<Stats>("Human");

            return new MLMutant.Models.ApiModels.Stats
            {
                count_human_dna = Human.Quantity,
                count_mutant_dna = Mutant.Quantity,
                ratio = (decimal)Mutant.Quantity / (decimal)Human.Quantity,
            };
        }
        public async void UpdateStats(bool isMutant)
        {
            UpdateItemRequest updateRequest = new UpdateItemRequest()
            {
                TableName = "Stats",
                Key = new Dictionary<string, AttributeValue>
                {
                    { "Id", new AttributeValue { S = isMutant ? "Mutant" : "Human" } },
                },
                ExpressionAttributeValues = new Dictionary<string, AttributeValue>
                {
                    { ":incr", new AttributeValue { N = "1" } }
                },
                UpdateExpression = "SET Quantity = Quantity + :incr",
                ReturnValues = "NONE"
            };
            await client.UpdateItemAsync(updateRequest);
        }
    }
}