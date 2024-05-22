using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ModernLangToolsApp
{
    [XmlRoot("Jedi")]
    public class Jedi
    {

        private int midiChlorianCount;
        [XmlAttribute("Nev")]
        public string Name { get; set; }
        [XmlAttribute("MidiChlorianSzam")]
        public int MidiChlorianCount
        {
            get => midiChlorianCount;
            set
            {
                if (midiChlorianCount == value) return;
                if (value <= 35) throw new ArgumentException("You are not a true jedi!");
                midiChlorianCount = value;
            }
        }
    }
}
