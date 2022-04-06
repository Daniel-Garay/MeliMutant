using MLMutant.Models;
namespace MLMutant.Services
{
    public interface IMutantDetectorService
    {
        bool IsMutant(string[] dna);
    }
}