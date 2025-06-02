//----------------------------------------------------------------------------------------
using Godot;
using System;
//----------------------------------------------------------------------------------------
public class EActorMoveDir
{
	public const int MoveDir_None = 0;
	public const int MoveDir_Up = 1;
	public const int MoveDir_Down = 2;
	public const int MoveDir_Left = 3;
	public const int MoveDir_Right = 4;
}
//----------------------------------------------------------------------------------------
public partial class BtCompMove : Node
{
	[Export]
	public BtCompModel MyCompModel = null;
	//当前移动朝向
	public int CurMoveDirByInput = EActorMoveDir.MoveDir_None;
	public float MoveSpeed = 3.0f;
	//----------------------------------------------------------------------------------------
	public void SetMoveDir(int NewDir)
	{
		CurMoveDirByInput = NewDir;
	}
	//----------------------------------------------------------------------------------------
	public override void _Process(double delta)
	{
		if (CurMoveDirByInput == EActorMoveDir.MoveDir_None)
		{
			return;
		}
		//
		float deltaFloat = (float)delta;
		Vector3 deltaPos = Vector3.Zero;
		if (CurMoveDirByInput == EActorMoveDir.MoveDir_Up)
		{
			MyCompModel.SetFaceDir_Up();
			deltaPos = Vector3.Forward * MoveSpeed * deltaFloat;
		}
		else if (CurMoveDirByInput == EActorMoveDir.MoveDir_Down)
		{
			MyCompModel.SetFaceDir_Down();
			deltaPos = Vector3.Back * MoveSpeed * deltaFloat;
		}
		else if (CurMoveDirByInput == EActorMoveDir.MoveDir_Left)
		{
			MyCompModel.SetFaceDir_Left();
			deltaPos = Vector3.Left * MoveSpeed * deltaFloat;
		}
		else if (CurMoveDirByInput == EActorMoveDir.MoveDir_Right)
		{
			MyCompModel.SetFaceDir_Right();
			deltaPos = Vector3.Right * MoveSpeed * deltaFloat;
		}
		//
		Node3D parentNode = GetParent() as Node3D;
		parentNode.GlobalTranslate(deltaPos);
	}
	//----------------------------------------------------------------------------------------
}
//----------------------------------------------------------------------------------------
