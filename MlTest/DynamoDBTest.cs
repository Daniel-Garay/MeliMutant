using Microsoft.Extensions.DependencyInjection;
using MLMutant.Services;
using System;
using Xunit;

namespace MlTest
{
    public class DynamoDBTest
    {
        private readonly IDynamoDB _dynamoDB;

        public DynamoDBTest()
        {
            var services = new ServiceCollection();
            services.AddSingleton<IDynamoDB, DynamoDB>();
            var serviceProvider = services.BuildServiceProvider();
            _dynamoDB = serviceProvider.GetService<IDynamoDB>();
        }

        [Fact]
        public void CreateMutant()
        {
            MLMutant.Models.Mutant mutant = new MLMutant.Models.Mutant
            {
                Id = Guid.NewGuid().ToString(),
                DNA = new string[] { "ATGCGA", "CAGTGC", "TTATTT", "AGACGG", "GCGTCA", "TCACTG" },
                IsMutant = true
            };
            _dynamoDB.CreateMutant(mutant);
        }
        [Fact]
        public void UpdateStats()
        {
            bool isMutant = true;
            _dynamoDB.UpdateStats(isMutant);
        }

        [Fact]
        public async void GetMutantStats()
        {
            MLMutant.Models.ApiModels.Stats stats = await _dynamoDB.GetMutantStats();
        }
    }
}