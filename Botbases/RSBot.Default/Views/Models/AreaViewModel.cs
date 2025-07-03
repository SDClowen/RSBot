using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSBot.Default.Views.Models
{
    public class AreaViewModel
    {
        public string Name { get; set; }
        public string Region { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public int Radius { get; set; }
        public bool IsSelected { get; set; }
        public string Position => $"X: {X:0.0}  Y: {Y:0.0}";
        public string FullName => $"{Name} ({Region})";
    }
}
