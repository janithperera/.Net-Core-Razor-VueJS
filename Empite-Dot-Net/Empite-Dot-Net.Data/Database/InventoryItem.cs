using System;
using System.Collections.Generic;

#nullable disable

namespace Empite_Dot_Net.Data.Database
{
    public partial class InventoryItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Qty { get; set; }
    }
}
