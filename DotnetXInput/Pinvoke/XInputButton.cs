namespace DotnetXInput.Pinvoke;

[System.Flags]
public enum XInputButton : ushort
{
	Up = 0x0001,
	Down = 0x0002,
	Left = 0x0004,
	Right = 0x0008,
	Start = 0x0010,
	Back = 0x0020,
	LeftStick = 0x0040,
	RightStick = 0x0080,
	LeftTrigger = 0x0100,
	RightTrigger = 0x0200,
	A = 0x1000,
	B = 0x2000,
	X = 0x4000,
	Y = 0x8000
}