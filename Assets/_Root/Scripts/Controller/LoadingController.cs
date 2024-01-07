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
        ConfigController.PlayerDataConfig.PlayerPositionCurrent = ConfigController.ItemConfig.ItemDatas[0].Item.transform.position;

        // usagi = transform.GetChild(0).gameObject;
        // usagi.transform.position += Vector3.right * 5;
        Animator animator = GetComponentInChildren<Animator>();
        animator.SetInteger("Status", 2);
        usagi.transform.DOMoveX(5.0f, 5.0f).OnComplete(() =>
        {
            Data.GetBool(Constant.MUSIC_STATE, true);
            SceneController.Instance.LoadHomeScene();
        });
    }
}
