namespace Application.Common.Definitions.Messages;

/// <summary>
/// Defines various types of actions that can be performed within the application.
/// </summary>
public enum MessageActionType
{
	/// <summary>
	/// Used when a view action is performed (e.g., viewing a resource).
	/// </summary>
	View,

	/// <summary>
	/// Used when viewing the details of a resource.
	/// </summary>
	Detail,

	/// <summary>
	/// Used when a resource has been successfully created.
	/// </summary>
	Created,

	/// <summary>
	/// Used when a resource has been successfully updated.
	/// </summary>
	Updated,

	/// <summary>
	/// Used when a resource has been successfully deleted.
	/// </summary>
	Deleted,

	/// <summary>
	/// Used when importing a resource into the system.
	/// </summary>
	Import,

	/// <summary>
	/// Used when downloading a resource.
	/// </summary>
	Download,

	/// <summary>
	/// Used when performing a search action within the application.
	/// </summary>
	Search,

	Login,
}