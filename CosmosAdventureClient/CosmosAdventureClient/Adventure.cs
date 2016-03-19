using CosmosAdventureClient.CosmicAdventureService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmosAdventureClient
{
    class Adventure
    {
        private ImperiumService.Service1Client imperiumServiceClient;
        private CosmicAdventureService.Service1Client cosmicAdventureClient;

        private List<Starship> starships;
        private bool anySystem;
        private int gold;
        private int imperiumMoneyAskCount;

        public Adventure()
        {
            imperiumServiceClient = new ImperiumService.Service1Client();
            cosmicAdventureClient = new CosmicAdventureService.Service1Client();

            starships = new List<Starship>();
            anySystem = true;
            gold = 1000;
            imperiumMoneyAskCount = 4;
        }

        public void ShowMenu()
        {
            Console.WriteLine("%%%");
            Console.WriteLine("Current gold: {0}. Available imperium money requests: {1}.", gold, imperiumMoneyAskCount);
            Console.WriteLine("Available actions:");
            Console.WriteLine("M - ask imperium for money");
            Console.WriteLine("B - buy starship");
            Console.WriteLine("S - plunder system");
            Console.WriteLine("E - finish");
            Console.WriteLine("%%%");
        }

        public void ReadUserInput()
        {
            ConsoleKeyInfo cki = Console.ReadKey();
        
            Console.Clear();
            switch (cki.Key)
            {
                case ConsoleKey.M:
                    AskImperiumForMoneyzAction();
                    break;
                case ConsoleKey.B:
                    BuyStarshipAction();
                    break;
                case ConsoleKey.S:
                    PlunderAction();
                    break;
                case ConsoleKey.E:
                    FinishGameAction();
                    break;
            }

        }

        public void Start()
        {
            cosmicAdventureClient.InitializeGame();
        }

        public void AskImperiumForMoneyzAction()
        {
            if (imperiumMoneyAskCount > 0)
            {
                int gold = imperiumServiceClient.GetMoneyFromImperium();
                this.gold += gold;
                imperiumMoneyAskCount--;

                Console.WriteLine("You received {0} gold from imperium.", gold);
            }
            else
            {
                Console.WriteLine("Imperium won't support you anymore.");
            }
        }

        public void BuyStarshipAction()
        {
            Console.WriteLine("Please enter the amount you want to spend on new starship.");

            string input = Console.ReadLine();
            int moneyCount;

            if (int.TryParse(input, out moneyCount))
            {
                if (moneyCount <= this.gold)
                {
                    Starship newStarship = cosmicAdventureClient.GetStarship(moneyCount);

                    if (newStarship != null)
                    {
                        starships.Add(newStarship);
                        this.gold -= moneyCount;

                        Console.WriteLine("Congratulations! You have bought a new starship: ");
                        PresentStarship(newStarship);
                    }
                    else Console.WriteLine("Sorry, we don't have a ship for that price.");
                }
                else Console.WriteLine("Don't try to cheat me!");
            }
            else Console.WriteLine("The amount must be an integer value!");
        }

        public void FinishGameAction()
        {
            if (!anySystem)
                Console.WriteLine("Congratulations! You have won a game.");
            else Console.WriteLine("You have lost");    
        }

        public void PlunderAction()
        {
            CosmosSystem system = cosmicAdventureClient.GetSystem();

            if (system != null && starships.Count > 0)
            {
                Console.WriteLine("System: {0}. Distance {1}.", system.Name, system.BaseDistance);
                Console.WriteLine("Ready starships: {0}.", starships.Count);

                Console.WriteLine("Pick a ship or press 'e' to exit.");
                starships.ForEach(s => PresentStarship(s));

                Starship pickedShip = PickStarshipAction();
                if (pickedShip != null)
                {
                    SendStarship(pickedShip, system);
                }
            }
            
            if (system == null)
            {
                anySystem = false;
            }
        }

        private void SendStarship(Starship starship, CosmosSystem system)
        {
            starships.Remove(starship);
            Starship returnedShip = cosmicAdventureClient.SendStarship(starship, system.Name);

            if (returnedShip.Gold != 0)
            {
                Console.WriteLine("You have plundered {0} gold.", returnedShip.Gold);
                this.gold += returnedShip.Gold;
                returnedShip.Gold = 0;
            }

            if (returnedShip.Crew.Count > 0)
                starships.Add(returnedShip);
        }

        private Starship PickStarshipAction()
        {
            string input = Console.ReadLine();
            int shipNo;

            if (input.Equals("e"))
            {
                return null;
            }

            if (int.TryParse(input, out shipNo))
            {
                if (shipNo > 0 && shipNo <= starships.Count)
                {
                    return starships.ElementAt(shipNo - 1);
                }
                else Console.WriteLine("Wrong ship number!");
            }
            else Console.WriteLine("Input must be a number value!");

            return null;
        }

        private void PresentStarship(Starship s)
        {
            Console.Write("{0}", s.ShipPower);
            s.Crew.ForEach(p => Console.Write(", {0} {1} {2}", p.Name, p.Nick, p.Age));
            Console.WriteLine();
        }
    }
}
