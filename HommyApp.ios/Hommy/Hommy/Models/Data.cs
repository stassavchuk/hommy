using System;
using System.Collections.Generic;
using System.Text;
using Foundation;

namespace Hommy.Models
{
    class Lamp
    {
        public string Name { get; set; }
        public bool State { get; set; }
        public NSIndexPath Index { get; set; }
    }

    class Radio
    {
        public string Name { get; set; }
        public string Link { get; set; }
    }

    class Data
    {
        private static volatile Data _instance;
        private static object _syncRoot = new object();
        public static Data Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_syncRoot)
                    {
                        if (_instance == null)
                            _instance = new Data();
                    }
                }

                return _instance;
            }
        }

        private Data()
        {
            Lamps = new List<Lamp>()
            {
                new Lamp() {Name = "Kitchen", State = true},
                new Lamp() {Name = "Bedroom", State = false},
                new Lamp() {Name = "Toilet", State = false}
            };

            Radios = new List<Radio>()
            {
                new Radio() {Name = "Radio 1"},
                new Radio() {Name = "Radio 2"},
                new Radio() {Name = "Radio 3"},
                new Radio() {Name = "Radio 4"}
            };
        }

        public List<Lamp> Lamps { get; set; }
        public List<Radio> Radios { get; set; } 
    }
}
