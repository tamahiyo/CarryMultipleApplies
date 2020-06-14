using CarryMultipleAppliesWPF.ViewModels.Common;
using System.Collections.Generic;

namespace CarryMultipleAppliesWPF.ViewModels
{
    public class StoreEventGrid
    {
        public StoreEventGrid()
        {
            StoreEvent = new List<ComboBoxSet>();
        }

        public List<ComboBoxSet> StoreEvent { get; set; }

        public string SerialNo { get; set; }

    }
}
