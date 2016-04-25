//------------------------------------------------------------------------------
// <copyright file="HSPVSPackage.cs" company="Company">
//     Copyright (c) Mikazuki.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel.Design;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

using HSPToolsVS.Language;

using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.Package;
using Microsoft.VisualStudio.Shell;

namespace HSPToolsVS
{
    /// <summary>
    ///     This is the class that implements the package exposed by this assembly.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         The minimum requirement for a class to be considered a valid package for Visual Studio
    ///         is to implement the IVsPackage interface and register itself with the shell.
    ///         This package uses the helper classes defined inside the Managed Package Framework (MPF)
    ///         to do it: it derives from the Package class that provides the implementation of the
    ///         IVsPackage interface and uses the registration attributes defined in the framework to
    ///         register itself and its components with the shell. These attributes tell the pkgdef creation
    ///         utility what data to put into .pkgdef file.
    ///     </para>
    ///     <para>
    ///         To get loaded into VS, the package must be referred by &lt;Asset Type="Microsoft.VisualStudio.VsPackage" ...
    ///         &gt; in .vsixmanifest file.
    ///     </para>
    /// </remarks>
    [PackageRegistration(UseManagedResourcesOnly = true)]
    [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)] // Info on this package for Help/About
    [Guid(PackageGuidString)]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly",
        Justification = "pkgdef, VS and vsixmanifest are valid VS terms")]
    // Register a Language Service
    [ProvideService(typeof(HSPLanguageService), ServiceName = "HSP Language Service")]
    [ProvideLanguageService(typeof(HSPLanguageService), "HSP", 0)]
    [ProvideLanguageExtension(typeof(HSPLanguageService), ".hsp")]
    [ProvideLanguageExtension(typeof(HSPLanguageService), ".as")]
    // ReSharper disable once InconsistentNaming
    public sealed class HSPVSPackage : Package, IOleComponent
    {
        /// <summary>
        ///     HSPVSPackage GUID string.
        /// </summary>
        public const string PackageGuidString = "d831da21-d940-4ad0-aa2a-4a7a04e3d6c4";

        private uint _componentId;

        #region Package Members

        /// <summary>
        ///     Initialization of the package; this method is called right after the package is sited, so this is the place
        ///     where you can put all the initialization code that rely on services provided by VisualStudio.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();

            var serviceContainer = this as IServiceContainer;
            var hspLangService = new HSPLanguageService();
            hspLangService.SetSite(this);
            serviceContainer.AddService(typeof(HSPLanguageService), hspLangService, true);

            var manager = GetService(typeof(SOleComponentManager)) as IOleComponentManager;
            if (_componentId != 0 || manager == null)
                return;
            var crinfo = new OLECRINFO[1];
            crinfo[0].cbSize = (uint) Marshal.SizeOf(typeof(OLECRINFO));
            crinfo[0].grfcrf = (uint) _OLECRF.olecrfNeedIdleTime |
                               (uint) _OLECRF.olecrfNeedPeriodicIdleTime;
            crinfo[0].grfcadvf = (uint) _OLECADVF.olecadvfModal |
                                 (uint) _OLECADVF.olecadvfRedrawOff |
                                 (uint) _OLECADVF.olecadvfWarningsOff;
            crinfo[0].uIdleTimeInterval = 1000;
            manager.FRegisterComponent(this, crinfo, out _componentId);
        }

        protected override void Dispose(bool disposing)
        {
            if (_componentId != 0)
            {
                var manager = GetService(typeof(SOleComponentManager)) as IOleComponentManager;
                manager?.FRevokeComponent(_componentId);
                _componentId = 0;
            }

            var serviceContainer = this as IServiceContainer;
            serviceContainer.RemoveService(typeof(HSPLanguageService));

            base.Dispose(disposing);
        }

        #endregion

        #region Implementation of IOleComponent

        public int FReserved1(uint dwReserved, uint message, IntPtr wParam, IntPtr lParam)
        {
            return 1;
        }

        public int FPreTranslateMessage(MSG[] pMsg)
        {
            return 0;
        }

        public void OnEnterState(uint uStateId, int fEnter)
        {

        }

        public void OnAppActivate(int fActive, uint dwOtherThreadId)
        {

        }

        public void OnLoseActivation()
        {

        }

        public void OnActivationChange(IOleComponent pic, int fSameComponent, OLECRINFO[] pcrinfo, int fHostIsActivating,
                                       OLECHOSTINFO[] pchostinfo, uint dwReserved) {}

        public int FDoIdle(uint grfidlef)
        {
            var bPeriodic = (grfidlef & (uint) _OLEIDLEF.oleidlefPeriodic) != 0;
            var service = GetService(typeof(HSPLanguageService)) as LanguageService;
            service?.OnIdle(bPeriodic);

            return 0;
        }

        public int FQueryTerminate(int fPromptUser)
        {
            return 1;
        }

        public void Terminate()
        {

        }

        public IntPtr HwndGetWindow(uint dwWhich, uint dwReserved)
        {
            return IntPtr.Zero;
        }

        public int FContinueMessageLoop(uint uReason, IntPtr pvLoopData, MSG[] pMsgPeeked)
        {
            return 1;
        }

        #endregion
    }
}