using UnityEngine;
using UnityEngine.UI;
public class GameController : Singleton<GameController>
{
    public MiniGame MiniGameCurrent;

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
        if (MiniGameCurrent != null)
        {
            Destroy(MiniGameCurrent.gameObject);
        }

        var miniGame = GetMiniGame(Data.IndexMiniGame);
        MiniGameCurrent = Instantiate(miniGame, transform);
        //Data.SetInt(Constant.MAX_SCORE, ConfigController.Level.MaxScoreLevel(Data.IndexMap));
    }
    public MiniGame GetMiniGame(int index)
    {
        return ConfigController.MiniGameConfig.ListMiniGames[index % ConfigController.MiniGameConfig.ListMiniGames.Count];
    }

    public void NextLevel()
    {
        Data.IndexMiniGame++;
        LoadLevel();
    }

    public void ReplayLevel()
    {
        LoadLevel();
    }

    public void FinishGame() { }

}
