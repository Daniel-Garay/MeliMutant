using MLMutant.Models;
namespace MLMutant.Services
{
    public class MutantDetectorService : IMutantDetectorService
    {
        private readonly Dictionary<string, int> _shoppingListStorage = new Dictionary<string, int>();


        public bool IsMutant(string[] dna)
        {
            int totalDna = 0;
            for (int i = 0; i < dna.Length; i++)
            {
                for (int j = 0; j < dna[i].Length; j++)
                {

                    // Control Horizontal
                    if (j < dna[i].Length - 3)
                    {
                        if (isEqual(dna[i][j], dna[i][j + 1], dna[i][j + 2], dna[i][j + 3]))
                        {
                            totalDna++;
                        }
                    }
                    // Control Vertical
                    if (i < dna.Length - 3)
                    {
                        // vertical check
                        if (isEqual(dna[i][j], dna[i + 1][j], dna[i + 2][j], dna[i + 3][j]))
                        {
                            totalDna++;
                        }
                    }

                    //Control Diagonal
                    if (i < dna.Length - 3 && j < dna[i].Length - 3)
                    {
                        if (isEqual(dna[i][j], dna[i + 1][j + 1], dna[i + 2][j + 2], dna[i + 3][j + 3]))
                        {
                            totalDna++;
                        }
                    }

                    //Control Diagonal Invertido
                    if (i >= 3 && j < dna[i].Length - 3)
                    {
                        if (isEqual(dna[i][j], dna[i - 1][j + 1], dna[i - 2][j + 2], dna[i - 3][j + 3]))
                        {
                            totalDna++;
                        }
                    }

                    if (totalDna > 1)
                    {
                        return true;
                    }

                }

            }

            return false;
        }

        public bool isEqual(char a, char b, char c, char d)
        {
            return a == b && b == c && c == d;
        }
    }
}
