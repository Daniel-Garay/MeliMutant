namespace MLMutant.Models.ApiModels
{
    /// <summary>
    ///  This class represents  Stats for the response API
    /// </summary>
    public class Stats
    {
        public int count_mutant_dna { get; set; }
        public int count_human_dna { get; set; }
        public decimal ratio { get; set; }
    }
}