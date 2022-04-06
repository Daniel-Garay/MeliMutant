using Amazon.DynamoDBv2.DataModel;
namespace MLMutant.Models
{
    [DynamoDBTable("Stats")]
    public class Stats
    {
        [DynamoDBHashKey]
        public string Id
        {
            get; set;
        }
        [DynamoDBProperty]
        public int Quantity { get; set; }
    }
}