using GraphQl.Data;

namespace GraphQl.Tracks
{
    public record AddTrackInput(string Name);
    public record RenameTrackInput([ID(nameof(Track))] int Id, string Name);
}
