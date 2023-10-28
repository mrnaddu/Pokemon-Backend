namespace Pokemon_WebApi.Models.Common;

public abstract class BaseEntity<T>
{
    public virtual T Id { get; set; } = default!;
}
