namespace Pokemon_WebApi.Models.Common;

public abstract class EntityDto
{
    public Guid Id { get; set; }

    protected EntityDto(Guid id) => Id = id;

    protected EntityDto()
    {

    }
}
