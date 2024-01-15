using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class MapLuna : Map
{
    [Header("Map Setting")]
    [SerializeField] private Config_MapLunaData MapLunaData;
    [SerializeField] private TMP_Text TxtCurrentScore;
    [SerializeField] private TMP_Text TxtMaxScore;
    [SerializeField] private Item SpawnPrefab;
    [SerializeField] private Transform SpawnPoint;
    private float CountDown = 0;
    private float CountDown2 = 0;

    private void Awake()
    {
        TxtMaxScore.text = Data.MaxScore + "";
        TxtCurrentScore.text = 0 + "";
    }
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

        int randomImage = Random.Range(0, MapLunaData.ListFruitImages.Count - 1);
        if (randomImage < MapLunaData.ListFruitImages.Count)
        {
            fruit.itemImage.sprite = MapLunaData.ListFruitImages[randomImage];
        }
        Debug.Log(spawnPos + " - " + randomImage + "/" + MapLunaData.ListFruitImages.Count);
    }
    private void SpawnNotFruit()
    {
        float randomX = Random.Range(-5f, 5f);
        var spawnPos = SpawnPoint.position + Vector3.right * randomX;

        var notfruit = Instantiate(SpawnPrefab, spawnPos, Quaternion.identity, SpawnPoint);

        int randomImage = Random.Range(0, MapLunaData.ListFruitImages.Count - 1);
        if (randomImage < MapLunaData.ListNotFruitImages.Count)
        {
            notfruit.itemImage.sprite = MapLunaData.ListNotFruitImages[randomImage];
        }
        Debug.Log(spawnPos + " - " + randomImage + "/" + MapLunaData.ListNotFruitImages.Count);
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
