﻿namespace Application.Common.Extensions;

public static class PasswordExtension
{
	public static string Hash(string password)
		=> BCrypt.Net.BCrypt.HashPassword(password);

	public static bool Verify(string password, string hashedPassword)
		=> BCrypt.Net.BCrypt.Verify(password, hashedPassword);
}
