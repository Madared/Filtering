namespace Filtering.Identification;

/// <summary>
/// An identification record
/// </summary>
public abstract record IdentifyingInformation
{
    /// <summary>
    /// Automatic conversion of the identifying information into a string using its <see cref="ToString"/> method.
    /// </summary>
    /// <param name="information"></param>
    /// <returns></returns>
    public static implicit operator string(IdentifyingInformation information) => information.ToString();
};