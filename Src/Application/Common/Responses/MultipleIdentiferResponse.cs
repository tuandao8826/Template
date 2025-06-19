namespace Application.Common.Responses;

public record class MultipleIdentiferResponse<TId>(IEnumerable<TId> Ids) where TId : class;

public record class MultipleIdentiferResponse(IEnumerable<Guid> Ids);