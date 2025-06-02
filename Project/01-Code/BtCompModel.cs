//----------------------------------------------------------------------------------------
using Godot;
using System;
//----------------------------------------------------------------------------------------
public partial class BtCompModel : Node
{
	//----------------------------------------------------------------------------------------
	[Export]
	public Sprite3D MySprite = null;
	//----------------------------------------------------------------------------------------
	public void SetFaceDir_Up()
	{
		Vector3 OldRotation = MySprite.RotationDegrees;
		OldRotation.Y = 0;
		MySprite.RotationDegrees = OldRotation;
	}
	//----------------------------------------------------------------------------------------
	public void SetFaceDir_Down()
	{
		Vector3 OldRotation = MySprite.RotationDegrees;
		OldRotation.Y = 180;
		MySprite.RotationDegrees = OldRotation;
	}
	//----------------------------------------------------------------------------------------
	public void SetFaceDir_Left()
	{
		Vector3 OldRotation = MySprite.RotationDegrees;
		OldRotation.Y = 90;
		MySprite.RotationDegrees = OldRotation;
	}
	//----------------------------------------------------------------------------------------
	public void SetFaceDir_Right()
	{
		Vector3 OldRotation = MySprite.RotationDegrees;
		OldRotation.Y = -90;
		MySprite.RotationDegrees = OldRotation;
	}
	//----------------------------------------------------------------------------------------
}
//----------------------------------------------------------------------------------------
