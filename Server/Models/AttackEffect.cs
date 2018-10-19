using System.ComponentModel.DataAnnotations;

namespace Server.Models
{
    public class AttackEffect
    {
        [Key]
        public int AttackEffectId { get; set; }

        public AttackEffect()
        {

        }

        public void ThrowBottleEffect()
        {

        }
    }
}