using System.Runtime.InteropServices;

namespace DotnetXInput.Structs;

[StructLayout(LayoutKind.Sequential)]
public struct XInputKeystroke
{
	public ushort VirtualKey;
	public char Unicode;
	public ushort Flags;
	public byte UserIndex;
	public byte HidCode;
}