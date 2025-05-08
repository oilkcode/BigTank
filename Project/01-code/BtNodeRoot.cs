//----------------------------------------------------------------------------------------
using Godot;
using System;
//----------------------------------------------------------------------------------------
public partial class BtNodeRoot : Node
{
	//----------------------------------------------------------------------------------------
	private static BtNodeRoot ms_NodeRoot = null;
	private Node m_NodeCurScene = null;
	//----------------------------------------------------------------------------------------
	public override void _Ready()
	{
		ms_NodeRoot = this;
		Func_InitSystemSetting();
	}
	//----------------------------------------------------------------------------------------
	public override void _Process(double delta)
	{
		if (Input.IsActionPressed("move_forward"))
		{
			ChangeScene("scene1");
		}
		else if (Input.IsActionPressed("move_backward"))
		{
			ChangeScene("scene2");
		}
	}
	//----------------------------------------------------------------------------------------
	//系统设置
	private void Func_InitSystemSetting()
	{
		//Input.MouseMode = Input.MouseModeEnum.Captured; //隐藏并锁定鼠标光标（常用于第一人称游戏）
		Input.MouseMode = Input.MouseModeEnum.Visible; //显示鼠标光标
	}
	//----------------------------------------------------------------------------------------
	//卸载旧的Scene，加载新的Scene
	private void Func_ChangeScene(string SceneName)
	{
		string FullName = string.Format("res://02-scene/{0}.tscn", SceneName);
		PackedScene NewPackedScene = GD.Load<PackedScene>(FullName);
		if (NewPackedScene == null)
		{
			GD.Print(string.Format("BtNodeRoot::Func_ChangeScene : Load Scene Failed [{0}]", SceneName));
			return;
		}
		Node NewScene = NewPackedScene.Instantiate();
		if (NewScene == null)
		{
			GD.Print(string.Format("BtNodeRoot::Func_ChangeScene : Scene Instantiate Failed [{0}]", SceneName));
			return;
		}
		if (m_NodeCurScene != null)
		{
			m_NodeCurScene.QueueFree();
			m_NodeCurScene = null;
		}
		m_NodeCurScene = NewScene;
		AddChild(NewScene);
	}
	//----------------------------------------------------------------------------------------
	//卸载旧的Scene，加载新的Scene
	public static void ChangeScene(string SceneName)
	{
		ms_NodeRoot.Func_ChangeScene(SceneName);
	}
	//----------------------------------------------------------------------------------------
}
//----------------------------------------------------------------------------------------
