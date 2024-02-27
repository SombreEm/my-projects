using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ШАГ_27._02._2024
{
    internal class Program
    {
        public delegate void TemperatureChangeHandler(int newTemperature);
        public class TemperatureSensor
        {
            public event TemperatureChangeHandler TemperatureChanged;
            private int currentTemperature;
            public void UpdateTemperature(int newTemperature)
            {
                if (newTemperature != currentTemperature)
                {
                    currentTemperature = newTemperature;
                    OnTemperatureChanged(newTemperature);
                }
            }
            protected virtual void OnTemperatureChanged(int newTemperature)
            {
                TemperatureChanged.Invoke(newTemperature);
            }
        }
        public class TemperatureDisplay
        {
            public void HandleTemperatureChange(int newTemperature)
            {
                Console.WriteLine($"Temperature changed: {newTemperature} degrees");
            }
        }
        static void Main(string[] args)
        {
            TemperatureSensor sensor = new TemperatureSensor();
            TemperatureDisplay display = new TemperatureDisplay();
            sensor.TemperatureChanged += display.HandleTemperatureChange;
            sensor.UpdateTemperature(25); 
            sensor.UpdateTemperature(28);
            sensor.UpdateTemperature(28);
        }
    }
}
