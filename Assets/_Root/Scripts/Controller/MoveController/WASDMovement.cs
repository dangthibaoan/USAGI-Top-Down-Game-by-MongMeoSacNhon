using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class WASDMovement : BaseMovement
{
    private Vector3 offset = Vector3.zero;

    [Header("Move Setting")]
    public float moveSpeed = 5f;
    public bool CameraFollowPlayer = true;

    [Header("Active Key")]
    [SerializeField] private bool W = true;
    [SerializeField] private bool A = true;
    [SerializeField] private bool S = true;
    [SerializeField] private bool D = true;

    public override void ResetPositionOrigin()
    {
        player.transform.position = ConfigController.PlayerDataConfig.PlayerPositionCurrent;
        if (CameraFollowPlayer)
        {
            Camera.main.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, Camera.main.transform.position.z);
        }
        Move(offset);
    }
    public override void Movement()
    {
        if (!ConfigController.PlayerDataConfig.isActiveMovement)
        {
            ConfigController.PlayerDataConfig.isMoving = false;
            return;
        }

        if (!((W && Input.GetKey(KeyCode.W)) || (A && Input.GetKey(KeyCode.A)) || (S && Input.GetKey(KeyCode.S)) || (D && Input.GetKey(KeyCode.D))))
        {
            ConfigController.PlayerDataConfig.isMoving = false;
            return;
        }

        ConfigController.PlayerDataConfig.isMoving = true;

        if (W && Input.GetKey(KeyCode.W))
        {
            ConfigController.PlayerDataConfig.status = 3;
            Move(Vector3.up * Time.deltaTime * moveSpeed);
        }
        if (A && Input.GetKey(KeyCode.A))
        {
            ConfigController.PlayerDataConfig.status = 1;
            Move(Vector3.left * Time.deltaTime * moveSpeed);
        }
        if (S && Input.GetKey(KeyCode.S))
        {
            ConfigController.PlayerDataConfig.status = 0;
            Move(Vector3.down * Time.deltaTime * moveSpeed);
        }
        if (D && Input.GetKey(KeyCode.D))
        {
            ConfigController.PlayerDataConfig.status = 2;
            Move(Vector3.right * Time.deltaTime * moveSpeed);
        }
    }
    public void SetMovement(bool w, bool a, bool s, bool d)
    {
        W = w;
        A = a;
        S = s;
        D = d;
    }
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
