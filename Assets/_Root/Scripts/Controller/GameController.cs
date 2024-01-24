using UnityEngine;
using UnityEngine.UI;
public class GameController : Singleton<GameController>
{
    public MiniGame MiniGameCurrent;
    [SerializeField] private MiniGameConfig MiniGameConfig;

    private void Start()
    {
        DialogController.Instance.ResetDialog();
        LoadLevel();
        PopupController.Instance.Show<GamePopup>();
    }

    public void LoadLevel()
    {
        if (MiniGameCurrent != null)
        {
            Destroy(MiniGameCurrent.gameObject);
        }

        var miniGame = GetMiniGame(Data.IndexMiniGame);
        MiniGameCurrent = Instantiate(miniGame, transform);
        SoundController.Instance.PlayBackground(MiniGameCurrent.Bgm);
    }
    public MiniGame GetMiniGame(int index)
    {
        return MiniGameConfig.ListMiniGames[index % MiniGameConfig.ListMiniGames.Count];
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
