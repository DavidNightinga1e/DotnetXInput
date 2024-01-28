using System.Runtime.InteropServices;
using DotnetXInput.Pinvoke;

namespace DotnetXInput.Structs;

[StructLayout(LayoutKind.Sequential)]
public struct XInputBatteryInformation
{
	public XInputBatteryType BatteryType;
	public XInputBatteryLevel BatteryLevel;
}