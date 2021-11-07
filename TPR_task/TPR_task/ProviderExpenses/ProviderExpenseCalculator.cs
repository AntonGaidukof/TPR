namespace TPR_task.ProviderExpenses
{
    public class ProviderExpenseCalculator
    {
        private readonly int _switchAmount;
        private readonly double _repairCost;

        public ProviderExpenseCalculator( int switchAmount, double repairCost )
        {
            _switchAmount = switchAmount;
            _repairCost = repairCost;
        }

        public ProviderExpense Calculate( DefectiveSwitchData defectiveSwitchData )
        {
            double fullProbabilityOfDefective = defectiveSwitchData.OneProcentProbability * 0.01
                + defectiveSwitchData.TwoProcentProbability * 0.02
                + defectiveSwitchData.ThreeProcentProbability * 0.03;
            int defectiveSwitchAmount = ( int )( _switchAmount * fullProbabilityOfDefective );
            double switchRepairCost = defectiveSwitchAmount * _repairCost;
            double providerExpense = switchRepairCost - defectiveSwitchData.ProviderDiscount;

            return new ProviderExpense
            {
                DefectiveSwitchAmount = defectiveSwitchAmount,
                ProbabilityOfDefective = fullProbabilityOfDefective,
                RepairCost = switchRepairCost,
                Expense = providerExpense,
                ProviderIndex = defectiveSwitchData.ProvviderIndex
            };
        }
    }
}
