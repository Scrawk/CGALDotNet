using System;
using System.Collections.Generic;

namespace CGALDotNet
{
    public abstract class CGALObject : IDisposable
    {

        private IntPtr m_ptr;

        public CGALObject()
        {
            m_ptr = IntPtr.Zero;
        }

        internal CGALObject(IntPtr ptr)
        {
            m_ptr = ptr;
        }

        ~CGALObject()
        {
            Release();
        }

        public bool IsDisposed { get; private set; }

        internal IntPtr Ptr 
        { 
            get
            {
                CheckPtr();
                return m_ptr;
            }
            private protected set
            {
                m_ptr = value;
            }
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
                if(m_ptr != IntPtr.Zero)
                    ReleasePtr();

                m_ptr = IntPtr.Zero;
                IsDisposed = true;
            }
        }

        protected abstract void ReleasePtr();

        protected void CheckPtr()
        {
            if(IsDisposed)
                throw new CGALUnmanagedResourcesReleasedExeception("Unmanaged resources have been released.");

            if (m_ptr == IntPtr.Zero)
                throw new CGALUnmanagedResourcesReleasedExeception("Unmanaged resources have not been created.");
        }
    }
}
