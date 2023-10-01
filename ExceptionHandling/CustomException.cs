using System.Net;
using NoteAPI.Domain;

namespace NoteAPI.ExceptionHandling;


public class NotFoundException : Exception
{
    public NotFoundException(string message) : base(message)
    {

    }

    public static void ThrowIfNull(object? entity, Guid id, string entityName)
    {
        if (entity is null) throw new NotFoundException(message: $"{entityName} with given Id \'{id}\' does not exist!");
    }


}

public class DuplicateCollectionException : Exception
{
    public DuplicateCollectionException(string message) : base(message)
    {

    }

    public static void ThrowIfDublicate(Collection? collection, string title)
    {
        if (collection is not null) throw new DuplicateCollectionException(message: $"Collection with given Title \'{title}\' already exists!");
    }

}




