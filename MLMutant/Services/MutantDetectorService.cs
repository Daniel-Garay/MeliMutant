using MLMutant.Models;
namespace MLMutant.Services
{
    /// <summary>
    /// This class detects a Mutant
    /// </summary>
    public class MutantDetectorService : IMutantDetectorService
    {
        /// <summary>
        /// This method detects a Mutant
        /// </summary>
        /// <param name="dna"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Applies if dna is null</exception>
        /// <exception cref="ArgumentException">Applies if dna is NxM</exception>
        public bool IsMutant(string[] dna)
        {
            if (dna == null)
                throw new ArgumentNullException(nameof(dna));

            int counterDna = 0;
            for (int i = 0; i < dna.Length; i++)
            {
                if (dna[i].Length != dna.Length)
                    throw new ArgumentException("The submitted array is not an NxN array", nameof(dna));

                for (int j = 0; j < dna[i].Length; j++)
                {
                    // Check Horizontal
                    if (j < dna[i].Length - 3)
                    {
                        if (dna[i][j] == dna[i][j + 1] &&
                             dna[i][j + 1] == dna[i][j + 2] &&
                             dna[i][j + 2] == dna[i][j + 3])
                        {
                            counterDna++;
                        }
                    }
                    // vertical check
                    if (i < dna.Length - 3)
                    {
                        if (
                            dna[i][j] == dna[i + 1][j] &&
                            dna[i + 1][j] == dna[i + 2][j] &&
                             dna[i + 2][j] == dna[i + 3][j])
                        {
                            counterDna++;
                        }
                    }
                    //Check  Diagonal
                    if (i < dna.Length - 3 && j < dna[i].Length - 3)
                    {
                        if (
                             dna[i][j] == dna[i + 1][j + 1] &&
                             dna[i + 1][j + 1] == dna[i + 2][j + 2] &&
                             dna[i + 2][j + 2] == dna[i + 3][j + 3])
                        {
                            counterDna++;
                        }
                    }
                    //Check Reversed Diagonal
                    if (i >= 3 && j < dna[i].Length - 3)
                    {
                        if (
                             dna[i][j] == dna[i - 1][j + 1] &&
                             dna[i - 1][j + 1] == dna[i - 2][j + 2] &&
                             dna[i - 2][j + 2] == dna[i - 3][j + 3]
                          )
                        {
                            counterDna++;
                        }
                    }
                    if (counterDna > 1)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}