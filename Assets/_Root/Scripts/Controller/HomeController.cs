using UnityEngine;
using UnityEngine.UI;

public class HomeController : Singleton<HomeController>
{
    public Map MapCurrent;

    protected override void Awake()
    {
        base.Awake();
    }

    void Start()
    {
        LoadMap();
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
        SoundController.Instance.PlayBackground(MapCurrent.Bgm);
    }
    public Map GetMap(int index)
    {
        return ConfigController.MapConfig.ListMaps[index % ConfigController.MapConfig.ListMaps.Count];
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
