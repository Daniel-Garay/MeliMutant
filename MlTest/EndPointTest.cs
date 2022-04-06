using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;
using Xunit;

namespace MlTest
{
    public class EndPointTest
    {
        [Fact]
        public async void GetStats()
        {
            await using var application = new WebApplicationFactory<MLMutant.Startup>();
            using var client = application.CreateClient();
            var response = await client.GetAsync("/stats");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async void CreateMutant()
        {
            await using var application = new WebApplicationFactory<MLMutant.Startup>();
            using var client = application.CreateClient();

            var mutant = new
            {
                DNA = new[] { "ATGCGA", "CAGTGC", "TTATGT", "AGAAGG", "CCCCTA", "TCACTG" }
            };

            var response = await client.PostAsync("/mutant"
                , new StringContent(
                                     JsonConvert.SerializeObject(mutant),
                                    Encoding.UTF8,
                                    "application/json"
                                    ));
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async void CreateHuman()
        {
            await using var application = new WebApplicationFactory<MLMutant.Startup>();
            using var client = application.CreateClient();

            var human = new
            {
                DNA = new[] { "ATGCGA", "CAGTGC", "TTATTT", "AGACGG", "GCGTCA", "TCACTG" }
            };

            var response = await client.PostAsync("/mutant"
                , new StringContent(
                                    JsonConvert.SerializeObject(human),
                                    Encoding.UTF8,
                                    "application/json"
                                    ));
            Assert.Equal(HttpStatusCode.Forbidden, response.StatusCode);
        }

        [Fact]
        public async void NullArray()
        {
            await using var application = new WebApplicationFactory<MLMutant.Startup>();
            using var client = application.CreateClient();

            string[] DNA = null;
            var human = new
            {
               DNA 
            };

            var response = await client.PostAsync("/mutant"
                , new StringContent(
                                    JsonConvert.SerializeObject(human),
                                    Encoding.UTF8,
                                    "application/json"
                                    ));
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async void EmpytDNA()
        {
            await using var application = new WebApplicationFactory<MLMutant.Startup>();
            using var client = application.CreateClient();

            string[] DNA = null;
            var human = new
            {               
            };

            var response = await client.PostAsync("/mutant"
                , new StringContent(
                                    JsonConvert.SerializeObject(human),
                                    Encoding.UTF8,
                                    "application/json"
                                    ));
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async void BadArraySize()
        {
            await using var application = new WebApplicationFactory<MLMutant.Startup>();
            using var client = application.CreateClient();

            var human = new
            {
                DNA = new[] { "ATGCG", "CAGTGC", "TTATTT", "AGACGG", "GCGTCA", "TCACTG" }
            };

            var response = await client.PostAsync("/mutant"
                , new StringContent(
                                    JsonConvert.SerializeObject(human),
                                    Encoding.UTF8,
                                    "application/json"
                                    ));
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}