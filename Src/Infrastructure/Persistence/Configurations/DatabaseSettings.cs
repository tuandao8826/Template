using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Persistence.Configurations;

public class DatabaseSettings
{
	public SqlSettings SqlSettings { get; set; } = default!;
}

public class ConnectionStrings
{
	public string DefaultConnection { get; set; } = default!;
}

public class SqlSettings
{
	public string Provider { get; set; } = default!;

	public ConnectionStrings ConnectionStrings { get; set; } = default!;
}