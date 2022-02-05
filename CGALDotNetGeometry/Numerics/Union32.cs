using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

namespace CGALDotNetGeometry.Numerics
{

    [Serializable]
    [StructLayout(LayoutKind.Explicit)]
    public struct Union32 : IEquatable<Union32>
    {

        [FieldOffset(0)]
        public byte Byte0;

        [FieldOffset(1)]
        public byte Byte1;

        [FieldOffset(2)]
        public byte Byte2;

        [FieldOffset(3)]
        public byte Byte3;

        [FieldOffset(0)]
        public bool Bool;

        [FieldOffset(0)]
        public int Int;

        [FieldOffset(0)]
        public uint UInt;

        [FieldOffset(0)]
        public float Float;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Union32(bool b)
        {
            var u = new Union32();
            u.Bool = b;
            return u;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Union32(int i)
        {
            var u = new Union32();
            u.Int = i;
            return u;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Union32(uint ui)
        {
            var u = new Union32();
            u.UInt = ui;
            return u;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Union32(float f)
        {
            var u = new Union32();
            u.Float = f;
            return u;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Union32 u1, Union32 u2)
        {
            return u1.Int == u2.Int;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Union32 u1, Union32 u2)
        {
            return u1.Int != u2.Int;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj)
        {
            if (!(obj is Union32)) return false;
            Union32 v = (Union32)obj;
            return this == v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Union32 v)
        {
            return this == v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode()
        {
            return Int.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("[Union32: Bool={0}, Int={1}, UInt={2}, Float={3}]", Bool, Int, UInt, Float);
        }

    }
}
