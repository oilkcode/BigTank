//----------------------------------------------------------------------------------------
using Godot;
using System;
//----------------------------------------------------------------------------------------
public partial class BtCompInput : Node
{
	//----------------------------------------------------------------------------------------
	//值为1表示玩家A，值为2表示玩家B。值为0表示非玩家。
	[Export]
	public int MyInputType = 0;
	[Export]
	public BtCompMove MyCompMove = null;
	//当前按键输入的结果
	public Vector3 MyInputValue = Vector3.Zero;
	//----------------------------------------------------------------------------------------
	public override void _Process(double delta)
	{
		// 获取键盘输入
		if (MyInputType == 1)
		{
			MyInputValue = Vector3.Zero;
			if (Input.IsActionPressed("player_a_move_up"))
				MyInputValue.Z += 1;
			if (Input.IsActionPressed("player_a_move_down"))
				MyInputValue.Z -= 1;
			if (Input.IsActionPressed("player_a_move_left"))
				MyInputValue.X -= 1;
			if (Input.IsActionPressed("player_a_move_right"))
				MyInputValue.X += 1;
			Func_MakeMove();
		}
		else if (MyInputType == 2)
		{
			MyInputValue = Vector3.Zero;
			if (Input.IsActionPressed("player_b_move_up"))
				MyInputValue.Z += 1;
			if (Input.IsActionPressed("player_b_move_down"))
				MyInputValue.Z -= 1;
			if (Input.IsActionPressed("player_b_move_left"))
				MyInputValue.X -= 1;
			if (Input.IsActionPressed("player_b_move_right"))
				MyInputValue.X += 1;
			Func_MakeMove();
		}
	}
	//----------------------------------------------------------------------------------------
	protected void Func_MakeMove()
	{
		int FinalDir = EActorMoveDir.MoveDir_None;
		if (MyInputValue.Z > 0.1f)
		{
			FinalDir = EActorMoveDir.MoveDir_Up;
		}
		else if (MyInputValue.Z < -0.1f)
		{
			FinalDir = EActorMoveDir.MoveDir_Down;
		}
		else if (MyInputValue.X < -0.1f)
		{
			FinalDir = EActorMoveDir.MoveDir_Left;
		}
		else if (MyInputValue.X > 0.1f)
		{
			FinalDir = EActorMoveDir.MoveDir_Right;
		}
		//GD.Print("BtCompInput: Func_MakeMove " + FinalDir);
		MyCompMove.SetMoveDir(FinalDir);
	}
	//----------------------------------------------------------------------------------------
}
//----------------------------------------------------------------------------------------
