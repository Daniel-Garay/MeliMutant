using Microsoft.Extensions.DependencyInjection;
using MLMutant.Services;
using System;
using Xunit;

namespace MlTest
{
    /// <summary>
    /// This test check possible  response the interface MutantDetectorService
    /// </summary>
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
        /// <summary>
        /// Verify that it is human, return false
        /// </summary>
        [Fact]
        public void IsHuman()
        {
            string[] DNA = { "ATGCGA", "CAGTGC", "TTATTT", "AGACGG", "GCGTCA", "TCACTG" };
            Assert.False(_mutantDetectorService.IsMutant(DNA));
        }
        /// <summary>
        /// Verify that it is mutant, return true
        /// </summary>
        [Fact]
        public void IsMutant()
        {
            string[] DNA = { "ATGCGA", "CAGTGC", "TTATGT", "AGAAGG", "CCCCTA", "TCACTG" };
            Assert.True(_mutantDetectorService.IsMutant(DNA));
        }
        /// <summary>
        /// Verify that it is array Empty, return false
        /// </summary>
        [Fact]
        public void EmptyArray()
        {
            string[] DNA = { };
            Assert.False(_mutantDetectorService.IsMutant(DNA));
        }

        /// <summary>
        /// Verify that it is null, return execption ArgumentNullException
        /// </summary>
        [Fact]
        public void NullArray()
        {
            string[] DNA = null;
            Assert.Throws<ArgumentNullException>(() => _mutantDetectorService.IsMutant(DNA));
        }

        /// <summary>
        /// Verify that it is array wrong size, return execption ArgumentException
        /// </summary>
        [Fact]
        public void BadArraySize()
        {
            string[] DNA = { "ATGCG", "CAGTGC", "TTATGT", "AGAAGG", "CCCCTA", "TCACTG" };
            Assert.Throws<ArgumentException>(() => _mutantDetectorService.IsMutant(DNA));
        }
    }
}