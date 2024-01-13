using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class MapLuna : Map
{
    [Header("Map Data")]
    [SerializeField] private float CurrentScore;

    [Header("Map Setting")]
    [SerializeField] private Item SpawnPrefab;
    [SerializeField] private Transform SpawnPoint;
    [SerializeField] private float CountDown = 0;
    [SerializeField] private List<Sprite> ListFruitImages;
    [SerializeField] private float CountDown2 = 0;
    [SerializeField] private List<Sprite> ListNotFruitImages;
    private void Start()
    {
        PopupController.Instance.GetPopup<UIPopup>().BtnWASDSetActive(false, true, false, true);
    }
    private void Update()
    {
        CountDown += Time.deltaTime;
        if (CountDown < 0.5) return;
        CountDown = 0;
        CountDown2++;

        if (SpawnPoint.childCount > 10) return;

        SpawnFruit();
        if (CountDown2 > 3)
        {
            SpawnNotFruit();
            CountDown2 = 0;
        }
    }
    private void SpawnFruit()
    {
        float randomX = Random.Range(-5f, 5f);
        var spawnPos = SpawnPoint.position + Vector3.right * randomX;

        var fruit = Instantiate(SpawnPrefab, spawnPos, Quaternion.identity, SpawnPoint);

        int randomImage = Random.Range(0, ListFruitImages.Count - 1);
        if (randomImage < ListFruitImages.Count)
        {
            fruit.itemImage.sprite = ListFruitImages[randomImage];
        }
        Debug.Log(spawnPos + " - " + randomImage + "/" + ListFruitImages.Count);
    }
    private void SpawnNotFruit()
    {
        float randomX = Random.Range(-5f, 5f);
        var spawnPos = SpawnPoint.position + Vector3.right * randomX;

        var notfruit = Instantiate(SpawnPrefab, spawnPos, Quaternion.identity, SpawnPoint);

        int randomImage = Random.Range(0, ListFruitImages.Count - 1);
        if (randomImage < ListNotFruitImages.Count)
        {
            notfruit.itemImage.sprite = ListNotFruitImages[randomImage];
        }
        Debug.Log(spawnPos + " - " + randomImage + "/" + ListNotFruitImages.Count);
    }
    public void IncreaseScore(float score)
    {
        CurrentScore += score;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<Item>(out var item))
        {
            item.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            float randomX = Random.Range(-5f, 5f);
            var spawnPos = SpawnPoint.position + Vector3.right * randomX;
            item.transform.DOMove(spawnPos, 0).OnComplete(() =>
            {
                item.transform.DORotate(Vector3.zero, 0);
                item.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                item.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                item.GetComponent<Rigidbody2D>().angularVelocity = 0;
            });

        }
    }
}
