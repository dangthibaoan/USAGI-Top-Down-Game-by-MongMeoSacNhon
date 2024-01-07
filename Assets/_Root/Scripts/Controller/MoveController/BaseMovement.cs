using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class BaseMovement : MonoBehaviour
{
    [Header("Player Setting")]
    public GameObject player;
    public float moveSpeed = 5f;
    private Vector3 offset = Vector3.zero;
    public bool CameraFollowPlayer = true;

    public void Awake()
    {
        if (player.TryGetComponent<BoxCollider2D>(out BoxCollider2D boxCollider2D))
        {
            boxCollider2D.enabled = true;
        }
    }
    public void Start()
    {
        player.transform.position = ConfigController.PlayerDataConfig.PlayerPositionCurrent;
        if (CameraFollowPlayer)
        {
            Camera.main.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, Camera.main.transform.position.z);
        }
        Move(offset);
    }
    private void Update()
    {
        if (!ConfigController.PlayerDataConfig.isActiveMovement)
        {
            ConfigController.PlayerDataConfig.isMoving = false;
            return;
        }

        Movement();
    }
    public virtual void Movement() { }
    public void Move(Vector3 offset)
    {
        player.transform.position += offset;
        ConfigController.PlayerDataConfig.PlayerPositionCurrent = player.transform.position;

        // if (Vector2.Distance(player.transform.position, new Vector2(Camera.main.transform.position.x, Camera.main.transform.position.y)) > 3f)
        // {
        //     Camera.main.transform.position += offset * 2;
        // }
        if (CameraFollowPlayer)
        {
            Camera.main.transform.DOMove(new Vector3(player.transform.position.x, player.transform.position.y, Camera.main.transform.position.z), 1);
        }
    }
}
