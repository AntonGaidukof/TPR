namespace TPR_task.ProviderExpenses
{
    public class ProviderExpense
    {
        public int ProviderIndex { get; set; }
        public double ProbabilityOfDefective { get; set; }
        public double DefectiveSwitchAmount { get; set; }
        public double RepairCost { get; set; }
        public double Expense { get; set; }
    }
}
