using System.Text.Json.Serialization;
using ExtraIsland.Shared;

namespace ExtraIsland.Components;

// ReSharper disable once ClassNeverInstantiated.Global
public class RhesisConfig
{
    public RhesisDataSource DataSource { get; set; } = RhesisDataSource.All;

    // Source enablement flags for multi-source selection
    public bool EnableHitokoto { get; set; } = true;
    public bool EnableJinrishici { get; set; } = true;
    public bool EnableSaint { get; set; } = true;
    public bool EnableOnlineTxt { get; set; } = true;

    // Weights for each source
    public int HitokotoWeight { get; set; } = 25;
    public int JinrishiciWeight { get; set; } = 25;
    public int SaintWeight { get; set; } = 25;

    // Prefetching settings
    public int MaxPrefetchedQuotes { get; set; } = 100;
    public int PrefetchIntervalSeconds { get; set; } = 30;

    public string IgnoreListString { get; set; } = string.Empty;

    public string HitokotoProp { get; set; } = string.Empty;

    public DateTime LastUpdate { get; set; } = DateTime.Today;

    public int LengthLimitation { get; set; }

    [JsonIgnore]
    public string HitokotoLengthArgs
    {
        get
        {
            return LengthLimitation switch
            {
                0 => string.Empty,
                _ => $"max_length={LengthLimitation}&"
            };
        }
    }

    public TimeSpan UpdateTimeGap { get; set; } = TimeSpan.FromSeconds(30);

    [JsonIgnore]
    public double UpdateTimeGapSeconds
    {
        get => UpdateTimeGap.TotalSeconds;
        set => UpdateTimeGap = TimeSpan.FromSeconds(value);
    }

    public string SainticProp { get; set; } = string.Empty;

    public bool IsAnimationEnabled { get; set; } = true;

    public bool IsSwapAnimationEnabled { get; set; }

    // 在线TXT文件相关属性
    public string OnlineTxtUrl { get; set; } = string.Empty;

    [JsonIgnore]
    private int _onlineTxtWeight = 20; // 默认20%权重

    public int OnlineTxtWeight
    {
        get => _onlineTxtWeight;
        set => _onlineTxtWeight = Math.Max(0, Math.Min(100, value)); // 确保权重在0-100范围内
    }
}
