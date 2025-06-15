using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Definitions;

public static class Message<T>
{
	private const char Delimiter = '.';
	private const string Prefix = "Message";
	private const string Success = "Success";
	private const string Failed = "Failed";

	// ------------------- Message action ------------------- 
	public static string Create(bool status = true)
		=> Action(MessageActionType.Created, status);

	public static string Update(bool status = true)
		=> Action(MessageActionType.Updated, status);

	public static string Delete(bool status = true)
		=> Action(MessageActionType.Deleted, status);

	public static string View(bool status = true)
		=> Action(MessageActionType.View, status);

	public static string Detail(bool status = true)
		=> Action(MessageActionType.Detail, status);

	// ------------------- Message error ------------------- 
	public static string Required(Expression<Func<T, object>> propExpression)
		=> Action(MessageErrorType.Required, propExpression);

	public static string Required(string propName)
		=> Action(MessageErrorType.Required, propName);

	// ------------------- Handle message ------------------- 
	public static string Action(MessageActionType type, bool status)
		=> BuildMessage(type.ToString(), status);

	public static string Action(MessageErrorType type, string propName)
		=> BuildMessage(type.ToString(), propName);

	public static string Action(MessageErrorType type, Expression<Func<T, object>> propExpression)
		=> BuildMessage(type.ToString(), GetPropertyName(propExpression));

	private static string BuildMessage(string type, bool status)
		=> BuildMessage(type, status ? Success : Failed);

	/// <summary>
	/// Ex: Message.User.Required.Name
	/// Ex: Message.User.Invalid.Name
	/// Ex: Message.User.Created.Success
	/// Ex: Message.User.Created.Failed
	/// </summary>
	private static string BuildMessage(string type, string propName)
		=> new StringBuilder()
			.Append(Prefix)
			.Append(Delimiter)
			.Append(typeof(T).Name) // Appends the class name (e.g., "User", "Role")
			.Append(Delimiter)
			.Append(type) // Appends the action (e.g., "Required", "Invalid")
			.Append(Delimiter)
			.Append(propName) // Appends the property name (e.g., "Name", "Age", "Success", "Failed")
			.ToString();

	private static string GetPropertyName(Expression<Func<T, object>> propExpression)
	{
		if (propExpression.Body is MemberExpression memberExpression)
		{
			return memberExpression.Member.Name;
		}

		throw new ArgumentException("Expression is not a member expression.");
	}
}

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
}

/// <summary>
/// Defines various types of error messages that can be used for application responses.
/// </summary>
public enum MessageErrorType
{
	/// <summary>
	/// Used when the user is not authorized to access the requested resource.
	/// </summary>
	Unauthorized,

	/// <summary>
	/// Used when the user is authenticated but not allowed to access the resource.
	/// </summary>
	Forbidden,

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
}