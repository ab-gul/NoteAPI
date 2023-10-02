using NoteAPI.Domain;
using NoteAPI.DTOs.Notes;

namespace NoteAPI.Common.Extensions
{
    public static class DomainExtensions
    {
        public static List<T1> FromListToList<T2, T1>(this List<dynamic> input)
        {
            try
            {
            ArgumentNullException.ThrowIfNull(input, nameof(input));

            return input.Select(i => (T1)i).ToList();

            }
            catch (Exception)
            {
                    
                throw;
            }
        }
    }
}
