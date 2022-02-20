using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Collections;

namespace CGALDotNet.Collections
{
	/// <summary>
	/// 
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public sealed class NativeList<T> : NativeList, IList<T>, IEnumerable<T> where T : CGALObject, new()
    {
		/// <summary>
		/// 
		/// </summary>
		private List<T> m_list;

		/// <summary>
		/// 
		/// </summary>
        public NativeList() : base()
		{
			m_list = new List<T>();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="count"></param>
		public NativeList(int count) : base(count)
		{
			m_list = new List<T>(count);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ptr"></param>
		internal NativeList(IntPtr ptr) : base(ptr)
		{
			for(int i = 0; i < Count; i++)
            {
				var p = NativeList_Get(Ptr, i);
				var item = new T();
				item.Swap(p);
				m_list.Add(item);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public bool IsSync => Count == m_list.Count;

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
        public override string ToString()
        {
            return String.Format("[NativeList: Count={0}, Capacity={1}, IsSync={2}]", Count, Capacity, IsSync);
        }

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public IEnumerator<T> GetEnumerator()
		{
			for (int i = 0; i < Count; i++)
				yield return m_list[i];
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="i"></param>
		/// <returns></returns>
		public T this[int i]
		{
			get => Get(i);
			set => Set(i, value);
		}

		/// <summary>
		/// 
		/// </summary>
		public void Clear()
		{
			m_list.Clear();
			NativeList_Clear(Ptr);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="item"></param>
		public void Add(T item)
		{
			m_list.Add(item);
			NativeList_Add(Ptr, item.Ptr);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="items"></param>
		public void AddRange(IEnumerable<T> items)
		{
			foreach(var item in items)
				Add(item);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public NativeList<T> Copy()
        {
			var ptr = NativeList_Copy(Ptr);
			return new NativeList<T>(ptr);
        }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="array"></param>
		/// <param name="startIndex"></param>
		public void CopyTo(T[] array, int startIndex)
		{
			for (int i = startIndex; i < Count; i++)
				array[i] = Get(i);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public bool Contains(T item)
		{
			return m_list.Contains(item);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public int IndexOf(T item)
		{
			return m_list.IndexOf(item);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="index"></param>
		/// <param name="item"></param>
		public void Insert(int index, T item)
		{
			m_list.Insert(index, item);
			NativeList_Insert(Ptr, item.Ptr, index);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public bool Remove(T item)
		{
			var b1 = m_list.Remove(item);
			var b2 = NativeList_Remove(Ptr, item.Ptr);

			return b1 && b2;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="index"></param>
		public void RemoveAt(int index)
		{
			m_list.RemoveAt(index);
			NativeList_RemoveAt(Ptr, index);
		}

		/// <summary>
		/// 
		/// </summary>
		public void Reverse()
		{
			m_list.Reverse();
			NativeList_Reverse(Ptr);
		}

		/// <summary>
		/// 
		/// </summary>
		public void TrimExcess()
		{
			m_list.TrimExcess();
			NativeList_TrimExcess(Ptr);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="index"></param>
		/// <returns></returns>
		private T Get(int index)
		{
			return m_list[index];
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="index"></param>
		/// <param name="item"></param>
		private void Set(int index, T item)
		{
			m_list[index] = item;
			NativeList_Set(Ptr, index, item.Ptr);
		}
    }

	/// <summary>
	/// 
	/// </summary>
	public abstract class NativeList : CGALObject
	{
		/// <summary>
		/// 
		/// </summary>
		public NativeList()
		{
			Ptr = NativeList_Create();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="count"></param>
		public NativeList(int count)
		{
			Ptr = NativeList_CreateWithCount(count);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ptr"></param>
		internal NativeList(IntPtr ptr)
		{
			Ptr = ptr;
		}

		/// <summary>
		/// 
		/// </summary>
		public int Capacity => NativeList_Capacity(Ptr);

		/// <summary>
		/// 
		/// </summary>
		public int Count => NativeList_Count(Ptr);

		/// <summary>
		/// 
		/// </summary>
		public bool IsReadOnly => false;

		/// <summary>
		/// 
		/// </summary>
		protected override void ReleasePtr()
		{
			NativeList_Release(Ptr);
		}

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		protected static extern IntPtr NativeList_Create();

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		protected static extern IntPtr NativeList_CreateWithCount(int count);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		protected static extern void NativeList_Release(IntPtr listPtr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		protected static extern void NativeList_Add(IntPtr listPtr, IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		protected static extern void NativeList_AddRange(IntPtr listPtr, IntPtr[] ptr_array, int count);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		protected static extern int NativeList_Capacity(IntPtr listPtr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		protected static extern void NativeList_Clear(IntPtr listPtr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		protected static extern int NativeList_Count(IntPtr listPtr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		protected static extern bool NativeList_Contains(IntPtr listPtr, IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		protected static extern IntPtr NativeList_Copy(IntPtr listPtr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		protected static extern IntPtr NativeList_Get(IntPtr listPtr, int index);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		protected static extern void NativeList_Set(IntPtr listPtr, int index, IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		protected static extern int NativeList_IndexOf(IntPtr listPtr, IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		protected static extern void NativeList_Insert(IntPtr listPtr, IntPtr ptr, int index);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		protected static extern bool NativeList_Remove(IntPtr listPtr, IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		protected static extern void NativeList_RemoveAt(IntPtr listPtr, int index);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		protected static extern void NativeList_Reverse(IntPtr listPtr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		protected static extern void NativeList_TrimExcess(IntPtr listPtr);
	}
}
