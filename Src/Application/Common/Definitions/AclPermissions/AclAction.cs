namespace Application.Common.Definitions.AclPermissions;

/// <summary>
/// Represents actions that are allowed to be performed
/// </summary>
public static class AclAction
{
	public const string View = nameof(View);
	public const string Login = nameof(Login);
	public const string Create = nameof(Create);
	public const string Update = nameof(Update);
	public const string Delete = nameof(Delete);
	public const string Search = nameof(Search);
	public const string Detail = nameof(Detail);
	public const string Import = nameof(Import);
}