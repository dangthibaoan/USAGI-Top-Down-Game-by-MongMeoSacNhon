using System;
using UnityEngine;

public class ConfigController : MonoBehaviour
{
    [SerializeField] private SoundConfig soundConfig;
    [SerializeField] private MiniGameConfig miniGameConfig;
    [SerializeField] private TileConfig tileConfig;
    [SerializeField] private CharacterConfig characterConfig;
    [SerializeField] private StoryLineConfig storyLineConfig;
    [SerializeField] private Config_PlayerData config_PlayerData;
    public static SoundConfig SoundConfig;
    public static MiniGameConfig MiniGameConfig;
    public static TileConfig TileConfig;
    public static CharacterConfig CharacterConfig;
    public static StoryLineConfig StoryLineConfig;
    public static Config_PlayerData Config_PlayerData;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        SoundConfig = soundConfig;
        MiniGameConfig = miniGameConfig;
        TileConfig = tileConfig;
        CharacterConfig = characterConfig;
        StoryLineConfig = storyLineConfig;
        Config_PlayerData = config_PlayerData;
    }
}