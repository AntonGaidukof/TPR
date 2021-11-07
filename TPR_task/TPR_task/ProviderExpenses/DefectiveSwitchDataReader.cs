using System;
using System.Collections.Generic;
using System.IO;

namespace TPR_task.ProviderExpenses
{
    public class DefectiveSwitchDataReader
    {
        public IReadOnlyList<DefectiveSwitchData> Read( string filePath )
        {
            var result = new List<DefectiveSwitchData>();
            int providerIndex = 1;
            using ( StreamReader fstream = new StreamReader( filePath ) )
            {
                while ( !fstream.EndOfStream )
                {
                    string switchDataStr = fstream.ReadLine();
                    var switchData = ConvertStringToData( switchDataStr , providerIndex );

                    result.Add( switchData );
                    ++providerIndex;
                }
            }

            return result;
        }

        private DefectiveSwitchData ConvertStringToData( string switchDataStr, int providerIndex )
        {
            string[] switchDataArr = switchDataStr.Replace( '.', ',' ).Split( ' ' );

            double oneProcentProbability = Convert.ToDouble( switchDataArr[ 0 ] );
            double twoProcentProbability = Convert.ToDouble( switchDataArr[ 1 ] );
            double threeProcentProbability = Convert.ToDouble( switchDataArr[ 2 ] );
            double? providerDiscount = switchDataArr.Length == 4 ? Convert.ToDouble( switchDataArr[ 3 ] ) : null;

            return new DefectiveSwitchData
            {
                OneProcentProbability = oneProcentProbability,
                TwoProcentProbability = twoProcentProbability,
                ThreeProcentProbability = threeProcentProbability,
                ProviderDiscount = providerDiscount ?? 0,
                ProvviderIndex = providerIndex
            };
        }
    }
}
