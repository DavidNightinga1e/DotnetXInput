namespace DotnetXInput.Pinvoke;

[System.Flags]
public enum XInputCapabilitiesFlags : ushort
{
	VoiceSupported = 0x0004,
	ForceFeedbackSupported = 0x0001,
	Wireless = 0x0002,
	PmdSupported = 0x0008,
	NoNavigation = 0x0010
}