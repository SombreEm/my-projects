using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class Glock17 : Weapons
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
    public class AK47 : Weapons
    {
        private int weight = 30;
        private int clipSize = 30;
        public const int minDamage = 20;
        public const int maxDamage = 30;
        public AK47()
        {
            setName("AK47");
            setWeight(weight);
        }
    }
    public class M24 : Weapons
    {
        private int weight = 20;
        private int clipSize = 5;
        public const int minDamage = 80;
        public const int maxDamage = 150;
        public M24()
        {
            setName("M24");
            setWeight(weight);
        }
    }
    public class M416 : Weapons
    {
        private int weight = 30;
        private int clipSize = 30;
        public const int minDamage = 20;
        public const int maxDamage = 30;
        public M416()
        {
            setName("M416");
            setWeight(weight);
        }
    }
    public class SKS : Weapons
    {
        private int weight = 30;
        private int clipSize = 20;
        public const int minDamage = 30;
        public const int maxDamage = 60;
        public SKS()
        {
            setName("SKS");
            setWeight(weight);
        }
    }
}
