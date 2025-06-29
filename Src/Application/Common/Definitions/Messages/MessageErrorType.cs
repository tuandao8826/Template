namespace Application.Common.Definitions.Messages;

/// <summary>
/// Defines various types of error messages that can be used for application responses.
/// </summary>
public enum MessageErrorType
{
	/// <summary>
	/// Used when there is a conflict with the current data (e.g., duplicate entries).
	/// </summary>
	Conflict,

	/// <summary>
	/// Used when the requested resource cannot be found.
	/// </summary>
	NotFound,

	/// <summary>
	/// Used when the requested action is not allowed because the resource already exists.
	/// </summary>
	AlreadyExists,

	/// <summary>
	/// Used when a user tries to access a resource that requires data.
	/// </summary>
	Required,

	/// <summary>
	/// Used when the user submits duplicate data that is not allowed.
	/// </summary>
	Duplicate,

	/// <summary>
	/// Used when the provided data exceeds the maximum allowed length.
	/// </summary>
	TooLong,

	/// <summary>
	/// Used when the provided data is below the minimum required length.
	/// </summary>
	TooShort,

	/// <summary>
	/// Used when the provided data is invalid or improperly formatted.
	/// </summary>
	Invalid,

	Blocked,
}
