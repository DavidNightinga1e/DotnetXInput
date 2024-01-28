namespace DotnetXInput.Controller;

public class DotnetXInputException : Exception
{
	public DotnetXInputException() : base("Unknown error occured")
	{
	}

	public DotnetXInputException(uint winErrorCode) : base($"WinError code {winErrorCode:X}")
	{
	}
}