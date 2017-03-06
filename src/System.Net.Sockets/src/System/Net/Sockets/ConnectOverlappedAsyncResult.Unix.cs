// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading;
using Microsoft.Win32;

namespace System.Net.Sockets
{
    // ConnectOverlappedAsyncResult - used to take care of storage for async Socket BeginConnect call.
    internal sealed partial class ConnectOverlappedAsyncResult : BaseOverlappedAsyncResult
    {
#if MONO
        private void Unix_CompletionCallback(SocketError errorCode)
#else
        public void CompletionCallback(SocketError errorCode)
#endif
        {
            CompletionCallback(0, errorCode);
        }

        // This method is called by base.CompletionPortCallback base.OverlappedCallback as part of IO completion
#if MONO
        private object Unix_PostCompletion(int numBytes)
#else
        internal override object PostCompletion(int numBytes)
#endif
        {
            var errorCode = (SocketError)ErrorCode;
            if (errorCode == SocketError.Success)
            {
                var socket = (Socket)AsyncObject;
                socket.SetToConnected();
                return socket;
            }

            return null;
        }
    }
}
