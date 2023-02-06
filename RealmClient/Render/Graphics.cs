using System.Drawing;
using System.Numerics;
using System.Runtime.InteropServices;
using ImGuiNET;
using RealmClient.Render;
using RealmClient.Util;
using Silk.NET.Input;
using Silk.NET.Maths;
using Silk.NET.OpenGL;
using Silk.NET.OpenGL.Extensions.ImGui;
using Silk.NET.Windowing;

using System.Runtime.InteropServices;
namespace RealmClient.Render;

[StructLayout(LayoutKind.Explicit)]
public struct Color4 {
	[FieldOffset(0)] public float W;
	[FieldOffset(4)] public float X;
	[FieldOffset(8)] public float Y;
	[FieldOffset(12)] public float Z;
	[FieldOffset(0)] public Vector4 Vec4;

	public Color4(float w, float x, float y, float z) {
		W = w;
		X = x;
		Y = y;
		Z = z;
	}

	public Color4(Vector4 vec4) {
		Vec4 = vec4;
	}
}

public static class Graphics {
	private static bool test = false;
	public static Color4 BackgroundColor = new(0.1f, 0.1f, 0.1f, 1f);
	public static Scene Scene;
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

		Vector2 size;
		// The render functionl
		window.Render += delta => {
			imgui.Update((float)delta);
			size.X = window.Size.X;
			size.Y = window.Size.Y;
			gl.ClearColor(BackgroundColor.W, BackgroundColor.X, BackgroundColor.Y, BackgroundColor.Z);
			gl.Clear((uint)ClearBufferMask.ColorBufferBit);
			
			Scene.Render(gl, window, size);
			imgui.Render();
		};

		// The closing function
		window.Closing += () => {
			Settings.ClientSettings?.Dispose();
			Settings.AccountSettings?.Dispose();
			imgui?.Dispose();
			input?.Dispose();
			gl?.Dispose();
		};
  
		// Now that everything's defined, let's run this bad boy!
		window.Run();
	}

	public static void RunDemo() {
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
			ImGui.ShowDemoWindow();

			// Make sure ImGui renders too!
			imgui.Render();
		};

		// The closing function
		window.Closing += () => {
			Settings.ClientSettings?.Dispose();
			Settings.AccountSettings?.Dispose();
			imgui?.Dispose();
			input?.Dispose();
			gl?.Dispose();
		};

		// Now that everything's defined, let's run this bad boy!
		window.Run();
	}

	public const ImGuiWindowFlags Flags = ImGuiWindowFlags.NoCollapse | ImGuiWindowFlags.NoMove | ImGuiWindowFlags.NoResize /*| ImGuiWindowFlags.NoTitleBar*/;
	public static void ImGuiMainWindow(Vector2 size, int padding) {
		ImGui.SetNextWindowPos(new Vector2(padding, padding));
		size.X -= padding * 2;
		size.Y -= padding * 2;
		ImGui.SetNextWindowSize(size);
	}
	public static void ImGuiMainWindow(Vector2 size, float percent) {
		//ImGui.SetNextWindowPos(new Vector2(padding, padding));
		//size.X -= padding * 2;
		//size.Y -= padding * 2;
		//ImGui.SetNextWindowSize(size);
	}

	public static void CenterHorizontal(string text) {
		var windowWidth = ImGui.GetWindowWidth();
		var textWidth = ImGui.CalcTextSize(text).X;
		ImGui.SetCursorPosX((windowWidth - textWidth) * 0.5f);
	}

	public static string LabelPrefix(string label) {
		var width = ImGui.CalcItemWidth();
		var x = ImGui.GetCursorPosX();
		ImGui.Text(label);
		ImGui.SameLine();
		//ImGui.SetCursorPosX(x + width * 0.5f + ImGui.GetStyle().ItemInnerSpacing.X);
		ImGui.SetCursorPosX(x + width * 0.5f);
		ImGui.SetNextItemWidth(-1);
		var labelId = "##" + label;
		return labelId;
	}
}