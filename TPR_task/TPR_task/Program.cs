using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TPR_task
{
    public class Program
    {
        private const int SWITCH_AMOUNT = 10000;
        private const double REPAIR_COST = 500;

        public static void Main( string[] args )
        {
            Console.WriteLine( "Введите расположение файла с данными поставщиков" );
            string filePath = Console.ReadLine();

            var defectiveSwitchDatas = ReadDefectiveSwitchData( filePath );
            var providerExpenses = new Dictionary<int, double>();

            for ( int i = 0; i < defectiveSwitchDatas.Count; i++ )
            {
                Console.WriteLine( $"Расчитываем расходы с поставщиком: {i}" );
                providerExpenses.Add( i, CalculateProviderExpenses( defectiveSwitchDatas[ i ] ) );
                Console.WriteLine();
            }

            var recommendedProvider = providerExpenses.FirstOrDefault( item => item.Value == providerExpenses.Values.Min() );
            Console.WriteLine( $"Рекомендуемый поставщик: {recommendedProvider.Key} с расходами: {recommendedProvider.Value}" );
        }

        private static IReadOnlyList<DefectiveSwitchData> ReadDefectiveSwitchData( string filePath )
        {
            var result = new List<DefectiveSwitchData>();
            using ( StreamReader fstream = new StreamReader( filePath ) )
            {
                while ( !fstream.EndOfStream )
                {
                    string switchData = fstream.ReadLine();
                    string[] switchDataArr = switchData.Replace( '.', ',' ).Split( ' ' );

                    double oneProcentProbability = Convert.ToDouble( switchDataArr[ 0 ] );
                    double twoProcentProbability = Convert.ToDouble( switchDataArr[ 1 ] );
                    double threeProcentProbability = Convert.ToDouble( switchDataArr[ 2 ] );
                    double? providerDiscount = switchDataArr.Length == 4 ? Convert.ToDouble( switchDataArr[ 3 ] ) : null;

                    result.Add( new DefectiveSwitchData(
                        oneProcentProbability,
                        twoProcentProbability,
                        threeProcentProbability,
                        providerDiscount ) );
                }
            }

            return result;
        }

        private static double CalculateProviderExpenses( DefectiveSwitchData defectiveSwitchData )
        {
            double fullProbabilityOfDefective = defectiveSwitchData.OneProcentProbability * 0.01
                + defectiveSwitchData.TwoProcentProbability * 0.02
                + defectiveSwitchData.ThreeProcentProbability * 0.03;
            Console.WriteLine( $"Вероятность брака детали по формуле полной вероятности: {fullProbabilityOfDefective}" );

            int defectiveSwitchAmount = ( int )( SWITCH_AMOUNT * fullProbabilityOfDefective );
            Console.WriteLine( $"Вероятное количестов бракованных деталей: {defectiveSwitchAmount}" );

            double switchRepairCost = defectiveSwitchAmount * REPAIR_COST;
            double providerExpenses = switchRepairCost - defectiveSwitchData.ProviderDiscount;
            Console.WriteLine( $"Стоимость ремонта бракованных деталей: {switchRepairCost}, скидка поставщика: {defectiveSwitchData.ProviderDiscount}, расходы с данным поставщиком: {providerExpenses}" );

            return providerExpenses;
        }
    }
}
