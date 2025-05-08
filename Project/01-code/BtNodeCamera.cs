//----------------------------------------------------------------------------------------
using Godot;
using System;
//----------------------------------------------------------------------------------------
public partial class BtNodeCamera : Camera3D
{
	//----------------------------------------------------------------------------------------
	[Export]
	public float MoveSpeed = 5.0f;
	[Export]
	public float RoteteSensitivity = 0.1f;
	//----------------------------------------------------------------------------------------
	public override void _Ready()
	{

	}
	//----------------------------------------------------------------------------------------
	public override void _Process(double delta)
	{
		float deltaFloat = (float)delta;
		Vector3 forwardDir = -GlobalTransform.Basis.Z; // 注意取反
		Vector3 rightDir = GlobalTransform.Basis.X;
		//GD.Print("Camera Forward: " + forwardDir);
		//GD.Print("Camera Right: " + rightDir);
		//
		var direction = Vector3.Zero;
		// 获取键盘输入
		if (Input.IsActionPressed("move_forward"))
			direction.Z += 1;
		if (Input.IsActionPressed("move_backward"))
			direction.Z -= 1;
		if (Input.IsActionPressed("move_left"))
			direction.X -= 1;
		if (Input.IsActionPressed("move_right"))
			direction.X += 1;
		// 将方向向量转换为全局坐标系
		direction = direction.Normalized();
		//GD.Print("Camera direction: " + direction);
		
		Vector3 deltaPos = forwardDir * direction.Z * MoveSpeed * deltaFloat + rightDir * direction.X * MoveSpeed * deltaFloat;
		// 更新摄像机位置
		GlobalTranslate(deltaPos);
	}
	//----------------------------------------------------------------------------------------
	public override void _Input(InputEvent @event)
	{
		// 鼠标旋转控制
		if (@event is InputEventMouseMotion mouseMotion)
		{
			if (Input.IsActionPressed("mouse_right_btn"))
			{
				float NewX = Mathf.Clamp(RotationDegrees.X - mouseMotion.Relative.Y * RoteteSensitivity, -90, 90);
				float NewY = RotationDegrees.Y - mouseMotion.Relative.X * RoteteSensitivity;
				RotationDegrees = new Vector3(NewX, NewY, RotationDegrees.Z);
			}
		}
	}
	//----------------------------------------------------------------------------------------
}
//----------------------------------------------------------------------------------------

