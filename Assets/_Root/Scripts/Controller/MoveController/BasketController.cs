using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class BasketController : BaseMovement
{
    [Header("Move Setting")]
    [SerializeField] private float speed = 30f; // tốc độ di chuyển trên bàn phím
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float mapWidth = 5f;
    // giới hạn chiều ngang di chuyển của player tránh nó chạy ra khỏi màn hình
    [SerializeField] private float MouseSpeed = 5f; // tốc độ di chuyển bằng chuột
    [SerializeField] private float slowness = 10f; // slow motion khi player thua

    [Header("HP settings")]
    public int MaxHP = 3;
    [SerializeField] private TMP_Text TxtHP;

    [Header("Events")]
    [SerializeField] private UnityEvent OnSuccessGetPoint;

    public override void Start()
    {
        base.Start();
        TxtHP.text = "×" + MaxHP;
        ConfigController.PlayerDataConfig.isActiveMovement = true;
        rb.bodyType = RigidbodyType2D.Dynamic;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (!ConfigController.PlayerDataConfig.isActiveMovement) return;

        // use 'A' or 'D' or right/left arrow to move
        float x = Input.GetAxis("Horizontal") * Time.fixedDeltaTime * speed;

        if (x == 0)
        {
            x = Input.GetAxis("Mouse X") * Time.fixedDeltaTime * speed * MouseSpeed; // use mouse to control
        }

        Vector2 newPosition = rb.position + Vector2.right * x;

        newPosition.x = Mathf.Clamp(newPosition.x, -mapWidth, mapWidth);

        rb.MovePosition(newPosition);

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        other.collider.enabled = false;

        if (other.gameObject.TryGetComponent<Item>(out Item item))
        {
            ScoreController.currentScore += item.itemScore;

            if (item.itemScore < 0) MaxHP--;

            if (ScoreController.currentScore < 0) ScoreController.currentScore = 0;

            OnSuccessGetPoint.Invoke();

            TxtHP.text = "×" + MaxHP;
            if (MaxHP <= 0)
            {
                this.GetComponent<BoxCollider2D>().enabled = false;
                EndGame();
            }
        }

        Destroy(other.gameObject);
    }

    public void EndGame()
    {
        MapLuna.IsSpawnPrefab = false;
        if (ScoreController.currentScore > Data.MaxScore) Data.MaxScore = ScoreController.currentScore;

        StartCoroutine(RestartLevel());
    }

    IEnumerator RestartLevel()
    {

        Time.timeScale = 1f / slowness; // khien time chay se giam tan toi 0.1 frame/s
        Time.fixedDeltaTime = Time.fixedDeltaTime / slowness; // de xu ly hinh anh duoc muot hon

        yield return new WaitForSeconds(2f / slowness);
        // luu y la khi xai timeScale se anh huong den waitForSeconds() 
        // vi vay phai chia cho so sloness de chay dung so second 

        Time.timeScale = 1f; // reset time ve bt
        Time.fixedDeltaTime = Time.fixedDeltaTime * slowness; // tra lai fixdeltaTime ban dau

        ConfigController.PlayerDataConfig.isActiveMovement = false;
        rb.bodyType = RigidbodyType2D.Kinematic;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        PopupController.Instance.Show<FinishGamePopup>();
    }
}
