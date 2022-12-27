using System.Numerics;
using ImGuiNET;
using RealmClient.Render;
using Silk.NET.OpenGL;
using Silk.NET.Windowing;

namespace RealmClient.Scenes; 

public class DemoScene : Scene {
	public override void Render(GL gl, IWindow window, Vector2 size) {
		Graphics.ImGuiMainWindow(size, 10);
		ImGui.Begin("Scene Picker", Graphics.Flags);
		if (ImGui.Button("MainScene")) {
			Graphics.Scene = new MainScene();
			ImGui.End();
		}

		if (ImGui.Button("WorldScene")) {
			Graphics.Scene = new WorldScene();
			ImGui.End();
		}

		ImGui.ColorPicker4("Background", ref Graphics.BackgroundColor.Vec4);
		ImGui.End();
	}
}