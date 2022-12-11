using System.Drawing;
using RealmClient.Util;
using Silk.NET.Input;
using Silk.NET.Maths;
using Silk.NET.OpenGL;
using Silk.NET.OpenGL.Extensions.ImGui;
using Silk.NET.Windowing;

namespace RealmClient.Render;

public static class Graphics {
	public static void Run() {
		using IWindow window = Window.Create(WindowOptions.Default);
		window.Size = new Vector2D<int>(1280, 1024);

		ImGuiController imgui = null;
		GL gl = null;
		IInputContext input = null;

		// Our loading function
		window.Load += () => {
			imgui = new ImGuiController(
				gl = window.CreateOpenGL(), // load OpenGL
				window, // pass in our window
				input = window.CreateInput() // create an input context
			);
		};

		// Handle resizes
		window.FramebufferResize += s => {
			// Adjust the viewport to the new window size
			gl.Viewport(s);
		};

		// The render function
		window.Render += delta => {
			// Make sure ImGui is up-to-date
			imgui.Update((float)delta);

			// This is where you'll do any rendering beneath the ImGui context
			// Here, we just have a blank screen.
			gl.ClearColor(Color.FromArgb(255, (int)(0.1f * 255), (int)(0.1f * 255), (int)(0.1f * 255)));
			gl.Clear((uint)ClearBufferMask.ColorBufferBit);

			// This is where you'll do all of your ImGUi rendering
			// Here, we're just showing the ImGui built-in demo window.
			ImGuiNET.ImGui.ShowDemoWindow();

			// Make sure ImGui renders too!
			imgui.Render();
		};

		// The closing function
		window.Closing += () => {
			Settings.SaveSettings();
			imgui?.Dispose();
			input?.Dispose();
			gl?.Dispose();
		};

		// Now that everything's defined, let's run this bad boy!
		window.Run();
	}
}