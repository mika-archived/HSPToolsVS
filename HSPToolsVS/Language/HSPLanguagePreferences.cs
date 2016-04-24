﻿using System;

using Microsoft.VisualStudio.Package;

namespace HSPToolsVS.Language
{
    // ReSharper disable once InconsistentNaming
    internal class HSPLanguagePreferences : LanguagePreferences
    {
        public HSPLanguagePreferences(IServiceProvider site, Guid langSvc, string name) : base(site, langSvc, name)
        {
            EnableCodeSense = true; // IntelliSense support.
            EnableCommenting = true; // Block comments.
            EnableMatchBraces = true; // Highlight matching brances.
            EnableMatchBracesAtCaret = true; // Highlight matching braces on typings.
            LineNumbers = true; // Shown line numbers.
        }
    }
}