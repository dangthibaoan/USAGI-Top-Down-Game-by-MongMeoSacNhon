using System;
using UnityEngine;

public class ConfigController : MonoBehaviour
{
    [SerializeField] private SoundConfig sound;
    [SerializeField] private MapConfig map;
    [SerializeField] private TileConfig tile;
    [SerializeField] private ItemConfig item;
    [SerializeField] private TextConfig storyLine;
    [SerializeField] private Config_PlayerData config_PlayerData;
    public static SoundConfig SoundConfig;
    public static MapConfig MapConfig;
    public static TileConfig TileConfig;
    public static ItemConfig ItemConfig;
    public static TextConfig StoryLineConfig;
    public static Config_PlayerData PlayerDataConfig;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        SoundConfig = sound;
        MapConfig = map;
        TileConfig = tile;
        ItemConfig = item;
        StoryLineConfig = storyLine;
        PlayerDataConfig = config_PlayerData;
    }
}