namespace Application.Common.Definitions.AclPermissions;

public static class AclUserType
{
	public const string Admin = nameof(Admin);
	public const string Customer = nameof(Customer);

	public static string[] Of(params string[] types)
	{
		return types;
	}
}