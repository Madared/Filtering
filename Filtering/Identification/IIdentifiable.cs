namespace Filtering.Identification;

/// <summary>
/// Represents an object which can be identified
/// </summary>
public interface IIdentifiable
{
    /// <summary>
    /// Provides the object identification
    /// </summary>
    /// <returns></returns>
    IdentifyingInformation Information();
}