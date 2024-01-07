using UnityEngine;

public class UsagiAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private void Awake()
    {
        animator = transform.parent.GetComponentInChildren<Animator>();
    }
    private void Update()
    {
        if (animator == null) return;

        if (ConfigController.PlayerDataConfig.isMoving)
        {
            //Play anim run
            animator.SetInteger("Status", ConfigController.PlayerDataConfig.status);
        }
        else
        {
            //Play anim idle
            switch (ConfigController.PlayerDataConfig.status)
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
}
