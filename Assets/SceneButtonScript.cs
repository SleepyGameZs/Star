using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneButtonScript : MonoBehaviour
{
    public GameObject buttonPanel;
    private void Start()
    {
        buttonPanel.SetActive(false);
    }
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player")) 
        {
            buttonPanel.SetActive(true);
        }
    }
}
