﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Identity.Client.ApiConfig.Parameters;
using Microsoft.Identity.Client.Internal;
using Microsoft.Identity.Client.Platforms.Features.WinFormsLegacyWebUi;
using Microsoft.Identity.Client.Platforms.Shared.Desktop.OsBrowser;
using Microsoft.Identity.Client.PlatformsCommon.Interfaces;
using Microsoft.Identity.Client.UI;

namespace Microsoft.Identity.Client.Platforms.net45
{
    internal class NetDesktopWebUIFactory : IWebUIFactory
    {
        public bool IsSystemWebViewAvailable => true;

        public IWebUI CreateAuthenticationDialog(
            CoreUIParent coreUIParent, 
            WebViewPreference useEmbeddedWebView, 
            RequestContext requestContext)
        {
            if (coreUIParent.UseHiddenBrowser)
            {
                return new SilentWebUI(coreUIParent, requestContext);
            }

            if (useEmbeddedWebView == WebViewPreference.System)
            {
                return new DefaultOsBrowserWebUi(
                    requestContext.ServiceBundle.PlatformProxy,
                    requestContext.Logger,
                    coreUIParent.SystemWebViewOptions);
            }

            // Use the old legacy WebUi by default on .NET classic
            return new InteractiveWebUI(coreUIParent, requestContext);
        }
    }
}
