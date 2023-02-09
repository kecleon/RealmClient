using System.Numerics;
using ImGuiNET;
using RealmClient.Render;
using RealmClient.Util;
using Silk.NET.OpenGL;
using Silk.NET.Windowing;

namespace RealmClient.Scenes; 

public class LoadingScene : Scene {
	public override void Start() {
	}

	public override void Render(GL gl, IWindow window, Vector2 size) {
		Graphics.ImGuiMainWindow(size, 300);
		ImGui.Begin("RotMG Loading", Graphics.Flags);
		var text = Log.GetStatus();
		Graphics.CenterHorizontal(text);
		var windowHeight = ImGui.GetWindowHeight();
		ImGui.SetCursorPosY(windowHeight * 0.25f);
		ImGui.Text(text);
		ImGui.End();
	}
}