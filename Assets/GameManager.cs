using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    public GameObject player;
    public ItemContainer inventoryContainer;
    public DragAndDropController dragAndDropController;
    public DayTimeController timeController;

    //note to self add area item pickup and item drop 
}
