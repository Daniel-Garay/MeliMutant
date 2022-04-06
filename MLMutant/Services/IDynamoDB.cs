using MLMutant.Models;
namespace MLMutant.Services
{
    public interface IDynamoDB
    {
        public void CreateMutant(Mutant mutant);
        public Task<MLMutant.Models.ApiModels.Stats> GetMutantStats();
        public void UpdateStats(bool isMutant);
    }
}