﻿namespace Domain.Primitives;
public class Entity : IEquatable<Entity>, IAuditableEntity
{
    protected Entity() { }

    protected Entity(int id) => Id = id;

    public int Id { get; private init; }


    //AuditableEntity
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    public DateTime? ModifiedOn { get; set; }

    public override int GetHashCode() => Id.GetHashCode() * 41;

    public static bool operator ==(Entity? first, Entity? second) => first is not null && second is not null && first.Equals(second);

    public static bool operator !=(Entity? first, Entity? second) => !(first == second);

    public bool Equals(Entity? other)
    {
        if (other is null)
        {
            return false;
        }

        if (other.GetType() != GetType())
        {
            return false;
        }

        return other.Id == Id;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null)
        {
            return false;
        }

        if (obj.GetType() != GetType())
        {
            return false;
        }

        if (obj is not Entity entity)
        {
            return false;
        }

        return entity.Id == Id;
    }
}
