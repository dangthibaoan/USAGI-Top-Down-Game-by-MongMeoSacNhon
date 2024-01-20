using UnityEngine;
using UnityEngine.UI;

public class HomeController : Singleton<HomeController>
{
    public MiniGame MapCurrent;

    protected override void Awake()
    {
        base.Awake();
    }

    void Start()
    {
        SoundController.Instance.PlayBackground(SoundType.BackgroundMusic);
        PopupController.Instance.Show<UIPopup>();
        PopupController.Instance.GetPopup<UIPopup>().BtnWASDSetActive(true, true, true, true);
        ConfigController.Config_PlayerData.isActiveMovement = true;
    }

    public void LoadMap()
    {
        if (MapCurrent != null)
        {
            Destroy(MapCurrent.gameObject);
        }

        var map = GetMap(Data.IndexMap);
        MapCurrent = Instantiate(map, transform);
        //Data.SetInt(Constant.MAX_SCORE, ConfigController.Level.MaxScoreLevel(Data.IndexMap));
    }
    public MiniGame GetMap(int index)
    {
        return ConfigController.MiniGameConfig.ListMiniGames[index % ConfigController.MiniGameConfig.ListMiniGames.Count];
    }

    public void NextLevel()
    {
        Data.IndexMap++;
        LoadMap();
    }

    public void ReplayLevel()
    {
        LoadMap();
    }
}
