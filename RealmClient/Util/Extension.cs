using System.Security.Cryptography;
using System.Text;

namespace RealmClient.Util;

public static class Extension {
	public static byte[] Hash(this string input) {
		using SHA1 sha1 = SHA1.Create();
		// Compute the SHA-1 hash of the input string
		byte[] hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(input));

		// Truncate the hash to 20 bytes
		Array.Resize(ref hash, 20);

		// Return the unique byte sequence
		return hash;
	}

	public static string ToHexString(this byte[] bytes) {
		// Create a string builder with the expected length
		StringBuilder hexString = new StringBuilder(bytes.Length * 2);

		// Loop through each byte in the array and append its hexadecimal representation to the string builder
		foreach (byte b in bytes) {
			hexString.Append($"{b:x2}");
		}

		// Return the resulting hexadecimal string
		return hexString.ToString();
	}

	public static byte[] ToByteArray(this string hexString) {
		// Check that the input string has an even number of characters
		if (hexString.Length % 2 != 0) {
			throw new ArgumentException("The hexadecimal string must have an even number of characters.");
		}

		// Create a byte array with the expected length
		byte[] bytes = new byte[hexString.Length / 2];

		// Loop through each pair of characters in the input string and convert them to a byte
		for (int i = 0; i < hexString.Length; i += 2) {
			bytes[i / 2] = Convert.ToByte(hexString.Substring(i, 2), 16);
		}

		// Return the resulting byte array
		return bytes;
	}
}