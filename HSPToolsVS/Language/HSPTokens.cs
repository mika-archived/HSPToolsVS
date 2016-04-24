using System.Collections.Generic;

namespace HSPToolsVS.Language
{
    // ReSharper disable once InconsistentNaming
    internal static class HSPTokens
    {
        public static List<string> Operators1Char = new List<string>
        {
            "+", "-", "*", "/", "\\", "&", "|", "^", "=", "!", "<", ">"
        };

        public static List<string> Operators2Chars = new List<string>
        {
            "<<", ">>", "==", "!=", ">=", "<=", "+=", "-=",
            "*=", "/=", "\\=", "|=", "&=", "^=", "++", "--"
        };

        public static List<string> Operators3Chars = new List<string>
        {
            "<<=", ">>="
        };

        public static List<string> LineComment = new List<string> {"//", ";"};

        public static List<string> Keywords { get; }

        public static List<string> Preprocessors { get; }

        public static List<string> Macros { get; }

        public static string CommentStart => "/*";
        public static string CommentEnd => "*/";

        static HSPTokens()
        {
            Keywords = new List<string>
            {
                // ~ HSP 3.3
                "comevdisp", "comevarg", "comevent", "delcom", "newcom", "querycom", "sarrayconv", "assert", "logmes",
                "button", "chkbox", "clrobj", "combox", "input", "listbox", "mesbox", "objenable", "objimage", "objmode",
                "objprm", "objsel", "objsize", "objskip", "bcopy", "bload", "bsave", "chdir", "chdpm", "delete",
                "dirlist", "exist", "memfile", "mkdir", "await", "break", "continue", "else", "end", "exec", "exgoto",
                "foreach", "resume", "return", "run", "stop", "wait", "yield", "mci", "mmload", "mmplay", "mmstop",
                "lpeek", "peek", "wpeek", "alloc", "comres", "ddim", "dim", "dimtype", "ldim", "lpoke", "memcpy",
                "memexpand", "memset", "newlab", "newmod", "poke", "sdim", "wpoke", "axobj", "bgscr", "bmpsave", "boxf",
                "buffer", "celdiv", "celload", "celput", "chgdisp", "circle", "cls", "color", "dialog", "font", "gcopy",
                "gmode", "gradf", "grect", "groll", "grotate", "gsel", "gsquare", "gzoom", "hsvcolor", "line", "mes",
                "palcolor", "palette", "pget", "picload", "pos", "print", "pset", "redraw", "screen", "sendmsg",
                "syscolor", "sysfont", "title", "width", "winobj", "abs", "absf", "atan", "callfunc", "cos", "dirinfo",
                "double", "expf", "gettime", "ginfo", "int", "length", "length2", "length3", "length4", "libptr",
                "limit", "limitf", "logf", "objinfo", "powf", "rnd", "sin", "sqrt", "str", "strlen", "sysinfo", "tan",
                "varptr", "vartype", "varuse", "getkey", "mcall", "mouse", "randomize", "stick", "dup", "dupptr", "mref",
                "cnvwtos", "getpath", "instr", "noteinfo", "strf", "strmid", "strtrim", "cnvstow", "getstr", "noteadd",
                "notedel", "noteget", "noteload", "notesave", "notesel", "noteunsel", "split", "strrep",
                // HSP 3.4
                "setease", "getease", "geteasef",
                // HSP 3.5
                "sortval", "sortstr", "sortnote", "sortget", "notefind"
            };
            Keywords.Sort((s1, s2) => s1.Length - s2.Length);

            Preprocessors = new List<string>
            {
                // ~ HSP 3.3
                "#addition", "#aht", "#ahtmes", "#cfunc", "#cmd", "#cmpopt", "#comfunc", "#const", "#defcfunc",
                "#deffunc", "#define", "#else", "#endif", "#enum", "#epack", "#func", "#global", "#if", "#ifdef",
                "#ifndef", "#include", "#modcfunc", "#modfunc", "#modinit", "#modterm", "#module", "#pack", "#packopt",
                "#regcmd", "#runtime", "#undef", "#usecom", "#uselib",
                // HSP 3.5
                "#bootopt"
            };
            Preprocessors.Sort((s1, s2) => s1.Length - s2.Length);

            Macros = new List<string>
            {
                // ~ HSP 3.3
                "_break", "_continue", "case", "default", "do", "for", "next", "swbreak", "swend",
                "switch", "until", "wend", "while"
            };
            Macros.Sort((s1, s2) => s1.Length - s2.Length);
        }
    }
}