namespace APLTools.Models
{
    public enum WindowType
    {
        SharedArtwork,
        SavedArtwork,
        UploadArtwork,
        TransferArtwrok,
        CheckDigitalBackground
    }
    public enum OrderByOptions
    {
        LastModified,
        Created,
        NotSet
    }

    public enum SortOptions
    {
        Ascending,
        Descending,
        NotSet
    }

    public enum ConnectionType
    {
        Dev,
        Live
    }

    public enum DataImportConnectionType
    {
        Loacal,
        Test,
        Live
    }

}
