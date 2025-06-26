namespace Application.Common.Definitions.AclPermissions;

public record class AclPermission(string Resource, string Action, string[] AllowedUserTypes, params string[] ImpliedPermissions)
{
	public string Code => Resource + Action;
}

public static class AclPermissions
{
	private static readonly AclPermission[] Users =
	{
		new
		(
			AclResource.User,
			AclAction.View,
			AclUserType.Of(AclUserType.Admin)
		),
		new
		(
			AclResource.User,
			AclAction.Create,
			AclUserType.Of(AclUserType.Admin),
			AclResource.User + AclAction.View
		),
		new
		(
			AclResource.User,
			AclAction.Update,
			AclUserType.Of(AclUserType.Admin),
			AclResource.User + AclAction.View
		),
		new
		(
			AclResource.User,
			AclAction.Delete,
			AclUserType.Of(AclUserType.Admin),
			AclResource.User + AclAction.View
		),
		new
		(
			AclResource.User,
			AclAction.Search,
			AclUserType.Of(AclUserType.Admin),
			AclResource.User + AclAction.View
		),
	};

	private static readonly AclPermission[] Roles =
	{
		new
		(
			AclResource.Role,
			AclAction.View,
			AclUserType.Of(AclUserType.Admin)
		),
		new
		(
			AclResource.Role,
			AclAction.Create,
			AclUserType.Of(AclUserType.Admin),
			AclResource.Role + AclAction.View
		),
		new
		(
			AclResource.Role,
			AclAction.Update,
			AclUserType.Of(AclUserType.Admin),
			AclResource.Role + AclAction.View
		),
		new
		(
			AclResource.Role,
			AclAction.Delete,
			AclUserType.Of(AclUserType.Admin),
			AclResource.Role + AclAction.View
		),
		new
		(
			AclResource.Role,
			AclAction.Search,
			AclUserType.Of(AclUserType.Admin),
			AclResource.Role + AclAction.View
		),
	};
}