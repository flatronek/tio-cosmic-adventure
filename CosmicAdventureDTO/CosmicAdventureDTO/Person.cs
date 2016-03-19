using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmicAdventureDTO
{
    public class Person
    {
        public string Name { get; set; }
        public string Nick { get; set; }
        public float Age { get; set; }

        public static Person CreateCrewMember(string namePrefix)
        {
            return new Person()
            {
                Name = namePrefix + new Random().Next(1, 10),
                Nick = namePrefix + new Random().Next(1, 10),
                Age = 20
            };
        }
    }
}
