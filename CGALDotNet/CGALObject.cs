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

        protected IntPtr GetCheckedPtr()
        {
            CheckPtr();
            return Ptr;
        }

        protected void SetPtr(IntPtr ptr)
        {
            Ptr = ptr;
        }

        public void Dispose()
        {
            Release();
            GC.SuppressFinalize(this);
        }

        private void Release()
        {
            if (!IsDisposed)
            {
                if(Ptr != IntPtr.Zero)
                    ReleasePtr();

                Ptr = IntPtr.Zero;
                IsDisposed = true;
            }
        }

        protected abstract void ReleasePtr();

        protected void CheckPtr()
        {
            if(IsDisposed)
                throw new CGALUnmanagedResourcesReleasedExeception("Unmanaged resources have been released.");

            if (Ptr == IntPtr.Zero)
                throw new CGALUnmanagedResourcesReleasedExeception("Unmanaged resources have not been created.");
        }
    }
}
