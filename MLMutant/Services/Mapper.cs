namespace MLMutant.Services
{
    public class Mapper : IMapper
    {
        private readonly IMutantDetectorService _mutantDetectorService;
        public Mapper(IMutantDetectorService mutantDetectorService)
        {
            _mutantDetectorService = mutantDetectorService ?? throw new ArgumentNullException(nameof(mutantDetectorService));
        }
        public MLMutant.Models.Mutant convert(MLMutant.Models.ApiModels.Mutant mutant)
        {
            MLMutant.Models.Mutant newMutant = new MLMutant.Models.Mutant
            {
                Id = Guid.NewGuid().ToString(),
                DNA = mutant.DNA,
                IsMutant = _mutantDetectorService.IsMutant(mutant.DNA)
            };
            return newMutant;
        }
    }
}