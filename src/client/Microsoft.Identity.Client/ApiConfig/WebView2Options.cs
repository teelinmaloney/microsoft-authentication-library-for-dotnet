﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.Identity.Client.Core;
using Microsoft.Identity.Client.Internal.Logger;
using Microsoft.Identity.Client.PlatformsCommon.Factories;

namespace Microsoft.Identity.Client
{
    /// <summary>
    /// Options for using the modern Windows embedded browser WebView2. 
    /// For more details see https://aka.ms/msal-net-webview2
    /// </summary>
#if !SUPPORTS_WEBVIEW2
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
    public class WebView2Options
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public WebView2Options()
        {
            ValidatePlatformAvailability();
        }

        /// <summary>
        /// Forces a static title to be set on the window hosting the browser. If not configured, the widow's title is set to the web page title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Allows use of a static WebView2 runtime. If unset, the WebView2 API tries to locate the globally available version.
        /// For more details see: https://docs.microsoft.com/en-us/dotnet/api/microsoft.web.webview2.core.corewebview2environment.createasync?view=webview2-dotnet-1.0.705.50
        /// </summary>
        public string BrowserExecutableFolder { get; set; }

        internal void LogParameters(ICoreLogger logger)
        {
            logger.Info("WebView2Options configured");

            logger.Info($"Title: {Title}");
            logger.InfoPii($"BrowserExecutableFolder: {BrowserExecutableFolder}", "BrowserExecutableFolder set");
        }

        internal static void ValidatePlatformAvailability()
        {
#if !SUPPORTS_WEBVIEW2
            throw new PlatformNotSupportedException(
                "WebView2Options API is only supported on .NET Fx, .NET Core and .NET5 ");
#endif
        }
    }
}