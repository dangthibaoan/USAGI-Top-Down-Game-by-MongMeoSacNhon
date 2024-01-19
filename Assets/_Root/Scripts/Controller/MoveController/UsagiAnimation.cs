using UnityEngine;

public class UsagiAnimation : MonoBehaviour
{
    [Header("Animation Setting")]
    [SerializeField] private Animator animator;

    [Header("SFX Setting")]
    [SerializeField] private SoundType SfxWalk = SoundType.Walk;
    [SerializeField] private float CountDown = 0.2f;

    private void Update()
    {
        if (animator == null) return;

        if (ConfigController.Config_PlayerData.isMoving)
        {
            //Play anim walk
            PlayAnimWalk(ConfigController.Config_PlayerData.status);
        }
        else
        {
            CountDown = 0.3f;
            //Play anim idle
            switch (ConfigController.Config_PlayerData.status)
            {
                case 0:
                    animator.Play("Down", 0, 0);
                    break;
                case 1:
                    animator.Play("Left", 0, 0);
                    break;
                case 2:
                    animator.Play("Right", 0, 0);
                    break;
                case 3:
                    animator.Play("Up", 0, 0);
                    break;
                default: break;
            }
        }
    }
    void PlayAnimWalk(int status)
    {
        animator.SetInteger("Status", status);
        CountDown += Time.deltaTime;
        if (CountDown < 0.2) return;
        CountDown = 0;
        SoundController.Instance.PlayOnce(SfxWalk);
    }
}
