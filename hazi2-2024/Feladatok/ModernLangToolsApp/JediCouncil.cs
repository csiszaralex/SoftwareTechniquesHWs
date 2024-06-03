using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernLangToolsApp
{
    public delegate void CouncilChangedDelegate(string message);
    internal class JediCouncil
    {
        List<Jedi> members = new List<Jedi>();
        public event CouncilChangedDelegate CouncilChanged;
        public int Count { get { return members.Count; } }


        public int CountIf(Func<Jedi, bool> filter)
        {
            int db = 0;
            foreach (var j in members)
            {
                if (filter(j)) db++;
            }
            return db;
        }

        public void Add(Jedi newJedi)
        {
            members.Add(newJedi);
            CouncilChanged?.Invoke("Új taggal bővültünk");
        }

        public void Remove()
        {
            members.RemoveAt(members.Count - 1);
            if (members.Count == 0) CouncilChanged?.Invoke("A tanács elesett!");
            else CouncilChanged?.Invoke("Zavart érzek az erőben");
        }

        public List<Jedi> midiMax530_Delegate()
        {
            return members.FindAll(MyFilter);
        }
        private static bool MyFilter(Jedi j)
        {
            return j.MidiChlorianCount < 530;
        }
        public List<Jedi> midiMax530_Lambda()
        {
            return members.FindAll(j => j.MidiChlorianCount < 1000);
        }
    }
}
