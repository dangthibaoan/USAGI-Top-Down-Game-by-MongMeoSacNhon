using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileController : MonoBehaviour
{
    [SerializeField] private Tilemap TilemapObjects;
    [SerializeField] private float CountDown = 0;

    private void Update()
    {
        ChangeDecor();
    }
    private void ChangeDecor()
    {
        CountDown += Time.deltaTime;
        if (CountDown < 0.5) return;
        CountDown = 0;

        foreach (var position in TilemapObjects.cellBounds.allPositionsWithin)
        {
            TileBase tileBase = TilemapObjects.GetTile(position);

            if (tileBase != null)
            {
                for (int i = 0; i < ConfigController.TileConfig.TilePairs0.Count(); i++)
                {
                    if (tileBase.name == ConfigController.TileConfig.TilePairs0[i].name)
                    {
                        TilemapObjects.SetTile(position, ConfigController.TileConfig.TilePairs1[i]);
                    }
                    else if (tileBase.name == ConfigController.TileConfig.TilePairs1[i].name)
                    {
                        TilemapObjects.SetTile(position, ConfigController.TileConfig.TilePairs0[i]);
                    }
                }
                // if (tileBase.name == FlowerA0.name) TilemapObjects.SetTile(position, FlowerA1);
                // else if (tileBase.name == FlowerA1.name) TilemapObjects.SetTile(position, FlowerA0);
                // else if (tileBase.name == FlowerB0.name) TilemapObjects.SetTile(position, FlowerB1);
                // else if (tileBase.name == FlowerB1.name) TilemapObjects.SetTile(position, FlowerB0);
                // Debug.Log(tileBase.name);
            }
        }
    }
}