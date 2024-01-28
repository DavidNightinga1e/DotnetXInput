using System.Runtime.InteropServices;

namespace DotnetXInput.Structs;

[StructLayout(LayoutKind.Sequential)]
public struct XInputVibration
{
	public ushort LeftMotorSpeed;
	public ushort RightMotorSpeed;
}