using CS.CategorizeTrades.Interfaces;
using System;

namespace CS.CategorizeTrades.Trades
{
    public class Trade : ITrade
    {    
        public readonly string _name; 
        public double Value { get; set; }
        public string ClientSector { get; set; }
        public Trade()
        {
        
            _name = "Trade" + Guid.NewGuid();    
        }
    
        public Trade(string name)
        {
            _name = name;
        }

    }
}
