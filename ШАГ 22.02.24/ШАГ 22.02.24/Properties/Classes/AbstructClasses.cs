using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public abstract class BaseProperty
    {

        private int weight { set; get; }
        private string name { set; get; }
        public int getWeight() { return this.weight; }
        public string getName() { return this.name;}
        protected void setWeight(int newWeight) {this.weight = newWeight; }
        protected void setName(string newName) { this.name = newName; }
    }
    public abstract class Weapons : BaseProperty
    {

    }
    public abstract class ModuleForWeapons : BaseProperty
    {

    }
    public abstract class Medicale : BaseProperty
    {

    }
    public abstract class Equpments : BaseProperty
    {

    }
    public abstract class Armor : BaseProperty
    {
        private int armor {  get; set; }
        public int getArmor() { return this.armor; }
        public void setArmor(int newArmor) {  this.armor = newArmor; }

    }

}
