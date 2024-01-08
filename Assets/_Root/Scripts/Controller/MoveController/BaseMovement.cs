using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class BaseMovement : MonoBehaviour
{
    [Header("Player Setting")]
    public GameObject player;

    public void Awake()
    {
        if (player.TryGetComponent<BoxCollider2D>(out BoxCollider2D boxCollider2D))
        {
            boxCollider2D.enabled = true;
        }
    }
    public virtual void Start()
    {
        ResetPositionOrigin();
    }
    private void Update()
    {
        Movement();
    }
    public virtual void Movement() { }
    public virtual void ResetPositionOrigin() { }
}
