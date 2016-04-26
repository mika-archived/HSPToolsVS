using System.Collections.Generic;

namespace HSDoc
{
    internal class Document
    {
        public List<Member> Members { get; private set; }

        public string Assembly { get; set; }

        public Document()
        {
            Members = new List<Member>();
        }
    }
}