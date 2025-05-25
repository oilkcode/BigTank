//----------------------------------------------------------------------------------------
using Godot;
using System;
//----------------------------------------------------------------------------------------
public partial class UiMain : Control
{
	private Label m_UIPosX = null;
	private Label m_UIPosY = null;
	private Label m_UIPosZ = null;
	//----------------------------------------------------------------------------------------
	public override void _Ready()
	{
		m_UIPosX = GetNode<Label>("UIPosX");
		m_UIPosY = GetNode<Label>("UIPosY");
		m_UIPosZ = GetNode<Label>("UIPosZ");
		m_UIPosX.Text = "0";
		m_UIPosY.Text = "0";
		m_UIPosZ.Text = "0";
	}
	//----------------------------------------------------------------------------------------
	public override void _Process(double delta)
	{
		float deltaFloat = (float)delta;
		//获取当前3D摄像机
		Camera3D curCamera = GetViewport().GetCamera3D();
		if (curCamera != null)
		{
			Vector3 globalPos = curCamera.GlobalTransform.Origin;
			m_UIPosX.Text = globalPos.X.ToString("0.00");
			m_UIPosY.Text = globalPos.Y.ToString("0.00");
			m_UIPosZ.Text = globalPos.Z.ToString("0.00");
		}
	}
}
//----------------------------------------------------------------------------------------
