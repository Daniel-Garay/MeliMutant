using MLMutant.Models;
namespace MLMutant.Services
{
    /// <summary>
    ///  Interface to access  DynamoDB
    /// </summary>
    public interface IDynamoDB
    {
        public void CreateMutant(Mutant mutant);
        public Task<MLMutant.Models.ApiModels.Stats> GetMutantStats();
        public void UpdateStats(bool isMutant);
    }
}