using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CosmicAdventureDTO
{
    [DataContract]
    public class Starship
    {
        [DataMember]
        public List<Person> Crew { get; set; }
        [DataMember]
        public int Gold { get; set; }
        [DataMember]
        public int ShipPower { get; set; }

        public Starship()
        {
            Crew = new List<Person>();
        }

        public static Starship createWeakShip()
        {
            Starship ship = new Starship()
            {
                ShipPower = new Random().Next(10, 25),
                Gold = 0
            };

            ship.Crew.AddRange(CreateCrew("weak"));

            return ship;
        }

        public static Starship createMediocreShip()
        {
            Starship ship = new Starship()
            {
                ShipPower = new Random().Next(20, 35),
                Gold = 0
            };

            ship.Crew.AddRange(CreateCrew("mid"));

            return ship;
        }

        public static Starship createStrongShip()
        {
            Starship ship = new Starship()
            {
                ShipPower = new Random().Next(35, 60),
                Gold = 0
            };

            ship.Crew.AddRange(CreateCrew("strong"));

            return ship;
        }

        private static List<Person> CreateCrew(string namePrefix)
        {
            List<Person> result = new List<Person>();
            for (int i = 0; i < 4; i++)
            {
                result.Add(Person.CreateCrewMember(namePrefix));
            }

            return result;
        }
    }
}
