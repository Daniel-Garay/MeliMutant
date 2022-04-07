using Amazon.DynamoDBv2.DataModel;
namespace MLMutant.Models.ApiModels
{
    /// <summary>
    /// This class represents a mutant for the request API
    /// </summary>
    public class Mutant
    {
        public string[] DNA { get; set; }
    }
}