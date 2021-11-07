namespace TPR_task
{
    public class DefectiveSwitchData
    {
        public double OneProcentProbability { get; }
        public double TwoProcentProbability { get; }
        public double ThreeProcentProbability { get; }
        public double ProviderDiscount { get; }

        public DefectiveSwitchData( 
            double oneProcentProbability, 
            double twoProcentProbability, 
            double threeProcentProbability,
            double? providerDiscount = null )
        {
            OneProcentProbability = oneProcentProbability;
            TwoProcentProbability = twoProcentProbability;
            ThreeProcentProbability = threeProcentProbability;
            ProviderDiscount = providerDiscount ?? 0;
        }
    }
}
