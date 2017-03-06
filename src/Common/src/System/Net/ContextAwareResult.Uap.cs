// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace System.Net
{
    partial class ContextAwareResult
    {
#if MONO
        private void Uap_SafeCaptureIdentity()
#else
        private void SafeCaptureIdentity()
#endif
        {
            // WindowsIdentity is not supported on UAP
        }

#if MONO
        private void Uap_CleanupInternal()
#else
        private void CleanupInternal()
#endif
        {
            // Nothing to cleanup
        }
    }
}
