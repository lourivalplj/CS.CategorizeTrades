using CS.CategorizeTrades.Risks;
using CS.CategorizeTrades.Trades;
using System.Collections.Generic;

namespace CategorizeTrades.Categories
{
    public class Category
    {
        public static List<string> CalculateRisk(List<Trade> portoflio)
        {
            List<string> tradeCategories = new List<string>();

            foreach(Trade trade in portoflio)
            {
                if (trade.ClientSector.ToUpper() == "PUBLIC")
                {
                    if (trade.Value > 1000000)
                    {
                        var returnRisk = Risks.MediumRisk;
                        tradeCategories.Add(returnRisk.ToString());
                    }
                    else 
                    {
                        var returnRisk = Risks.LowRisk;
                        tradeCategories.Add(returnRisk.ToString());
                    }
                }
                else if (trade.ClientSector.ToUpper() == "PRIVATE")
                { 
                    if (trade.Value > 1000000)
                    {
                        var returnRisk = Risks.Highrisk;
                        tradeCategories.Add(returnRisk.ToString());
                    }
                }

            }

            return tradeCategories;

        }   


    }
}
