namespace DotnetXInput.Pinvoke;

public enum XInputBatteryType : byte
{
	Disconnected = 0x00,
	Wired = 0x01,
	Alkaline = 0x02,
	NiMh = 0x03,
	Unknown = 0xFF
}