using System;
using System.Collections.Generic;

namespace CGALDotNet
{
    public abstract class CGALObject : IDisposable
    {

        public CGALObject()
        {

        }

        internal CGALObject(IntPtr ptr)
        {
            Ptr = ptr;
        }

        ~CGALObject()
        {
            Release();
        }

        public bool IsDisposed { get; private set; }

        internal IntPtr Ptr { get; private set; }

        public void Dispose()
        {
            Release();
            GC.SuppressFinalize(this);
        }

        private void Release()
        {
            if (!IsDisposed)
            {
                ReleasePtr();
                Ptr = IntPtr.Zero;
                IsDisposed = true;
            }
        }

        protected abstract void ReleasePtr();

        protected void CheckPtr()
        {
            if (Ptr == IntPtr.Zero)
                throw new NullReferenceException("Unmanaged resources have been released.");
        }
    }
}
