using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class Player
    {
        [Key]
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public int PosX { get; set; }
        public int PosY { get; set; }
        public int Points { get; set; }
        public DateTime SpawnTime { get; set; }
        public DateTime LastCheckTime { get; set; }
        public CharacterClass CharacterClass { get; set; }

        public ICollection<Bottle> Bottles { get; set; }

        public int HealthPoints { get; set; }
    }

    public enum CharacterClass
    {
        DefaultClass,
        Speedy,
        Hoarder,
        Brute
    }
}
