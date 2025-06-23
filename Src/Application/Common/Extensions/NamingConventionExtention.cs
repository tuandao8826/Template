using System.Text;

namespace Application.Common.Extensions;

public static class NamingConventionExtention
{
	/// <summary>
	/// Ex: RolePermission -> role_permission
	/// </summary>
	public static string ToSnakeCase(this string text)
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
