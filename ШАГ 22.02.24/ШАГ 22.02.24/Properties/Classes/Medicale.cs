using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class MedicineChest : Medicale
    {
        private int weight = 5;
        private int clipSize = 8;
        public const int minDamage = 8;
        public const int maxDamage = 15;
        public Glock17()
        {
            setName("Glock17");
            setWeight(weight);
        }
    }
}
