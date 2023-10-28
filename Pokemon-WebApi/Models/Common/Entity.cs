namespace Pokemon_WebApi.Models.Common;

public abstract class Entity
{
    public Guid Id { get; set; }
    public Entity(Guid id) => Id = id;
    protected Entity() 
    {

    }
}
