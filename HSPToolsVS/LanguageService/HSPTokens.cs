using System.Collections.Generic;

namespace HSPToolsVS.LanguageService
{
    // ReSharper disable once InconsistentNaming
    internal static class HSPTokens
    {
        public static List<string> LineComment => new List<string> {"//", ";"};

        public static List<string> AllowSpaceCharsIn => new List<string> {"\"", "'"};

        public static List<string> Operators { get; }

        public static List<string> Separators => new List<string>
        {
            ",", ":", "(", ")", "{", "}", ".", "@"
        };

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
                "foreach", "gosub", "goto", "if", "loop", "on", "onclick", "oncmd", "onerror", "onexit", "onkey",
                "repeat", "resume", "return", "run", "stop", "wait", "yield", "mci", "mmload", "mmplay", "mmstop",
                "lpeek", "peek", "wpeek", "alloc", "comres", "ddim", "dim", "dimtype", "ldim", "lpoke", "memcpy",
                "memexpand", "memset", "newlab", "newmod", "delmod", "poke", "sdim", "wpoke", "axobj", "bgscr",
                "bmpsave", "boxf", "buffer", "celdiv", "celload", "celput", "chgdisp", "circle", "cls", "color",
                "dialog", "font", "gcopy", "gmode", "gradf", "grect", "groll", "grotate", "gsel", "gsquare", "gzoom",
                "hsvcolor", "line", "mes", "palcolor", "palette", "pget", "picload", "pos", "print", "pset", "redraw",
                "screen", "sendmsg", "syscolor", "sysfont", "title", "width", "winobj", "abs", "absf", "atan",
                "callfunc", "cos", "dirinfo", "double", "expf", "gettime", "ginfo", "int", "length", "length2",
                "length3", "length4", "libptr", "limit", "limitf", "logf", "objinfo", "powf", "rnd", "sin", "sqrt",
                "str", "strlen", "sysinfo", "tan", "varptr", "vartype", "varuse", "getkey", "mcall", "mouse",
                "randomize", "stick", "dup", "dupptr", "mref", "cnvwtos", "getpath", "instr", "noteinfo", "strf",
                "strmid", "strtrim", "cnvstow", "getstr", "noteadd", "notedel", "noteget", "noteload", "notesave",
                "notesel", "noteunsel", "split", "strrep", "system", "hspstat", "hspver", "stat", "cnt", "err",
                "strsize", "looplev", "sublev", "iparam", "wparam", "lparam", "refstr", "refdval", "hwnd",
                "hinstance", "hdc", "thismod",
                // HSP 3.4
                "setease", "getease", "geteasef",
                // HSP 3.5
                "sortval", "sortstr", "sortnote", "sortget", "notefind"
            };
            Keywords.Sort((s1, s2) => s2.Length - s1.Length);

            Preprocessors = new List<string>
            {
                // ~ HSP 3.3
                "#addition", "#aht", "#ahtmes", "#cfunc", "#cmd", "#cmpopt", "#comfunc", "#const", "#defcfunc",
                "#deffunc", "#define", "#else", "#endif", "#enum", "#epack", "#func", "#global", "#if", "#ifdef",
                "#ifndef", "#include", "#modcfunc", "#modfunc", "#modinit", "#modterm", "#module", "#pack", "#packopt",
                "#regcmd", "#runtime", "#undef", "#usecom", "#uselib", "#defint", "#defdouble", "#defnone",
                // HSP 3.5
                "#bootopt"
            };
            Preprocessors.Sort((s1, s2) => s2.Length - s1.Length);

            Macros = new List<string>
            {
                // ~ HSP 3.3
                "_break", "_continue", "case", "default", "do", "for", "next", "swbreak", "swend",
                "switch", "until", "wend", "while", "and", "or", "not", "xor", "__hspver__", "__hsp30__",
                "__date__", "__time__", "__line__", "__file__", "_debug", "__hspdef__", "screen_normal",
                "screen_palette", "screen_hide", "screen_fixedsize", "screen_tool", "screen_frame",
                "gmode_gdi", "gmode_mem", "gmode_rgb0", "gmode_alpha", "gmode_rgb0alpha", "gmode_add",
                "gmode_sub", "gmode_pixela", "ginfo_mx", "ginfo_my", "ginfo_act", "ginfo_sel", "ginfo_wx1",
                "ginfo_wy1", "ginfo_wx2", "ginfo_wy2", "ginfo_vx", "ginfo_vy", "ginfo_sizex", "ginfo_sizey",
                "ginfo_winx", "ginfo_winy", "ginfo_mesx", "ginfo_mesy", "ginfo_r", "ginfo_g", "ginfo_b",
                "ginfo_paluse", "ginfo_dispx", "ginfo_dispy", "ginfo_cx", "ginfo_cy", "objinfo_mode",
                "objinfo_bmscr", "objinfo_hwnd", "notemax", "notesize", "dir_cur", "dir_exe", "dir_win",
                "dir_sys", "dir_cmdline", "dir_desktop", "dir_mydoc", "dir_tv", "font_normal", "font_bold",
                "font_italic", "font_underline", "font_antialias", "objmode_normal", "objmode_guifont",
                "objmode_usefont", "gsquare_grad", "msgothic", "msmincho", "m_pi", "rad2deg", "deg2rad",
                "ease_linear", "ease_quad_in", "ease_quad_out", "ease_quad_inout", "ease_cubic_in", "ease_cubic_out",
                "ease_cubic_inout", "ease_quartic_in", "ease_quartic_out", "ease_quartic_inout", "ease_bounce_in",
                "ease_bounce_out", "ease_bounce_inout", "ease_shake_in", "ease_shake_out", "ease_shake_inout",
                "ease_loop"
            };
            Macros.Sort((s1, s2) => s2.Length - s1.Length);

            Operators = new List<string>
            {
                "+", "-", "*", "/", "\\", "&", "|", "^", "=", "!", "<", ">",
                "<<", ">>", "==", "!=", ">=", "<=", "+=", "-=",
                "*=", "/=", "\\=", "|=", "&=", "^=", "++", "--",
                "<<=", ">>="
            };
            Operators.Sort((s1, s2) => s2.Length - s1.Length);
        }
    }
}