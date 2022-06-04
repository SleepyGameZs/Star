using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonManagerHurb : MonoBehaviour
{
    // Start is called before the first frame update

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
        // Update is called once per frame
    void Update()
    {
        
    }
}
