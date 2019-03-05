using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace UsingSpan
{
	internal static class BufferGenerators
	{
		internal static byte[] GenerateWithConverters(int value, Coordinate coordinate, string data)
		{
			var valueArray = BitConverter.GetBytes(value);

			var pointSize = Marshal.SizeOf(coordinate);
			var pointArray = new byte[pointSize];
			var pointPtr = Marshal.AllocHGlobal(pointSize);

			Marshal.StructureToPtr(coordinate, pointPtr, true);
			Marshal.Copy(pointPtr, pointArray, 0, pointSize);
			Marshal.FreeHGlobal(pointPtr);

			var dataArray = Encoding.Unicode.GetBytes(data);

			var buffer = new List<byte>();
			buffer.AddRange(valueArray);
			buffer.AddRange(pointArray);
			buffer.AddRange(dataArray);

			return buffer.ToArray();
		}

		internal static byte[] GenerateWithStream(int value, Coordinate coordinate, string data)
		{
			using (var writer = new BinaryWriter(new MemoryStream(), Encoding.Unicode))
			{
				writer.Write(value);
				writer.Write(coordinate.X);
				writer.Write(coordinate.Y);
				writer.Write(coordinate.Z);
				writer.Write(data);
				writer.Flush();
				var stream = writer.BaseStream;
				var buffer = new byte[stream.Length];
				stream.Read(buffer, 0, (int)stream.Length);
				return buffer;
			}
		}

		internal static byte[] GenerateWithSpan(int value, Coordinate coordinate, string data)
		{
			var valueArray = MemoryMarshal.Cast<int, byte>(new Span<int>(new[] { value })).ToArray();
			var pointArray = MemoryMarshal.Cast<Coordinate, byte>(new Span<Coordinate>(new[] { coordinate })).ToArray();
			var dataArray = MemoryMarshal.Cast<char, byte>(data.AsSpan()).ToArray();

			var buffer = new List<byte>();
			buffer.AddRange(valueArray);
			buffer.AddRange(pointArray);
			buffer.AddRange(dataArray);

			return buffer.ToArray();
		}
	}
}
