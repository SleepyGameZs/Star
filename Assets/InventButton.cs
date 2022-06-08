﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] Image icon;
    [SerializeField] Text text;
    [SerializeField] Image highlight;

    int myIndex;

    public void SetIndex(int index)
    {
        myIndex = index;
    }

    public void Set(ItemSlot slot)
    {
        icon.gameObject.SetActive(true); 
        icon.sprite = slot.item.icon;

        if (slot.item.stackable == true)
        {
            text.gameObject.SetActive(true);
            text.text = slot.count.ToString();
        }
        else
        {
            text.gameObject.SetActive(false);
        }
    }

    public void Clean()
    {
        icon.sprite = null;
        icon.gameObject.SetActive(false);

        text.gameObject.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ItemPanel itemPanel = transform.parent.GetComponent<ItemPanel>();
        itemPanel.Onclick(myIndex);
    }

    public void Highlight(bool b)
    {
        highlight.gameObject.SetActive(b);
    }
}
