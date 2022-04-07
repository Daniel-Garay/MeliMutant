namespace MLMutant.Services
{
    /// <summary>
    ///  Interface to access  Mapper
    /// </summary>
    public interface IMapper
    {
        public MLMutant.Models.Mutant convert(MLMutant.Models.ApiModels.Mutant mutant);
    }
}