using System.Numerics;
using ImGuiNET;
using RealmClient.Assets;
using RealmClient.Render;
using RealmClient.Util;
using Silk.NET.OpenGL;
using Silk.NET.Windowing;

namespace RealmClient.Scenes; 

public class LoadingScene : Scene {
	public override void Render(GL gl, IWindow window, Vector2 size) {
		Graphics.ImGuiMainWindow(size, 100);
		ImGui.Begin("RotMG Loading", Graphics.Flags);
		var text = Log.CurrentStatus;
		var windowWidth = ImGui.GetWindowWidth();
		var textWidth = ImGui.CalcTextSize(text).X;
		var windowHeight = ImGui.GetWindowHeight();
		ImGui.SetCursorPosX((windowWidth - textWidth) * 0.5f);
		ImGui.SetCursorPosY(windowHeight * 0.25f);
		ImGui.Text(text);
		ImGui.End();
	}
}