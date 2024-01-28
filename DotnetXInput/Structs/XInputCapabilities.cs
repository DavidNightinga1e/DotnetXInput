using System.Runtime.InteropServices;
using DotnetXInput.Pinvoke;

namespace DotnetXInput.Structs;

[StructLayout(LayoutKind.Sequential)]
public struct XInputCapabilities
{
	public byte Type;
	public byte SubType;
	public XInputCapabilitiesFlags Flags;
	public XInputGamepad Gamepad;
	public XInputVibration Vibration;
}