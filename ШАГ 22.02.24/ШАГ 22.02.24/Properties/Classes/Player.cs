using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MyGame
{
    public class Player
    {
        private int hp = 100;
        private int weightLimit = 100;
        private List<object> inventory = new List<object>();
        public void showPlayerInventory()
        {
            foreach (var item in inventory) {
                Console.WriteLine();
            }
        }
        public int getHP(){ return this.hp; }
        public void setHp(int newHP) { this.hp = newHP; }
        public int getWL() { return this.weightLimit; }
        public void setWL(int newWL) {  this.weightLimit = newWL; }
        
    }
}
