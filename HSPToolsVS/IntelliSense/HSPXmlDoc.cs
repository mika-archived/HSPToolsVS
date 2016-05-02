using System.Collections.Generic;
using System.Xml.Serialization;

// ReSharper disable InconsistentNaming

namespace HSPToolsVS.IntelliSense
{
    [XmlRoot("doc")]
    public class HSPXmlDocRoot
    {
        [XmlElement("assembly")]
        public HSPXmlDocAssembly Assembly { get; set; }

        [XmlElement("members")]
        public HSPXmlDocMembers Members { get; set; }
    }

    public class HSPXmlDocAssembly
    {
        [XmlElement("name")]
        public string Name { get; set; }
    }

    public class HSPXmlDocMembers
    {
        [XmlElement("member")]
        public List<HSPXmlDocMember> List { get; set; }
    }

    public class HSPXmlDocMember
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlElement("summary")]
        public string Summary { get; set; }

        [XmlElement("param")]
        public List<HSPXmlDocParam> Params { get; set; }
    }

    public class HSPXmlDocParam
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlText]
        public string Description { get; set; }
    }
}