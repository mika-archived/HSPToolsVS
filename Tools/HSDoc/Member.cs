using System.Collections.Generic;

namespace HSDoc
{
    internal class Member
    {
        public string Name { get; set; }

        public string Summary { get; set; }

        public List<Param> Params { get; private set; }

        public string Returns { get; set; }

        public Member()
        {
            Params = new List<Param>();
        }
    }
}