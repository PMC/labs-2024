
internal class AssetManager
{
    private readonly List<Asset> _assets;
    public AssetManager()
    {
        _assets = new List<Asset>();
    }

    internal void AddAsset(Asset asset)
    {
        _assets.Add(asset);
    }
    internal List<Asset> GetAssets()
    {
        return _assets;
    }
}