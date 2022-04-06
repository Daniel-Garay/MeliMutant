using Microsoft.Extensions.DependencyInjection;
using MLMutant.Services;
using System;
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
        public void IsHuman()
        {
            string[] DNA = { "ATGCGA", "CAGTGC", "TTATTT", "AGACGG", "GCGTCA", "TCACTG" };
            Assert.False(_mutantDetectorService.IsMutant(DNA));
        }
        [Fact]
        public void IsMutant()
        {
            string[] DNA = { "ATGCGA", "CAGTGC", "TTATGT", "AGAAGG", "CCCCTA", "TCACTG" };
            Assert.True(_mutantDetectorService.IsMutant(DNA));
        }

        [Fact]
        public void EmptyArray()
        {
            string[] DNA = { };
            Assert.False(_mutantDetectorService.IsMutant(DNA));
        }

        [Fact]
        public void NullArray()
        {
            string[] DNA = null;
            Assert.Throws<ArgumentNullException>(() => _mutantDetectorService.IsMutant(DNA));
        }

        [Fact]
        public void BadArraySize()
        {
            string[] DNA = { "ATGCG", "CAGTGC", "TTATGT", "AGAAGG", "CCCCTA", "TCACTG" };
            Assert.Throws<ArgumentException>(() => _mutantDetectorService.IsMutant(DNA));
        }
    }
}