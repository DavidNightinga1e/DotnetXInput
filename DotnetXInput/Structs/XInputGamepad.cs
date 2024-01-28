using System.Runtime.InteropServices;
using DotnetXInput.Pinvoke;

namespace DotnetXInput.Structs;

[StructLayout(LayoutKind.Sequential)]
public struct XInputGamepad
{
	public XInputButton Buttons;
	public byte LeftTrigger;
	public byte RightTrigger;
	public short ThumbLX;
	public short ThumbLY;
	public short ThumbRX;
	public short ThumbRY;
}