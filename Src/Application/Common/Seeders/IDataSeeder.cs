namespace Application.Common.Seeders;

public interface IDataSeeder
{
	Task SeedAsync(CancellationToken cancellationToken = default);
}
