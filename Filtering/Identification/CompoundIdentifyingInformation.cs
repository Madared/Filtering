namespace Filtering.Identification;

public sealed record CompoundIdentifyingInformation : IdentifyingInformation
{
    private readonly IEnumerable<IdentifyingInformation> _filterInformations;

    public CompoundIdentifyingInformation(params IdentifyingInformation[] filterInformations)
    {
        _filterInformations = filterInformations;
    }

    public CompoundIdentifyingInformation(IEnumerable<IdentifyingInformation> filterInformations)
    {
        _filterInformations = filterInformations;
    }

    public StringRepresentableCollection<IdentifyingInformation> FilterInformations =>
        new StringRepresentableCollection<IdentifyingInformation>(_filterInformations);
};