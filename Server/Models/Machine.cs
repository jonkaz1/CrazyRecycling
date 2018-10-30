using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class Machine
    {
        [Key]
        public int MachineId { get; set; }
        public int PosX { get; set; }
        public int PosY { get; set; }
        public int SizeX { get; set; }
        public int SizeY { get; set; }
        public MachineType MachineType { get; set; }
    }

    public enum MachineType
    {
        RecyclingMachine,
        Shop
    }
}
