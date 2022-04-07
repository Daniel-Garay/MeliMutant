using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;
using Xunit;

namespace MlTest
{
    /// <summary>
    /// This test check possible  status codes the EndPoint
    /// </summary>
    public class functionalTest
    {

        /// <summary>
        /// Check that a mutant can be saved, with functional test
        /// </summary>
        [Fact]
        public async void CreateFunctionalMutant()
        {
            await using var application = new WebApplicationFactory<MLMutant.Startup>();
            using var client = application.CreateClient();

            var responseStatsInitial = await client.GetAsync("/stats");
            string responseBodyInitial = await responseStatsInitial.Content.ReadAsStringAsync();
            var statsInital = JsonConvert.DeserializeObject<MLMutant.Models.ApiModels.Stats>(responseBodyInitial);

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

            var responseStatsFinal = await client.GetAsync("/stats");
            string responseBodyFinal = await responseStatsInitial.Content.ReadAsStringAsync();
            var statsFinal = JsonConvert.DeserializeObject<MLMutant.Models.ApiModels.Stats>(responseBodyFinal);


            Assert.Equal(statsFinal.count_mutant_dna, statsInital.count_mutant_dna++);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(HttpStatusCode.OK, responseStatsFinal.StatusCode);
            Assert.Equal(HttpStatusCode.OK, responseStatsInitial.StatusCode);
        }


        /// <summary>
        /// Check that a human can be saved with status code 403, with functional test
        /// </summary>
        [Fact]
        public async void CreateFunctionalHuman()
        {

            await using var application = new WebApplicationFactory<MLMutant.Startup>();
            using var client = application.CreateClient();

            var responseStatsInitial = await client.GetAsync("/stats");
            string responseBodyInitial = await responseStatsInitial.Content.ReadAsStringAsync();
            var statsInital = JsonConvert.DeserializeObject<MLMutant.Models.ApiModels.Stats>(responseBodyInitial);

            var mutant = new
            {
                DNA = new[] { "ATGCGA", "CAGTGC", "TTATTT", "AGACGG", "GCGTCA", "TCACTG" }
            };

            var response = await client.PostAsync("/mutant"
                , new StringContent(
                                     JsonConvert.SerializeObject(mutant),
                                    Encoding.UTF8,
                                    "application/json"
                                    ));

            var responseStatsFinal = await client.GetAsync("/stats");
            string responseBodyFinal = await responseStatsInitial.Content.ReadAsStringAsync();
            var statsFinal = JsonConvert.DeserializeObject<MLMutant.Models.ApiModels.Stats>(responseBodyFinal);


            Assert.Equal(statsFinal.count_mutant_dna, statsInital.count_mutant_dna++);
            Assert.Equal(HttpStatusCode.Forbidden, response.StatusCode);
            Assert.Equal(HttpStatusCode.OK, responseStatsFinal.StatusCode);
            Assert.Equal(HttpStatusCode.OK, responseStatsInitial.StatusCode);
        }

    }
}