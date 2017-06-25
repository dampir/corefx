// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Runtime.ConstrainedExecution;

namespace System.Threading
{
    public sealed partial class Thread
    {
#if MONO
        public ApartmentState Unix_GetApartmentState() => ApartmentState.Unknown;
#else
		public ApartmentState GetApartmentState() => ApartmentState.Unknown;
#endif

#if MONO
        private static Exception Unix_GetApartmentStateChangeFailedException() => new PlatformNotSupportedException(SR.PlatformNotSupported_COMInterop);
#else
		private static Exception GetApartmentStateChangeFailedException() => new PlatformNotSupportedException(SR.PlatformNotSupported_COMInterop);
#endif

#if MONO
        private bool Unix_TrySetApartmentStateUnchecked(ApartmentState state) => state == GetApartmentState();
#else
		private bool TrySetApartmentStateUnchecked(ApartmentState state) => state == GetApartmentState();
#endif

#if MONO
        public void Unix_DisableComObjectEagerCleanup() { }
#else
		public void DisableComObjectEagerCleanup() { }
#endif
    }
}
