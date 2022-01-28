using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace CGALDotNet.Collections
{

	public sealed class UnmanagedList<T> : UnmanagedList where T : CGALObject, new()
    {
		public UnmanagedList() : base()
		{

		}

		public UnmanagedList(int count) : base(count)
		{

		}

		internal UnmanagedList(IntPtr ptr) : base(ptr)
		{
	
		}
	}

	public abstract class UnmanagedList : CGALObject
	{

		public UnmanagedList()
		{
			Ptr = UnmanagedList_Create();
		}

		public UnmanagedList(int count)
		{
			Ptr = UnmanagedList_CreateWithCount(count);
		}

		internal UnmanagedList(IntPtr ptr)
		{
			Ptr = ptr;
		}

		public int Capacity => UnmanagedList_Capacity(Ptr);

		public int Count => UnmanagedList_Count(Ptr);

		public void Add(IntPtr ptr)
		{
			UnmanagedList_Add(Ptr, ptr);
		}

		public void AddRange(IntPtr[] ptr_array, int count)
		{
			UnmanagedList_AddRange(Ptr, ptr_array, count);
		}

		public void Clear()
		{
			UnmanagedList_Clear(Ptr);
		}

		public bool Contains(IntPtr ptr)
		{
			return UnmanagedList_Contains(Ptr, ptr);
		}

		public IntPtr Get(int index)
		{
			return UnmanagedList_Get(Ptr, index);
		}

		public void Set(int index, IntPtr ptr)
		{
			UnmanagedList_Set(Ptr, index, ptr);
		}

		public int IndexOf(IntPtr ptr)
		{
			return UnmanagedList_IndexOf(Ptr, ptr);
		}

		public void Insert(IntPtr ptr, int index)
		{
			UnmanagedList_Insert(Ptr, ptr, index);
		}

		public void Remove(IntPtr ptr)
		{
			UnmanagedList_Remove(Ptr, ptr);
		}

		public void RemoveAt(int index)
		{
			UnmanagedList_RemoveAt(Ptr, index);
		}

		public void Reverse()
		{
			UnmanagedList_Reverse(Ptr);
		}

		public void TrimExcess()
		{
			UnmanagedList_TrimExcess(Ptr);
		}

		protected override void ReleasePtr()
		{
			UnmanagedList_Release(Ptr);
		}

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern IntPtr UnmanagedList_Create();

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern IntPtr UnmanagedList_CreateWithCount(int count);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void UnmanagedList_Release(IntPtr listPtr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void UnmanagedList_Add(IntPtr listPtr, IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void UnmanagedList_AddRange(IntPtr listPtr, IntPtr[] ptr_array, int count);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern int UnmanagedList_Capacity(IntPtr listPtr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void UnmanagedList_Clear(IntPtr listPtr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern int UnmanagedList_Count(IntPtr listPtr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern bool UnmanagedList_Contains(IntPtr listPtr, IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern IntPtr UnmanagedList_Copy(IntPtr listPtr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern IntPtr UnmanagedList_Get(IntPtr listPtr, int index);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void UnmanagedList_Set(IntPtr listPtr, int index, IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern int UnmanagedList_IndexOf(IntPtr listPtr, IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void UnmanagedList_Insert(IntPtr listPtr, IntPtr ptr, int index);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void UnmanagedList_Remove(IntPtr listPtr, IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void UnmanagedList_RemoveAt(IntPtr listPtr, int index);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void UnmanagedList_Reverse(IntPtr listPtr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void UnmanagedList_TrimExcess(IntPtr listPtr);
	}
}
