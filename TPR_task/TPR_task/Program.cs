using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using TPR_task.ProviderExpenses;

namespace TPR_task
{
    public class Program
    {
        public static void Main( string[] args )
        {
            int switchAmount = Convert.ToInt32( ConfigurationManager.AppSettings[ "SwitchAmount" ] );
            double repairCost = Convert.ToDouble( ConfigurationManager.AppSettings[ "RepairCost" ] );
            string switchDataFilePath = ConfigurationManager.AppSettings[ "SwitchDataFilePath" ];

            var providerExpenseCalculator = new ProviderExpenseCalculator( switchAmount, repairCost );
            var defectiveSwitchDataReader = new DefectiveSwitchDataReader();
            var defectiveSwitchDatas = defectiveSwitchDataReader.Read( switchDataFilePath );
            var providerExpenses = new List<ProviderExpense>();

            foreach ( var defectiveSwitchData in defectiveSwitchDatas )
            {
                Console.WriteLine( $"Расчитываем расходы с поставщиком: {defectiveSwitchData.ProvviderIndex}" );
                var providerExpense = providerExpenseCalculator.Calculate( defectiveSwitchData );
                
                Console.WriteLine( $"Вероятность брака детали по формуле полной вероятности: {providerExpense.ProbabilityOfDefective}" );
                Console.WriteLine( $"Вероятное количестов бракованных деталей: {providerExpense.DefectiveSwitchAmount}" );
                Console.WriteLine( $"Стоимость ремонта бракованных деталей: {providerExpense.RepairCost}, скидка поставщика: {defectiveSwitchData.ProviderDiscount}, расходы с данным поставщиком: {providerExpense.Expense}" );

                providerExpenses.Add( providerExpense );

                Console.WriteLine();
            }

            double minExpense = providerExpenses.Min( e => e.Expense );
            var recommendedProvider = providerExpenses.FirstOrDefault( item => item.Expense == minExpense );
            Console.WriteLine( $"Рекомендуемый поставщик: {recommendedProvider.ProviderIndex} с расходами: {recommendedProvider.Expense}" );
        }
    }
}
