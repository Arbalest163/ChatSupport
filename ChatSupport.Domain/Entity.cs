using ChatSupport.Domain.Interfaces;
namespace ChatSupport.Domain;
public abstract class Entity : IEntity
{
    public int Id { get; set; }
}
