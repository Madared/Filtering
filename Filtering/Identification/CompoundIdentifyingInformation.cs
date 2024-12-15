namespace Filtering.Identification;

/// <summary>
/// An aggregation of <see cref="IdentifyingInformation"/> objects into one
/// </summary>
public sealed record CompoundIdentifyingInformation : IdentifyingInformation
{
    private readonly IEnumerable<IdentifyingInformation> _informations;

    /// <summary>
    /// Params constructor
    /// </summary>
    /// <param name="informations"></param>
    public CompoundIdentifyingInformation(params IdentifyingInformation[] informations)
    {
        _informations = informations;
    }

    /// <summary>
    /// IEnumerable constructor
    /// </summary>
    /// <param name="informations"></param>
    public CompoundIdentifyingInformation(IEnumerable<IdentifyingInformation> informations)
    {
        _informations = informations;
    }

    /// <summary>
    /// Returns a string representable collection of all information objects contained
    /// </summary>
    public StringRepresentableCollection<IdentifyingInformation> InformationCollection =>
        new StringRepresentableCollection<IdentifyingInformation>(_informations);
};