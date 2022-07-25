using CategorizeTrades.Categories;
using CS.CategorizeTrades.Trades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CS.ClassifyTrades
{ 

    class Program
    { 
        static void Main(string[] args)
        {
            List<Trade> portfolio;
            List<string> tradeCategories;

            portfolio = new List<Trade>();
            

            Trade trade1 = new Trade();
            trade1.Value = 20000000;
            trade1.ClientSector = "Private";
            portfolio.Add(trade1);

            Trade trade2 = new Trade();
            trade2.Value = 400000;
            trade2.ClientSector = "Public";
            portfolio.Add(trade2);

            Trade trade3 = new Trade();
            trade3.Value = 500000;
            trade3.ClientSector = "Public";
            portfolio.Add(trade3);

            Trade trade4 = new Trade();
            trade4.Value = 3000000;
            trade4.ClientSector = "Public";
            portfolio.Add(trade4);

            tradeCategories = Category.CalculateRisk(portfolio);

            
            Console.WriteLine("Input:");
            portfolio.ForEach(trade =>
            {
                Console.WriteLine($"{trade._name} = {{Value = {trade.Value}, ClientSector = \"{trade.ClientSector}\"}}");
            });
            string showPortifolio = "portfolio = {";
            portfolio.ForEach(trade =>
            {
                showPortifolio += trade._name + ", ";
            });
            showPortifolio = showPortifolio.Remove(showPortifolio.Length-2, 2);
            showPortifolio += "}";
            Console.WriteLine(showPortifolio);
            Console.WriteLine("\nOutput:");
            Console.WriteLine($"tradeCategories = {{{string.Join(", ", tradeCategories.Select(category => $"\"{category}\""))}}}");
            Console.ReadKey();
        }



}
}