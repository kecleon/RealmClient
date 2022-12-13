using AssetStudio;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace RealmClient.Assets;

//ripped and isolated pieces of AssetStudio's Texture2DConverter
public class Texture2DConverter {
	private ResourceReader reader;
	private int m_Width;
	private int m_Height;
	private TextureFormat m_TextureFormat;
	private int[] version;
	private BuildTarget platform;
	private int outPutSize;

	public Texture2DConverter(Texture2D m_Texture2D) {
		reader = m_Texture2D.image_data;
		m_Width = m_Texture2D.m_Width;
		m_Height = m_Texture2D.m_Height;
		m_TextureFormat = m_Texture2D.m_TextureFormat;
		version = m_Texture2D.version;
		platform = m_Texture2D.platform;
		outPutSize = m_Width * m_Height * 4;
	}

	private bool DecodeTexture2D(byte[] bytes) {
		if (reader.Size == 0 || m_Width == 0 || m_Height == 0) {
			return false;
		}

		bool flag = false;
		byte[] buff = BigArrayPool<byte>.Shared.Rent(reader.Size);
		reader.GetData(buff);
		switch (m_TextureFormat) {
			case TextureFormat.RGBA32: //test pass
				flag = DecodeRGBA32(buff, bytes);
				break;
		}

		BigArrayPool<byte>.Shared.Return(buff);
		return flag;
	}

	private bool DecodeRGBA32(byte[] image_data, byte[] buff) {
		for (int i = 0; i < outPutSize; i += 4) {
			buff[i] = image_data[i + 2];
			buff[i + 1] = image_data[i + 1];
			buff[i + 2] = image_data[i + 0];
			buff[i + 3] = image_data[i + 3];
		}

		return true;
	}

	public static Image<Bgra32> ConvertTextureToImage(Texture2D m_Texture2D, bool flip) {
		Texture2DConverter converter = new(m_Texture2D);
		byte[] buff = BigArrayPool<byte>.Shared.Rent(m_Texture2D.m_Width * m_Texture2D.m_Height * 4);
		try {
			if (converter.DecodeTexture2D(buff)) {
				var image = Image.LoadPixelData<Bgra32>(buff, m_Texture2D.m_Width, m_Texture2D.m_Height);
				if (flip) {
					image.Mutate(x => x.Flip(FlipMode.Vertical));
				}

				return image;
			}

			return null;
		}
		finally {
			BigArrayPool<byte>.Shared.Return(buff);
		}
	}

	public static byte[] ExportAsPngBytes(Texture2D item) {
		Image<Bgra32> image = ConvertTextureToImage(item, true);
		using Image<Bgra32> image1 = image;
		using MemoryStream file = new();
		image.SaveAsPng(file);
		return file.ToArray();
	}
}