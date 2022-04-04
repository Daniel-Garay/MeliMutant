using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using Amazon.Runtime;
namespace MLMutant.Services
{
    public class DynamoDB
    {

        public async void init() {
            // var credentials = new BasicAWSCredentials("accessKey", "secretKey");
            AmazonDynamoDBConfig clientConfig = new AmazonDynamoDBConfig();
            clientConfig.ServiceURL = "http://localhost:8000";
            //var client = new AmazonDynamoDBClient(credentials, RegionEndpoint.USEast1);
            var client = new AmazonDynamoDBClient(clientConfig);

            bool isTableAvailable = false;
            while (!isTableAvailable)
            {
                Thread.Sleep(5000);
                var tableStatus = await client.ListTablesAsync();
                string algo = "";
                //isTableAvailable = tableStatus.Table.TableStatus == "ACTIVE";
            }
        }
        
    }
}
