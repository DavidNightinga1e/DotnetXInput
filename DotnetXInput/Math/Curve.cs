namespace DotnetXInput.Utilities;

public class Curve
{
	private float _pow;
	private float _angle;
	private float _deadZone;
	private float _clamp;

	public static Curve Linear => new Curve(1f, 1f, 0f, 1f);

	public Curve(float pow, float angle, float deadZone, float clamp)
	{
		_pow = pow;
		_angle = angle;
		_deadZone = deadZone;
		_clamp = clamp;
	}

	public float Evaluate(float t)
	{
		if (Math.Abs(t) < _deadZone)
			return 0;

		var result = MathF.Pow(t, _pow) * _angle;
		return Math.Clamp(result, -_clamp, _clamp);
	}
}