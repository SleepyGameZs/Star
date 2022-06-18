using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonManagerHurb : MonoBehaviour
{
    public Button hurbButton;
    public GameObject narrative;

    void Start()
    {
        Button btn = hurbButton.GetComponent<Button>();
    }
    public void TaskOnClick()
    {
        narrative.SetActive(true);
        Debug.Log("hihi");
    }
}
