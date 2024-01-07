using UnityEngine;
using UnityEngine.UI;
public class GameController : Singleton<GameController>
{
    public Map MapCurrent;

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        DialogController.Instance.ResetDialog();
        LoadLevel();
        PopupController.Instance.Show<GamePopup>();
        SoundController.Instance.PlayBackground(SoundType.BackgroundMusicOnGame);
    }

    public void LoadLevel()
    {
        if (MapCurrent != null)
        {
            Destroy(MapCurrent.gameObject);
        }

        var map = GetMap(Data.IndexMap);
        MapCurrent = Instantiate(map, transform);
        //Data.SetInt(Constant.MAX_SCORE, ConfigController.Level.MaxScoreLevel(Data.IndexMap));
    }
    public Map GetMap(int index)
    {
        return ConfigController.MapConfig.Maps[index % ConfigController.MapConfig.Maps.Count];
    }

    public void NextLevel()
    {
        Data.IndexMap++;
        LoadLevel();
    }

    public void ReplayLevel()
    {
        LoadLevel();
    }

    public void FinishGame()
    {
        //PopupController.Instance.Show<WinPopup>();
    }

}
