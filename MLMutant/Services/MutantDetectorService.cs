using MLMutant.Models;
namespace MLMutant.Services
{
    public class MutantDetectorService : IMutantDetectorService
    {
        public bool IsMutant(string[] dna)
        {
            if (dna == null)
                throw new ArgumentNullException(nameof(dna));

            int counterDna = 0;
            for (int i = 0; i < dna.Length; i++)
            {
                if (dna[i].Length != dna.Length)
                    throw new ArgumentException("El arreglo enviado no es un arreglo de NxN", nameof(dna));

                for (int j = 0; j < dna[i].Length; j++)
                {
                    // Verificar Horizontal
                    if (j < dna[i].Length - 3)
                    {
                        if (dna[i][j] == dna[i][j + 1] &&
                             dna[i][j + 1] == dna[i][j + 2] &&
                             dna[i][j + 2] == dna[i][j + 3])
                        {
                            counterDna++;
                        }
                    }
                    // Verificar Vertical
                    if (i < dna.Length - 3)
                    {
                        // vertical check
                        if (
                            dna[i][j] == dna[i + 1][j] &&
                            dna[i + 1][j] == dna[i + 2][j] &&
                             dna[i + 2][j] == dna[i + 3][j])
                        {
                            counterDna++;
                        }
                    }
                    //Verificar Diagonal
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
                    //Verificar Diagonal Invertido
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