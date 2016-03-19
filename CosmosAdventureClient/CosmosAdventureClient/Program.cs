using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CosmosAdventureClient.ImperiumService;
using CosmosAdventureClient.CosmicAdventureService;

namespace CosmosAdventureClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Adventure adventure = new Adventure();
 
            adventure.Start();
            while (true)
            {
                adventure.ShowMenu();
                adventure.ReadUserInput();
            }
        }
    }
}
