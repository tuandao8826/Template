using System.Linq.Expressions;

namespace Application.Common.Helpers;

public static class ReflectionHelper
{
	public static string GetPropertyName<T>(Expression<Func<T, object>> propExpression)
	{
		if (propExpression.Body is MemberExpression memberExpression)
		{
			return memberExpression.Member.Name;
		}

		throw new ArgumentException("Expression is not a member expression.");
	}	
}
