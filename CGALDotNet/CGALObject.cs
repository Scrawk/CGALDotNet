using System;
using System.Collections.Generic;

namespace CGALDotNet
{
    /// <summary>
    /// Base class for objects that referrence a CGAL object.
    /// </summary>
    public abstract class CGALObject : IDisposable
    {
        /// <summary>
        /// The pointer to the unmanged CGAL object.
        /// </summary>
        private IntPtr m_ptr;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public CGALObject()
        {
            m_ptr = IntPtr.Zero;
        }

        /// <summary>
        /// Constructor taking a referrence to a CGAL object.
        /// </summary>
        /// <param name="ptr">A pointer to a CGAL object.</param>
        internal CGALObject(IntPtr ptr)
        {
            m_ptr = ptr;
        }

        /// <summary>
        /// The destuctor.
        /// </summary>
        ~CGALObject()
        {
            Release();
        }

        /// <summary>
        /// Has the object been disposed.
        /// </summary>
        public bool IsDisposed { get; private set; }

        /// <summary>
        /// Get the ptr to the CGAL object.
        /// </summary>
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

        /// <summary>
        /// Dispose the CGAl object.
        /// </summary>
        public void Dispose()
        {
            Release();
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Release the CGAL object.
        /// </summary>
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

        /// <summary>
        /// Swap the unmanaged pointer with another.
        /// The old ptr will be released first.
        /// </summary>
        /// <param name="ptr">The new ptr. The old ptr will be released first.</param>
        protected void Swap(IntPtr ptr)
        {
            ReleasePtr(Ptr);
            Ptr = ptr;
        }

        /// <summary>
        /// Allow derived class to release the unmanaged memory.
        /// </summary>
        protected abstract void ReleasePtr();

        /// <summary>
        /// Allow derived class to release the unmanaged memory.
        /// </summary>
        protected virtual void ReleasePtr(IntPtr ptr)
        {
            throw new CGALUnmanagedResourcesNotReleasedExeception("ReleasePtr not implemented.");
        }

        /// <summary>
        /// Check if the object is still valid.
        /// </summary>
        protected void CheckPtr()
        {
            if(IsDisposed)
                throw new CGALUnmanagedResourcesReleasedExeception("Unmanaged resources have been released.");

            if (m_ptr == IntPtr.Zero)
                throw new CGALUnmanagedResourcesReleasedExeception("Unmanaged resources have not been created.");
        }
    }
}
