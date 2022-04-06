using Amazon.DynamoDBv2.DataModel;
namespace MLMutant.Models
{
    [DynamoDBTable("Mutant")]
    public class Mutant
    {
        [DynamoDBHashKey]
        public string Id
        {
            get; set;
        }
        [DynamoDBProperty]
        public string[] DNA { get; set; }

        [DynamoDBProperty]
        public bool IsMutant { get; set; }
    }
}