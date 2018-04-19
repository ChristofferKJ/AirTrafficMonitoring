namespace AirTrafficMonitoring
{
    public interface IFilterAirspace
    {
        void FilterTrack(ITrack track);

        bool IsTrackInAirspace { get; set; }
    }
}