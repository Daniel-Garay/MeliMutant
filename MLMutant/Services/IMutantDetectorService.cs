using MLMutant.Models;
namespace MLMutant.Services
{
    /// <summary>
    ///  Interface to access  MutantDetectorService
    /// </summary>
    public interface IMutantDetectorService
    {
        bool IsMutant(string[] dna);
    }
}