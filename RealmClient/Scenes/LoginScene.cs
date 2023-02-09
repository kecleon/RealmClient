using System.Numerics;
using System.Text;
using ImGuiNET;
using RealmClient.Render;
using Silk.NET.OpenGL;
using Silk.NET.Windowing;

namespace RealmClient.Scenes; 

public class LoginScene: Scene {
	private byte[] EmailInput = new byte[256]; //can't remember guid cap so this is a generous bet
	private byte[] PasswordInput = new byte[256];
	private bool Steam;
	private bool TriedLogin = false;
	private int Focus = 0;
	private Account Account;
	public override void Start() {
		var account = Launcher.Client.Account;
		if (!string.IsNullOrEmpty(account.Guid) && !string.IsNullOrEmpty(account.Password)) {
			EmailInput = Encoding.ASCII.GetBytes(account.Guid);
			PasswordInput = Encoding.ASCII.GetBytes(account.Password);
		}
	}

	public override void Render(GL gl, IWindow window, Vector2 size) {
		Graphics.ImGuiMainWindow(size, 10);
		ImGui.Begin("Login", Graphics.Flags);

		if (TriedLogin) {
			ImGui.BeginDisabled();
		}

		if (Focus == 0) {
			ImGui.SetKeyboardFocusHere();
		}

		var test = ImGui.InputText(Graphics.LabelPrefix("example: "), EmailInput, (uint)EmailInput.Length, ImGuiInputTextFlags.EnterReturnsTrue);

		/*var emailEnter = ImGui.InputText("a", EmailInput, (uint)EmailInput.Length, ImGuiInputTextFlags.EnterReturnsTrue);
		if (emailEnter) {
			Focus = 1;
		}

		if (Focus == 1) {
			ImGui.SetKeyboardFocusHere();
		}

		var passEnter = ImGui.InputText("b", PasswordInput, (uint)PasswordInput.Length, ImGuiInputTextFlags.EnterReturnsTrue | ImGuiInputTextFlags.Password);

		ImGui.Checkbox("Steam", ref Steam);
		if (TriedLogin) {
			ImGui.EndDisabled();
		}

		if (passEnter) {
			TriedLogin = true;
			Account = new Account(Encoding.ASCII.GetString(EmailInput), Encoding.ASCII.GetString(PasswordInput), Steam);
			Launcher.Client.Account = Account;
			if (Account.TryLauncherLogin()) {
				Account.LoadLauncherAccountUrls();
				Graphics.Scene = new MainScene();
				Account.LoadLauncherPlayUrls();
				Account.LoadClientUrls();
			} else {
				TriedLogin = false;
			}
		}*/
	}
}