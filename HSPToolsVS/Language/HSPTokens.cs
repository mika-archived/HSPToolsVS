using System.Collections.Generic;

namespace HSPToolsVS.Language
{
    // ReSharper disable once InconsistentNaming
    internal static class HSPTokens
    {
        public static List<string> Operators => new List<string>
        {
            // Arithmetic operators
            "+", "-", "*", "/", "\\",
            // Bitwise operators
            "&", "|", "^", "<<", ">>",
            // Conditional operators
            "=", "==", "!=", "!", /* "&" , */ /* "|", */ ">", "<", ">=", "<=",
            // Assignment operators
            /* "=" ,*/ /* "==", */ "+=", "-=", "*=", "/=", "\\=", "|=", "&=", "^=", "<<=", ">>=", "++", "--"
        };

        public static List<string> Keywords => new List<string>
        {
            // ~ HSP 3.3
            "comevdisp", "comevarg", "comevent", "delcom", "newcom", "querycom", "sarrayconv", "assert", "logmes",
            "button", "chkbox", "clrobj", "combox", "input", "listbox", "mesbox", "objenable", "objimage", "objmode",
            "objprm", "objsel", "objsize", "objskip", "bcopy", "bload", "bsave", "chdir", "chdpm", "delete", "dirlist",
            "exist", "memfile", "mkdir", "await", "break", "continue", "else", "end", "exec", "exgoto", "foreach",
            "gosub", "goto", "if", "loop", "on", "onclick", "oncmd", "onerror", "onexit", "onkey", "repeat", "resume",
            "return", "run", "stop", "wait", "yield", "mci", "mmload", "mmplay", "mmstop", "lpeek", "peek", "wpeek",
            "alloc", "comres", "ddim", "dim", "dimtype", "ldim", "lpoke", "memcpy", "memexpand", "memset", "newlab",
            "newmod", "poke", "sdim", "wpoke", "axobj", "bgscr", "bmpsave", "boxf", "buffer", "celdiv", "celload",
            "celput", "chgdisp", "circle", "cls", "color", "dialog", "font", "gcopy", "gmode", "gradf", "grect",
            "groll", "grotate", "gsel", "gsquare", "gzoom", "hsvcolor", "line", "mes", "palcolor", "palette", "pget",
            "picload", "pos", "print", "pset", "redraw", "screen", "sendmsg", "syscolor", "sysfont", "title", "width",
            "winobj", "abs", "absf", "atan", "callfunc", "cos", "dirinfo", "double", "expf", "gettime", "ginfo", "int",
            "length", "length2", "length3", "length4", "libptr", "limit", "limitf", "logf", "objinfo", "powf", "rnd",
            "sin", "sqrt", "str", "strlen", "sysinfo", "tan", "varptr", "vartype", "varuse", "getkey", "mcall", "mouse",
            "randomize", "stick", "dup", "dupptr", "mref", "cnvwtos", "getpath", "instr", "noteinfo", "strf", "strmid",
            "strtrim", "cnvstow", "getstr", "noteadd", "notedel", "noteget", "noteload", "notesave", "notesel",
            "noteunsel", "split", "strrep",
            // HSP 3.4
            "setease", "getease", "geteasef",
            // HSP 3.5
            "sortval", "sortstr", "sortnote", "sortget", "notefind"
        };

        public static List<string> Preprocessors => new List<string>
        {
            // ~ HSP 3.3
            "#addition", "#aht", "#ahtmes", "#cfunc", "#cmd", "#cmpopt", "#comfunc", "#const", "#defcfunc", "#deffunc",
            "#define", "#else", "#endif", "#enum", "#epack", "#func", "#global", "#if", "#ifdef", "#ifndef", "#include",
            "#modcfunc", "#modfunc", "#modinit", "#modterm", "#module", "#pack", "#packopt", "#regcmd", "#runtime",
            "#undef", "#usecom", "#uselib",
            // HSP 3.5
            "#bootopt"
        };

        public static List<string> Macros => new List<string>
        {
            // ~ HSP 3.3
            "_break", "_continue", "case", "default", "do", "for", "next", "swbreak", "swend",
            "switch", "until", "wend", "while"
        };
    }
}