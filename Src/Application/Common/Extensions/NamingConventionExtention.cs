using System.Text;

namespace Application.Common.Extensions;

public static class NamingConventionExtention
{
	/// <summary>
	/// Ex: RolePermission -> role_permission
	/// </summary>
	public static string ToSnakeCase(this string str)
	{
		if (string.IsNullOrEmpty(str))
		{
			return str;
		}

		StringBuilder stringBuilder = new();

		for (int i = 0; i < str.Length; i++)
		{
			char character = str[i];

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

	/// <summary>
	/// Ex: UserName -> userName
	/// </summary>
	public static string ToLowerFirst(this string str)
	{
		if (string.IsNullOrEmpty(str))
		{
			return str;
		}

		return char.ToLower(str[0]) + str[1..];
	}
}
