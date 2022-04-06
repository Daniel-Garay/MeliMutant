namespace MLMutant.Services
{
    public interface IMapper
    {
        public MLMutant.Models.Mutant convert(MLMutant.Models.ApiModels.Mutant mutant);
    }
}
