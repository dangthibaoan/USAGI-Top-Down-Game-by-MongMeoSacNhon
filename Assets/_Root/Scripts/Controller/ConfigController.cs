using System;
using UnityEngine;

public class ConfigController : MonoBehaviour
{
    [SerializeField] private SoundConfig soundConfig;
    [SerializeField] private TileConfig tileConfig;
    [SerializeField] private CharacterConfig characterConfig;
    [SerializeField] private Config_PlayerData config_PlayerData;
    public static SoundConfig SoundConfig;
    public static TileConfig TileConfig;
    public static CharacterConfig CharacterConfig;
    public static Config_PlayerData Config_PlayerData;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        SoundConfig = soundConfig;
        TileConfig = tileConfig;
        CharacterConfig = characterConfig;
        Config_PlayerData = config_PlayerData;
    }
}