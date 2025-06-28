namespace Application.Common.Definitions.AclPermissions;

public record class AclPermission(string Resource, string Action, List<AclUserType> AllowedUserTypes, params string[] ImpliedPermissions)
{
	public string Code => Resource + Action;

	public string Name => $"{Resource} {Action}";
}

public static class AclPermissions
{
	public static AclPermission[] GetAll()
		=> Users
			.Concat(Roles)
			.ToArray();

	private static List<AclUserType> Allowed(params AclUserType[] userTypes)
	{
		return [.. userTypes];
	}

	private static readonly AclPermission[] Users =
	{
		new
		(
			AclResource.User,
			AclAction.View,
			Allowed(AclUserType.Admin)
		),
		new
		(
			AclResource.User,
			AclAction.Create,
			Allowed(AclUserType.Admin),
			AclResource.User + AclAction.View
		),
		new
		(
			AclResource.User,
			AclAction.Update,
			Allowed(AclUserType.Admin),
			AclResource.User + AclAction.View
		),
		new
		(
			AclResource.User,
			AclAction.Delete,
			Allowed(AclUserType.Admin),
			AclResource.User + AclAction.View
		),
		new
		(
			AclResource.User,
			AclAction.Search,
			Allowed(AclUserType.Admin),
			AclResource.User + AclAction.View
		),
	};

	private static readonly AclPermission[] Roles =
	{
		new
		(
			AclResource.Role,
			AclAction.View,
			Allowed(AclUserType.Admin)
		),
		new
		(
			AclResource.Role,
			AclAction.Create,
			Allowed(AclUserType.Admin),
			AclResource.Role + AclAction.View
		),
		new
		(
			AclResource.Role,
			AclAction.Update,
			Allowed(AclUserType.Admin),
			AclResource.Role + AclAction.View
		),
		new
		(
			AclResource.Role,
			AclAction.Delete,
			Allowed(AclUserType.Admin),
			AclResource.Role + AclAction.View
		),
		new
		(
			AclResource.Role,
			AclAction.Search,
			Allowed(AclUserType.Admin),
			AclResource.Role + AclAction.View
		),
	};
}