namespace Filtering.Identification;

public abstract record IdentifyingInformation
{
    public static implicit operator string(IdentifyingInformation information) => information.ToString();
};
public interface IIdentifiable
{
    IdentifyingInformation Information();
}