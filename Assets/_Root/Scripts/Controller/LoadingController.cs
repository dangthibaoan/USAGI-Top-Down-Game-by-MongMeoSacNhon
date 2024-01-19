using DG.Tweening;
using UnityEngine;

public class LoadingController : Singleton<LoadingController>
{
    [SerializeField] private GameObject usagi;
    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        ConfigController.Config_PlayerData.status = 2;
        ConfigController.Config_PlayerData.PlayerPositionCurrent = ConfigController.CharacterConfig.CharacterDatas[0].Character.transform.position;

        // usagi = transform.GetChild(0).gameObject;
        // usagi.transform.position += Vector3.right * 5;
        ConfigController.Config_PlayerData.isMoving = true;
        usagi.transform.DOMoveX(5.0f, 5.0f).OnComplete(() =>
        {
            ConfigController.Config_PlayerData.isMoving = false;
            Data.GetBool(Constant.MUSIC_STATE, true);
            SceneController.Instance.LoadHomeScene();
        });
    }
}
