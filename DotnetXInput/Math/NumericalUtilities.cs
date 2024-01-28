namespace DotnetXInput.Utilities;

public static class NumericalUtilities
{
	public static float Normalize(this short value)
	{
		return (float)value / short.MaxValue;
	}	
	
	public static float Normalize(this byte value)
	{
		return (float)value / byte.MaxValue;
	}
}