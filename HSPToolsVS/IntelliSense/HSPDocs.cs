using System.Collections.Generic;
using System.Xml.Serialization;

namespace HSPToolsVS.IntelliSense
{
    // ReSharper disable once InconsistentNaming
    internal static class HSPDocs
    {
        public static List<HSPXmlDocMember> Documents { get; private set; }

        public static void LoadDocuments()
        {
            Documents = new List<HSPXmlDocMember>();
            var systemDocs = new[]
            {
                "ex_macro", "i_com", "i_file", "i_graph", "i_hsp3util", "i_mem", "i_mmedia", "i_object",
                "i_prep", "i_prog", "i_stdfunc", "i_stdio", "i_string", "sysval"
            };
            foreach (var doc in systemDocs)
            {
                var stream = typeof(HSPVSPackage).Assembly.GetManifestResourceStream($"HSPToolsVS.Docs.{doc}.xml");
                if (stream == null)
                    continue;
                var serializer = new XmlSerializer(typeof(HSPXmlDocRoot));
                var data = serializer.Deserialize(stream) as HSPXmlDocRoot;
                if (data == null)
                    continue;
                foreach (var member in data.Members.List)
                    Documents.Add(member);
            }
        }
    }
}