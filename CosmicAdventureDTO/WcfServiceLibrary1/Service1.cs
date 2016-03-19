using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CosmicAdventureDTO;

namespace WcfServiceLibrary1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Service1 : IService1
    {
        private List<CosmicAdventureDTO.CosmosSystem> _systems;

        public Service1()
        {
            _systems = new List<CosmosSystem>();
        }

        public void InitializeGame()
        {
            Random random = new Random();
            for (int i = 0; i < 4; i++)
            {
                _systems.Add(CosmicAdventureDTO.CosmosSystem.CreateRandomSystem("System" + i));
            }
        }

        public CosmicAdventureDTO.CosmosSystem GetSystem()
        {
            if (_systems.Count > 0)
                return _systems.ElementAt(0);

            return null;
        }

        public Starship GetStarship(int money)
        {
            if (money >= 1000 && money < 3000)
                return Starship.createWeakShip();
            else if (money >= 3000 && money < 10000)
                return Starship.createMediocreShip();
            else if (money >= 10000)
                return Starship.createStrongShip();

            return null;
        }

        public Starship SendStarship(Starship starship, string systemName)
        {

            if (_systems.Exists(s => s.Name.Equals(systemName)))
            {
                CosmicAdventureDTO.CosmosSystem system = _systems.First(s => s.Name.Equals(systemName));
                if (plunderSystem(starship, system))
                {
                    _systems.Remove(system);
                }

                return starship;
            }
            else
            {
                starship.Crew.Clear();

                return starship;
            }
        }

        private bool plunderSystem(Starship ship, CosmicAdventureDTO.CosmosSystem system)
        {
            increaseCrewAge(system, ship);
            ship.Crew.RemoveAll(cm => cm.Age > 90);

            if (ship.ShipPower > system.MinShipPower)
            {
                ship.Gold += system.Gold;
                return true;
            }
            else return false;
        }

        private void increaseCrewAge(CosmicAdventureDTO.CosmosSystem system, Starship ship)
        {
            if (ship.ShipPower <= 20)
            {
                ship.Crew.ForEach(cm => cm.Age = cm.Age + (2 * system.BaseDistance) / 12);
            }
            else if (ship.ShipPower > 20 && ship.ShipPower < 30)
            {
                ship.Crew.ForEach(cm => cm.Age = cm.Age + (2 * system.BaseDistance) / 6);
            }
            else
            {
                ship.Crew.ForEach(cm => cm.Age = cm.Age + (2 * system.BaseDistance) / 4);
            }
        }
    }
}
