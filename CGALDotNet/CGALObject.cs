using System;
using System.Collections.Generic;
using System.Text;

using System.Runtime.InteropServices;

namespace CGALDotNet
{
    /// <summary>
    /// Base class for objects that referrence a CGAL object.
    /// </summary>
    public abstract class CGALObject : IDisposable
    {
        protected const string DLL_NAME = "CGALWrapper.dll";

        protected const CallingConvention CDECL = CallingConvention.Cdecl;

        /// <summary>
        /// The pointer to the unmanged CGAL object.
        /// </summary>
        private IntPtr m_ptr;

        /// <summary>
        /// Default constructor.
        /// </summary>
        internal CGALObject()
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
        /// Dispose the CGAL object.
        /// </summary>
        public void Dispose()
        {
            Release();
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Print some information about the object.
        /// </summary>
        /// <returns>Print some information about the object.</returns>
        public override string ToString()
        {
            return String.Format("[CGALObject: Ptr={0}, IsDiposed={1}]", Ptr.ToInt64(), IsDisposed);
        }

        /// <summary>
        /// Print the object into the console.
        /// </summary>
        public void Print()
        {
            var buider = new StringBuilder();
            Print(buider);
            Console.WriteLine(buider.ToString());
        }

        /// <summary>
        /// Print the object into a string builder.
        /// </summary>
        /// <param name="builder">The builder to print into.</param>
        public virtual void Print(StringBuilder builder)
        {
            builder.AppendLine(ToString());
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
        internal void Swap(IntPtr ptr)
        {
            if(IsDisposed)
                throw new CGALUnmanagedResourcesReleasedExeception("Can not swap when object has beed disposed.");

            if (m_ptr != IntPtr.Zero)
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
