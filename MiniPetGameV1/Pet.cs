using System;
using System.Collections.Generic;
using System.Text;

namespace MiniPetGameV1
{
    class Pet
    {
        public List<Item> inventory { get; set; }
        public List<Item> GetIteam { get; set; }
        public string PetName { get; set; }
        public byte isHungary { get; set; }
        public byte isThirsty { get; set; }
        public int Heart { get; set; }
        public byte Lvl { get; set; }
        public int Xp { get; set; }
        public int TargetLvl { get; set; }
        public int Coin { get; set; }
         
    }
}
