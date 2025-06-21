using System.Text;

namespace Application.Common.Helpers;

public static class NamingConventionHelper
{
	public static string ToSnakeCase(string text)
	{
		if (string.IsNullOrEmpty(text))
		{
			return text;
		}

		StringBuilder stringBuilder = new();

		for (int i = 0; i < text.Length; i++)
		{
			char character = text[i];

			if (char.IsUpper(character))
			{
				if (i > 0)
				{
					stringBuilder.Append('_');
				}
			}

			stringBuilder.Append(char.ToLower(character));
		}

		return stringBuilder.ToString();
	}
}
