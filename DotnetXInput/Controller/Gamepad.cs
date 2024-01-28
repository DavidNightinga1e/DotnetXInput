using DotnetXInput.Pinvoke;
using DotnetXInput.Structs;
using DotnetXInput.Utilities;

namespace DotnetXInput.Controller;

public class Gamepad
{
	private readonly uint _userId;

	private XInputButton _previousButtonsState;
	private XInputButton _currentButtonsState;
	private XInputBatteryInformation _batteryInformation;
	private XInputState _state;
	private XInputVibration _vibration;

	private readonly Dictionary<Axis, Curve> _curves = new();

	public Gamepad(uint userId)
	{
		_userId = userId;

		var axes = Enum.GetValues<Axis>();
		foreach (Axis axis in axes) 
			_curves[axis] = Curve.Linear;
	}

	/// <summary>
	/// Update the Gamepad to receive new button presses and axis movements
	/// </summary>
	public bool UpdateState()
	{
		uint result = XInputPinvoke.XInputGetState(_userId, ref _state);
		bool isValid = ProcessResult(result);
		if (isValid)
		{
			_previousButtonsState = _currentButtonsState;
			_currentButtonsState = _state.Gamepad.Buttons;
		}
		return isValid;
	}

	/// <summary>
	/// Returns raw state from Xinput1_4.dll 
	/// </summary>
	public XInputState GetState() => _state;

	/// <summary>
	/// Set motor vibration with [0, 1] value. To disable motor call this method again with 0 as
	/// an argument 
	/// </summary>
	public bool SetVibration(float leftMotorNormalized, float rightMotorNormalized)
	{
		_vibration.LeftMotorSpeed = (ushort)(leftMotorNormalized * ushort.MaxValue);
		_vibration.RightMotorSpeed = (ushort)(rightMotorNormalized * ushort.MaxValue);
		uint result = XInputPinvoke.XInputSetState(_userId, ref _vibration);
		return ProcessResult(result);
	}

	/// <summary>
	/// Returns True if button was pressed in this state update. Will return False
	/// next state update if button is being held
	/// </summary>
	public bool IsButtonPressed(XInputButton button)
	{
		return _currentButtonsState.HasFlag(button) && !_previousButtonsState.HasFlag(button);
	}

	/// <summary>
	/// Returns True if button was released in this state update
	/// </summary>
	public bool IsButtonReleased(XInputButton button)
	{
		return !_currentButtonsState.HasFlag(button) && _previousButtonsState.HasFlag(button);
	}

	/// <summary>
	/// Returns True if button was pressed in this state update. Will return True while button
	/// is held
	/// </summary>
	public bool IsButtonHold(XInputButton button)
	{
		return _currentButtonsState.HasFlag(button);
	}

	/// <summary>
	/// Applies Curve to current input and returns normalized value
	/// </summary>
	public float GetAxisValue(Axis axis)
	{
		float axisNormalizedValue = GetAxisNormalizedValue(axis);
		Curve curve = _curves[axis];
		return curve.Evaluate(axisNormalizedValue);
	}

	/// <summary>
	/// Returns normalized value without calculating Curves. Consider using GetAxisValue
	/// </summary>
	public float GetAxisNormalizedValue(Axis axis) =>
		axis switch
		{
			Axis.LeftStickHorizontal => _state.Gamepad.ThumbLX.Normalize(),
			Axis.LeftStickVertical => _state.Gamepad.ThumbLY.Normalize(),
			Axis.RightStickHorizontal => _state.Gamepad.ThumbRX.Normalize(),
			Axis.RightStickVertical => _state.Gamepad.ThumbRY.Normalize(),
			Axis.LeftTrigger => _state.Gamepad.LeftTrigger.Normalize(),
			Axis.RightTrigger => _state.Gamepad.RightTrigger.Normalize(),
			_ => throw new ArgumentOutOfRangeException(nameof(axis), axis, null)
		};

	public XInputBatteryInformation GetBatteryInformation()
	{
		XInputPinvoke.XInputGetBatteryInformation(_userId, 0, ref _batteryInformation);
		return _batteryInformation;
	}
	
	private bool ProcessResult(uint result)
	{
		return result switch
		{
			WinError.ERROR_SUCCESS => true,
			WinError.ERROR_DEVICE_NOT_CONNECTED => false,
			_ => throw new DotnetXInputException(result)
		};
	}
}