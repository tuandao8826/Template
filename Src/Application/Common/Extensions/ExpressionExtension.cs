using System.Linq.Expressions;

namespace Application.Common.Extensions;

public static class ExpressionExtension
{
	public static string GetPropertyName<T>(this Expression<Func<T, object?>> propExpression)
	{
		if (propExpression.Body is MemberExpression memberExpression)
		{
			return memberExpression.Member.Name;
		}

		if (propExpression.Body is UnaryExpression unary && unary.Operand is MemberExpression memberOperand)
		{
			return memberOperand.Member.Name;
		}

		throw new ArgumentException("Expression is not a member expression.");
	}
}
