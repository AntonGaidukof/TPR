namespace TPR_task
{
    public class ProbabilityCalculator
    {
        public double CalculateDefectiveProbability( DefectiveSwitchData defectiveSwitchData, int discount = 0 )
        {
            double fullProbability = defectiveSwitchData.OneProcentProbability * 0.01
                + defectiveSwitchData.TwoProcentProbability * 0.02
                + defectiveSwitchData.ThreeProcentProbability * 0.03;

            int defectiveSwitchAmount = ( int )( 10000 * fullProbability );
            return defectiveSwitchAmount * 500 - discount;
        }
    }
}
