using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsaacCharacterGuide
{
    internal class Starter
    {
        public Starter(string r)
        {
            var v = r.Split(';');
            Characters = v[0];
            Name = v[1];
            IsActive = v[2] == "Active";
            Description = v[3];
            FindableAt = v[4];
        }

        public string Characters { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public string Description { get; set; }
        public string FindableAt { get; set; }
    }
}
