using Amazon.DynamoDBv2.DataModel;
namespace MLMutant.Models
{
    /// <summary>
    ///  This  class represents the statistics of DynamoD
    /// </summary>
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