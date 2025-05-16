//----------------------------------------------------------------------------------------
using Godot;
using System;
//----------------------------------------------------------------------------------------
public partial class UISwitchScene : Control
{
	//----------------------------------------------------------------------------------------
	public override void _Ready()
	{
        GetNode<Button>("UIBtnScene1").Pressed += OnBtnScene1Clicked;
        GetNode<Button>("UIBtnScene2").Pressed += OnBtnScene2Clicked;
	}
    //----------------------------------------------------------------------------------------
	protected void OnBtnScene1Clicked()
	{
        BtNodeRoot.ChangeScene("scene1");
	}
    //----------------------------------------------------------------------------------------
	protected void OnBtnScene2Clicked()
	{
        BtNodeRoot.ChangeScene("scene2");
	}
}
//----------------------------------------------------------------------------------------

