namespace TPR_task
{
    public class DefectiveSwitchData
    {
        public double OneProcentProbability { get; }
        public double TwoProcentProbability { get; }
        public double ThreeProcentProbability { get; }

        public DefectiveSwitchData( double oneProcentProbability, double twoProcentProbability, double threeProcentProbability )
        {
            OneProcentProbability = oneProcentProbability;
            TwoProcentProbability = twoProcentProbability;
            ThreeProcentProbability = threeProcentProbability;
        }
    }
}
