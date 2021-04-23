using System;
using System.Collections.Generic;
using System.Text;

namespace BitcoinPrice.Library
{
    public class BitCoinPrice : Entity
    {
        public virtual Time time { get; set; }
        public string disclaimer { get; set; }
        public string chartName { get; set; }
        public virtual Bpi bpi { get; set; }
    }
}
