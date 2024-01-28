using System.Runtime.InteropServices;

namespace DotnetXInput.Structs;

[StructLayout(LayoutKind.Sequential)]
public struct XInputState
{
	public uint PacketNumber;
	public XInputGamepad Gamepad;
}