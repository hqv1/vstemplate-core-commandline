namespace Domain
{
    /// <summary>
    /// Map using Automapper (http://automapper.org/)
    /// Don't need this interface if we're pulling in Hqv.Shared nuget library
    /// </summary>
    public interface IMapper
    {
        /// <summary>
        /// Map the source to a destination. Creates a new destination object.
        /// </summary>
        TDestination Map<TDestination>(object source);

        /// <summary>
        /// Map the source to the destination. Uses the destination object passed in.
        /// </summary>
        void Map<TSource, TDestination>(TSource source, TDestination destination);

        /// <summary>
        /// Assert that the source to destination mapping is valid.
        /// </summary>
        void AssertConfigurationIsValid();
    }
}