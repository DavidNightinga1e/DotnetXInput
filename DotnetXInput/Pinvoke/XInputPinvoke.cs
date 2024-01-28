using System.Runtime.InteropServices;
using DotnetXInput.Structs;

namespace DotnetXInput.Pinvoke;

public static class XInputPinvoke
{
	[DllImport("Xinput1_4.dll")]
	public static extern void XInputEnable(bool enable);

	[DllImport("Xinput1_4.dll")]
	public static extern uint XInputGetBatteryInformation(
		uint userIndex,
		byte devType,
		ref XInputBatteryInformation batteryInformation);

	[DllImport("Xinput1_4.dll")]
	public static extern uint XInputGetCapabilities(
		uint userIndex,
		uint flags,
		ref XInputCapabilities capabilities);

	[DllImport("Xinput1_4.dll")]
	public static extern uint XInputGetState(uint userIndex, ref XInputState state);

	[DllImport("Xinput1_4.dll")]
	public static extern uint XInputGetKeystroke(uint userIndex, uint reserved, ref XInputKeystroke keystroke);

	[DllImport("Xinput1_4.dll")]
	public static extern uint XInputSetState(uint userIndex, ref XInputVibration vibration);
}