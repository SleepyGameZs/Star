using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ToolController : MonoBehaviour
{
    MovementScript character;
    Rigidbody2D rigbody2D;
    ToolBarController toolBarController;
    [SerializeField] float offsetDistance = 1f;
    [SerializeField] float sizeOfInteractableArea = 3f;
    [SerializeField] TileReaderController tileReaderController;
    [SerializeField] MarkerManger markerManger;
    [SerializeField] float maxDistance = 2.5f;
    [SerializeField] ToolAction onTilePickUp;

    Vector3Int selectedTilePosition;
    bool selectable;

    private void Awake()
    {
        character = GetComponent<MovementScript>();
        rigbody2D = GetComponent<Rigidbody2D>();
        toolBarController = GetComponent<ToolBarController>();
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

    //If ever needed add the need pick axe or what ever to work here
    private bool UseToolWorld()
    {
        Vector2 posistion = rigbody2D.position + character.lastMotionVector * offsetDistance;

        Item item = toolBarController.GetItem;
        if(item == null) { return false; }
        if (item.onAction == null) {return false; }

        bool complete = item.onAction.OnApply(posistion);

        if (complete == true)
        {
            if (item.onItemUsed != null)
            {
                item.onItemUsed.OnItemUsed(item, GameManager.instance.inventoryContainer);
            }
        }

        return complete;
    }
    private void UseToolGrid()
    {
        if(selectable == true)
        {
            Item item = toolBarController.GetItem;
            if(item == null) {
                PickUpTile();
                return; 

            }
            if(item.onTileAction == null) { return; }

            bool complete = item.onTileAction.OnApplyToTileMap(selectedTilePosition, tileReaderController, item);

            if(complete == true)
            {
                if(item.onItemUsed != null)
                {
                    item.onItemUsed.OnItemUsed(item, GameManager.instance.inventoryContainer);
                }
            }
        }

    }

    private void PickUpTile()
    {
        if(onTilePickUp == null){ return; }

        onTilePickUp.OnApplyToTileMap(selectedTilePosition, tileReaderController, null);
    }
}
