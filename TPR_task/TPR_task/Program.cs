using System;

namespace TPR_task
{
    public class Program
    {
        private const int SWITCH_AMOUNT = 10000;
        private const double REPAIR_COST = 500;

        public static void Main( string[] args )
        {
            var providerADefectiveData = new DefectiveSwitchData( 0.7, 0.2, 0.1 );
            var providerBDefectiveData = new DefectiveSwitchData( 0.3, 0.4, 0.3 );

            double providerAExpenses = CalculateProviderExpenses( providerADefectiveData );
            double providerBExpenses = CalculateProviderExpenses( providerBDefectiveData, 37000 );

            Console.WriteLine( $"Расходы у поставщика А: {providerAExpenses}" );
            Console.WriteLine( $"Расходы у поставщика В: {providerBExpenses}" );
        }

        private static double CalculateProviderExpenses( DefectiveSwitchData defectiveSwitchData, double providerDiscount = 0 )
        {
            double fullProbabilityOfDefective = defectiveSwitchData.OneProcentProbability * 0.01
                + defectiveSwitchData.TwoProcentProbability * 0.02
                + defectiveSwitchData.ThreeProcentProbability * 0.03;

            int defectiveSwitchAmount = ( int )( SWITCH_AMOUNT * fullProbabilityOfDefective );
            return defectiveSwitchAmount * 500 - providerDiscount;
        }
    }
}
