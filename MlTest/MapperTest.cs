using Microsoft.Extensions.DependencyInjection;
using MLMutant.Services;
using Xunit;

namespace MlTest
{
    public class MapperTest
    {
        private readonly IMapper _mapper;
        public MapperTest()
        {
            var services = new ServiceCollection();
            services.AddTransient<IMapper, Mapper>();
            services.AddTransient<IMutantDetectorService, MutantDetectorService>();
            var serviceProvider = services.BuildServiceProvider();
            _mapper = serviceProvider.GetService<IMapper>();
        }
        [Fact]
        public void convertMutant()
        {
            MLMutant.Models.ApiModels.Mutant mutant = new MLMutant.Models.ApiModels.Mutant
            {
                DNA = new string[] { "ATGCGA", "CAGTGC", "TTATTT", "AGACGG", "GCGTCA", "TCACTG" }
            };
            MLMutant.Models.Mutant Mutant = _mapper.convert(mutant);
        }
    }
}