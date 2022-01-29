using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ToolController : MonoBehaviour
{
    MovementScript character;
    Rigidbody2D rigbody2D;
    [SerializeField] float offsetDistance = 1f;
    [SerializeField] float sizeOfInteractableArea = 2f;
    [SerializeField] TileReaderController tileReaderController;
    [SerializeField] MarkerManger markerManger;
    [SerializeField] float maxDistance = 2.5f;
    [SerializeField] CropsManager cropsManager;
    [SerializeField] TileData plowAbleTile;

    Vector3Int selectedTilePosition;
    bool selectable;

    private void Awake()
    {
        character = GetComponent<MovementScript>();
        rigbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        SelectTile();
        Marker();
        CanSelectCheck();
        if (Input.GetMouseButtonDown(0))
        {
            if(UseToolWorld() == true)
            {
                return;
            }
            UseToolGrid();
        }
    }

    private void SelectTile()
    {
        selectedTilePosition = tileReaderController.GetGridPosition(Input.mousePosition, true);
    }

    void CanSelectCheck()
    {
        Vector2 characterPosition = transform.position;
        Vector2 cameraPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        selectable = Vector2.Distance(characterPosition, cameraPosition) < maxDistance;
        markerManger.Show(selectable);
    }

    private void Marker()
    {
        markerManger.markedCellPosition = selectedTilePosition;
    }

    
    private bool UseToolWorld()
    {
        Vector2 posistion = rigbody2D.position + character.lastMotionVector * offsetDistance;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(posistion, sizeOfInteractableArea);

        foreach (Collider2D c in colliders)
        {
            ToolHit hit = c.GetComponent<ToolHit>();
            if(hit != null)
            {
                hit.Hit();
                return true;
            }
        }
        return false;
    }
    private void UseToolGrid()
    {
        if(selectable == true)
        {
            TileBase tileBase = tileReaderController.GetTileBase(selectedTilePosition);
            TileData tileData = tileReaderController.GetTileData(tileBase);
            if(tileData != plowAbleTile)
            {
                return;
            }
            if (cropsManager.Check(selectedTilePosition))
            {
                cropsManager.Seed(selectedTilePosition);
            }
            else
            {
                cropsManager.Plow(selectedTilePosition);
            }
        }
    }
}
