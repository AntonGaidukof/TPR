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

            Console.WriteLine( "Расчитываем расходы с поставщиком A" );
            double providerAExpenses = CalculateProviderExpenses( providerADefectiveData );
            Console.WriteLine();

            Console.WriteLine( "Расчитываем расходы с поставщиком B" );
            double providerBExpenses = CalculateProviderExpenses( providerBDefectiveData, 37000 );
            Console.WriteLine();

            Console.WriteLine( $"Рекомендуемый поставщик: {( providerAExpenses > providerBExpenses ? "B" : "A" )}" );
        }

        private static double CalculateProviderExpenses( DefectiveSwitchData defectiveSwitchData, double providerDiscount = 0 )
        {
            double fullProbabilityOfDefective = defectiveSwitchData.OneProcentProbability * 0.01
                + defectiveSwitchData.TwoProcentProbability * 0.02
                + defectiveSwitchData.ThreeProcentProbability * 0.03;
            Console.WriteLine( $"Вероятность брака детали по формуле полной вероятности: {fullProbabilityOfDefective}" );

            int defectiveSwitchAmount = ( int )( SWITCH_AMOUNT * fullProbabilityOfDefective );
            Console.WriteLine( $"Вероятное количестов бракованных деталей: {defectiveSwitchAmount}" );

            double switchRepairCost = defectiveSwitchAmount * REPAIR_COST;
            double providerExpenses = switchRepairCost - providerDiscount;
            Console.WriteLine($"Стоимость ремонта бракованных деталей: {switchRepairCost}, скижка поставщика: {providerDiscount}, расходы с данным поставщиком: {providerExpenses}");

            return providerExpenses;
        }
    }
}
