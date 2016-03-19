using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CosmicAdventureDTO
{
    [DataContract]
    public class CosmosSystem
    {
    
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int BaseDistance { get; set; }

        public int MinShipPower { get { return _minShipPower; } }
        public int Gold { get { return _gold; } }

        private int _minShipPower;
        private int _gold;

        public static CosmosSystem CreateRandomSystem(string name)
        {
            Random random = new Random();

            return new CosmosSystem()
            {
                Name = name,
                BaseDistance = random.Next(20, 120),
                _minShipPower = random.Next(10, 40),
                _gold = random.Next(3000, 7000)
            };
        }
    }
}
