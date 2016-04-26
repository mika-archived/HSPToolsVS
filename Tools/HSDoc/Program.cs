using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

// ReSharper disable AssignNullToNotNullAttribute

namespace HSDoc
{
    internal static class Program
    {
        // HSP Help Manager Source Parser (Simplicity)
        private static void Main()
        {
            // << HS dir
            var dir = Console.ReadLine();
            if (dir == null || !Directory.Exists(dir))
                return;

            Console.Write("Processing");
            // >> __.xml
            foreach (var file in Directory.GetFiles(dir))
                ParseAndWrite(file);
        }

        private static void ParseAndWrite(string hsFile)
        {
            Console.Write(".");
            if (!hsFile.EndsWith(".hs"))
                return;

            var xmlFile = hsFile.Replace(".hs", ".xml");
            var document = new Document();
            using (var sr = new StreamReader(hsFile, Encoding.GetEncoding("SHIFT-JIS")))
            {
                string line;
                var indexed = false;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.StartsWith(";"))
                        continue;

                    if (line.StartsWith("%type"))
                    {
                        var type = sr.ReadLine();
                        switch (type)
                        {
                            case "内蔵命令":
                            case "内蔵関数":
                                document.Assembly = "system/func";
                                break;

                            case "マクロ":
                                document.Assembly = "system/macro";
                                break;

                            case "HSPシステム変数":
                                document.Assembly = "system/var";
                                break;

                            default:
                                var name = Path.GetFileName(hsFile).Replace(".hs", "");
                                document.Assembly = name.StartsWith("llmod3") ? $"llmod3/{name.Split('_')[1]}" : name;
                                break;
                        }
                    }

                    if (!line.StartsWith("%index"))
                        continue;
                    document.Members.Add(ParseIndex(sr, ref indexed));
                    while (indexed)
                        document.Members.Add(ParseIndex(sr, ref indexed));
                }
            }

            using (var sw = new StreamWriter(xmlFile))
            {
                sw.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
                sw.WriteLine("<doc>");
                sw.WriteLine("  <assembly>");
                sw.WriteLine($"    <name>{document.Assembly}</name>");
                sw.WriteLine("  </assembly>");
                sw.WriteLine("  <members>");
                foreach (var member in document.Members)
                {
                    sw.WriteLine($"    <member name=\"{member.Name}\">");
                    if (member.Summary != null)
                        sw.WriteLine($"      <summary>{member.Summary}</summary>");
                    if (member.Returns != null)
                        sw.WriteLine($"      <returns>{member.Returns}</returns>");
                    if (member.Params.Count > 0)
                    {
                        foreach (var param in member.Params)
                            sw.WriteLine($"      <param name=\"{param.Name}\">{param.Summary}</param>");
                    }
                    sw.WriteLine("    </member>");
                }
                sw.WriteLine("  </members>");
                sw.WriteLine("</doc>");
            }
            Console.Write(".");
        }

        // ReSharper disable once RedundantAssignment
        private static Member ParseIndex(StreamReader sr, ref bool indexed)
        {
            var member = new Member
            {
                Name = sr.ReadLine()?.Trim(),
                Summary = sr.ReadLine()
            };
            string line;
            indexed = false;

            while ((line = sr.ReadLine()) != null && line != "%prm")
            {
                if (line != "%index")
                    continue;
                indexed = true;
                break;
            }
            if (line != "%prm")
                return member;

            line = sr.ReadLine();
            if (line == null || line.StartsWith("%") || line == "")
                return member;
            line = line.Replace("(", "").Replace(")", "");
            foreach (var s in line.Split(','))
            {
                var param = new Param {Name = s.Replace("\"", "").Trim()};
                member.Params.Add(param);
            }
            var index = 0;
            while ((line = sr.ReadLine()) != null && index < member.Params.Count)
            {
                if (line == "" || line.StartsWith("%"))
                    break;
                var splitter = ':';
                if (!line.Contains(":") && line.Contains("="))
                    splitter = '=';
                if (Regex.IsMatch(line, @"\(.*?(,.*)+?\)") || Regex.IsMatch(line, "\".*?(,.*)+?\""))
                {
                    var prms = line.Split(splitter)[0];
                    for (var i = 0; i < prms.Split(',').Length; i++)
                        member.Params[index++].Summary = line.Split(splitter)[1].Trim();
                }
                else
                    member.Params[index++].Summary = line.Split(splitter)[1].Trim();
            }
            return member;
        }
    }
}