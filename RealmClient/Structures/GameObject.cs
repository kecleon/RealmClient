using RealmClient.Assets;

namespace RealmClient.Structures;

public class GameObject {
	public Texture Texture;

	public GameObject(Texture texture) {
		Texture = texture;
	}
}