using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class CropsTile
{
    public int growTimer;
    public int growStage;
    public Crop crop;
    public SpriteRenderer renderer;

    public bool Complete
    {
        get 
        {
            if(crop == null) { return false; }
            return growTimer >= crop.timeToGrow;
        }
        
    }

    internal void Harvested()
    {
        growTimer = 0;
        growStage = 0;
        crop = null;
        renderer.gameObject.SetActive(false);
    }
}
public class CropsManager : TimeAgent
{
    [SerializeField] TileBase plowed;
    [SerializeField] TileBase seeded;
    [SerializeField] Tilemap targetTileMap;
    [SerializeField] GameObject cropSpritePrefab;

    Dictionary<Vector2Int, CropsTile> crops;

    private void Start()
    {
        crops = new Dictionary<Vector2Int, CropsTile>();
        onTimeTick += Tick;
        Init();
    }

    public void Tick()
    {
        foreach (CropsTile cropsTile in crops.Values)
        {
            if(cropsTile.crop == null)
            {
                continue;
            }

            if (cropsTile.Complete)
            {
                Debug.Log("i'm done growing");
                continue;
            }

            cropsTile.growTimer += 1;

            if (cropsTile.growTimer >= cropsTile.crop.growthStageTime[cropsTile.growStage])
            {
                cropsTile.renderer.gameObject.SetActive(true);
                cropsTile.renderer.sprite = cropsTile.crop.spites[cropsTile.growStage];

                cropsTile.growStage += 1;
            }

            
        }
    }

    public bool Check(Vector3Int position)
    {
        return crops.ContainsKey((Vector2Int)position);
    }
    public void Plow(Vector3Int position)
    {
        if (crops.ContainsKey((Vector2Int)position))
        {
            return;
        }

        CreatePlowedTile(position);
    }

    public void Seed(Vector3Int position, Crop toSeed)
    {
        targetTileMap.SetTile(position, seeded);

        crops[(Vector2Int)position].crop = toSeed;
    }

    private void CreatePlowedTile(Vector3Int position)
    {
        CropsTile crop = new CropsTile();
        crops.Add((Vector2Int)position, crop);

        GameObject go = Instantiate(cropSpritePrefab);
        go.transform.position = targetTileMap.CellToWorld(position);
        go.transform.position -= Vector3.forward * 0.01f; 
        go.SetActive(false);
        crop.renderer = go.GetComponent<SpriteRenderer>();

        targetTileMap.SetTile(position, plowed); 
    }
    internal void PickUp(Vector3Int gridPosition)
    {
        Vector2Int position = (Vector2Int)gridPosition;
        if (crops.ContainsKey(position) == false){ return; }

        CropsTile cropsTile = crops[position];

        //This is to harvest the crop I need to make is so the item goes directly into the iventory
        if (cropsTile.Complete)
        {
            targetTileMap.SetTile(gridPosition, plowed);
            cropsTile.Harvested();
        }
    }
}

