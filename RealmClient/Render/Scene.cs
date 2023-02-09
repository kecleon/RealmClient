using System.Numerics;
using Silk.NET.OpenGL;
using Silk.NET.Windowing;

namespace RealmClient.Render; 

public abstract class Scene {
	public abstract void Render(GL gl, IWindow window, Vector2 size);

	public abstract void Start();
}