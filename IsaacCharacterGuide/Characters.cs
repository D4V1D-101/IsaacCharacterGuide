using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace IsaacCharacterGuide
{
    internal class Characters
    {
        public Characters(string r, List<Starter> starterItems, List<Stat> starterStats)
        {
            var v = r.Split(';');
            Name = v[0];
            Gender = v[1] == "Male";
            Race = v[2];
            HasTaintedVersion = v[3] == "Yes"; ;
            ReleaseDate = DateTime.Parse(v[4]);
            StarterItem = starterItems.Where(x => x.Characters.Equals(Name)).ToList();
            StarterStat = starterStats.Where(x => x.Characters.Equals(Name)).ToList();
        }

        public string Name { get; set; }
        public bool Gender { get; set; }
        public string Race { get; set; }
        public bool HasTaintedVersion { get; set; }
        public DateTime ReleaseDate { get; set; }
        public List<Starter> StarterItem { get; set; }
        public List<Stat> StarterStat { get; set; }
       



    }
}
 