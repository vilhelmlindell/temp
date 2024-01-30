using Godot;

namespace Stellar;

public partial class Camera : Camera3D
{
	[Export] public Node3D TargetNode;
	[Export] public float DistanceToTarget = 10f;
	[Export] private float pitchSensitivity = 1f;
	[Export] private float yawSensitivity = 1f;

	private const float SensitivityFactor = 0.01f;
	
	public override void _Ready()
	{
	}

	public override void _Process(double delta)
	{
		if (Input.IsKeyPressed(Key.W))
		{
			Rotation -= new Vector3(pitchSensitivity * SensitivityFactor, 0f, 0f);
		}
		if (Input.IsKeyPressed(Key.S))
		{
			Rotation -= new Vector3(-pitchSensitivity * SensitivityFactor, 0f, 0f);
		}
		
		if (Input.IsKeyPressed(Key.A))
		{
			Rotation -= new Vector3(0f, yawSensitivity * SensitivityFactor, 0f);
		}
		if (Input.IsKeyPressed(Key.D))
		{
			Rotation -= new Vector3(0f, -yawSensitivity * SensitivityFactor, 0f);
		}

		RotationDegrees = new Vector3(Mathf.Clamp(RotationDegrees.X, -90f, -0f), RotationDegrees.Y, 0f);
		
		Vector3 displacement = DisplacementToTarget();
		GD.Print(displacement);
		Position = TargetNode.GlobalPosition + displacement;
		GD.Print(Position);
	}

	private Vector3 DisplacementToTarget()
	{
		float horizontalDistance = Mathf.Cos(Rotation.X) * DistanceToTarget;
		
		float y = -Mathf.Sin(Rotation.X) * DistanceToTarget;
		float x = Mathf.Sin(Rotation.Y) * horizontalDistance;
		float z = Mathf.Cos(Rotation.Y) * horizontalDistance;

		return new Vector3(x, y, z);
	}
}