using Microsoft.Extensions.DependencyInjection;
using MLMutant.Services;
using Xunit;

namespace MlTest
{
    public class MutantDetectorServiceTest
    {
        private readonly IMutantDetectorService _mutantDetectorService;
        public MutantDetectorServiceTest()
        {
            var services = new ServiceCollection();
            services.AddSingleton<IMutantDetectorService, MutantDetectorService>();
            var serviceProvider = services.BuildServiceProvider();
            _mutantDetectorService = serviceProvider.GetService<IMutantDetectorService>();
        }
        [Fact]
        public void IsNotMutant()
        {
            string[] DNA = { "ATGCGA", "CAGTGC", "TTATTT", "AGACGG", "GCGTCA", "TCACTG" };
            bool IsMutant = _mutantDetectorService.IsMutant(DNA);
            Assert.False(IsMutant);
        }
        [Fact]
        public void IsMutant()
        {
            string[] DNA = { "ATGCGA", "CAGTGC", "TTATGT", "AGAAGG", "CCCCTA", "TCACTG" };
            bool IsMutant = _mutantDetectorService.IsMutant(DNA);
            Assert.True(IsMutant);
        }
    }
}