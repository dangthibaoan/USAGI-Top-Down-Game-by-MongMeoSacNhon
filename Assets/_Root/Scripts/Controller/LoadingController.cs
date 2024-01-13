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
        ConfigController.PlayerDataConfig.status = 2;
        ConfigController.PlayerDataConfig.PlayerPositionCurrent = ConfigController.ItemConfig.ItemDatas[0].Item.transform.position;

        // usagi = transform.GetChild(0).gameObject;
        // usagi.transform.position += Vector3.right * 5;
        ConfigController.PlayerDataConfig.isMoving = true;
        usagi.transform.DOMoveX(5.0f, 5.0f).OnComplete(() =>
        {
            ConfigController.PlayerDataConfig.isMoving = false;
            Data.GetBool(Constant.MUSIC_STATE, true);
            SceneController.Instance.LoadHomeScene();
        });
    }
}
