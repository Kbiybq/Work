using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLApp.ViewModel
{
    public static class  PositionInPowerLineCollectionVM
    {

        /// <summary>
        /// Колекция позиций в ЛЭП
        /// </summary>
        public static ObservableCollection<ObservableCollection<PositionInPowerLineVM>> MultiCollectionPositionInPowerLine { get; set; } =
            new ObservableCollection<ObservableCollection<PositionInPowerLineVM>>();


        public static void FillPositionElementCollection()
        {
            //for(int i = 0; i<9; i++)
            {
                MultiCollectionPositionInPowerLine.Add(new ObservableCollection<PositionInPowerLineVM>());
            }
            for (int i=0; i<=6; i = i + 3)
            {
                MultiCollectionPositionInPowerLine[i].Add(new PositionInPowerLineVM("Buser", i+1, 1));
                MultiCollectionPositionInPowerLine[i + 1].Add(new PositionInPowerLineVM("LineDisconnector", i+2, 1));
                MultiCollectionPositionInPowerLine[i + 2].Add(new PositionInPowerLineVM("BypassDisconnector", i+3, 1));

                //MultiCollectionPositionInPowerLine[i].Add(new PositionInPowerLineVM("Buser", i+1, 1));
                //MultiCollectionPositionInPowerLine[i + 1].Add(new PositionInPowerLineVM("LineDisconnector", i+2, 1));
                //MultiCollectionPositionInPowerLine[i + 2].Add(new PositionInPowerLineVM("BypassDisconnector", i+3, 1));
                //MultiCollectionPositionInPowerLine[i].Add(new PositionInPowerLineVM("CT", i + 1, 2));
                //MultiCollectionPositionInPowerLine[i + 1].Add(new PositionInPowerLineVM("CT", i + 2, 2));
                //MultiCollectionPositionInPowerLine[i + 2].Add(new PositionInPowerLineVM("BypassBus", i + 3, 2));
                //MultiCollectionPositionInPowerLine[i].Add(new PositionInPowerLineVM("Reactor", i + 1, 3));
                //MultiCollectionPositionInPowerLine[i + 1].Add(new PositionInPowerLineVM("Switch", i + 2, 3));
                //MultiCollectionPositionInPowerLine[i + 2].Add(new PositionInPowerLineVM("BypassDisconnector", i + 3, 3));
                //MultiCollectionPositionInPowerLine[i].Add(new PositionInPowerLineVM("LineDisconnector", i + 1, 4));
                //MultiCollectionPositionInPowerLine[i + 1].Add(new PositionInPowerLineVM("CT", i + 2, 4));
                //MultiCollectionPositionInPowerLine[i + 2].Add(new PositionInPowerLineVM("CT", i + 3, 4));
                //MultiCollectionPositionInPowerLine[i].Add(new PositionInPowerLineVM("Leade", i + 1, 5));
                //MultiCollectionPositionInPowerLine[i + 1].Add(new PositionInPowerLineVM("BusDisconnector1", i + 2, 5));
                //MultiCollectionPositionInPowerLine[i + 2].Add(new PositionInPowerLineVM("BypassSwitch", i + 3, 5));
                //MultiCollectionPositionInPowerLine[i].Add(new PositionInPowerLineVM("HighFrequencyShield", i + 1, 6));
                //MultiCollectionPositionInPowerLine[i + 1].Add(new PositionInPowerLineVM("Bus1", i + 2, 6));
                //MultiCollectionPositionInPowerLine[i + 2].Add(new PositionInPowerLineVM("CT", i + 3, 6));
                //MultiCollectionPositionInPowerLine[i].Add(new PositionInPowerLineVM("ElectricalConductor1", i + 1, 7));
                //MultiCollectionPositionInPowerLine[i + 1].Add(new PositionInPowerLineVM("BusDisconnector2", i + 2, 7));
                //MultiCollectionPositionInPowerLine[i + 2].Add(new PositionInPowerLineVM("BusDisconnector1", i + 3, 7));
                //MultiCollectionPositionInPowerLine[i].Add(new PositionInPowerLineVM("ElectricalConductor2", i + 1, 8));
                //MultiCollectionPositionInPowerLine[i + 1].Add(new PositionInPowerLineVM("Bus2", i + 2, 8));
                //MultiCollectionPositionInPowerLine[i + 2].Add(new PositionInPowerLineVM("Bus1", i + 3, 8));
                //MultiCollectionPositionInPowerLine[i].Add(new PositionInPowerLineVM("ElectricalConductor3", i + 1, 9));
                //MultiCollectionPositionInPowerLine[i + 2].Add(new PositionInPowerLineVM("BusDisconnector2", i + 2, 9));
                //MultiCollectionPositionInPowerLine[i].Add(new PositionInPowerLineVM("ElectricalConductor4", i + 1, 10));
                //MultiCollectionPositionInPowerLine[i + 2].Add(new PositionInPowerLineVM("Bus2", i + 2, 10));
            }
        }
      
    }
}
