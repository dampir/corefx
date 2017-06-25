// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Runtime.ConstrainedExecution;

namespace System.Threading
{
    public sealed partial class Thread
    {
#if MONO
        public ApartmentState Windows_GetApartmentState() => _runtimeThread.GetApartmentState();
#else
		public ApartmentState GetApartmentState() => _runtimeThread.GetApartmentState();
#endif
	
#if MONO
        private static Exception Windows_GetApartmentStateChangeFailedException() =>
            new InvalidOperationException(SR.Thread_ApartmentState_ChangeFailed);
#else
		private static Exception Windows_GetApartmentStateChangeFailedException() =>
            new InvalidOperationException(SR.Thread_ApartmentState_ChangeFailed);
#endif

#if MONO
        private bool Windows_TrySetApartmentStateUnchecked(ApartmentState state) => _runtimeThread.TrySetApartmentState(state);
#else
		private bool TrySetApartmentStateUnchecked(ApartmentState state) => _runtimeThread.TrySetApartmentState(state);
#endif
	
#if MONO
        public void Windows_DisableComObjectEagerCleanup() => _runtimeThread.DisableComObjectEagerCleanup();
#else
		public void DisableComObjectEagerCleanup() => _runtimeThread.DisableComObjectEagerCleanup();
#endif
    }
}
