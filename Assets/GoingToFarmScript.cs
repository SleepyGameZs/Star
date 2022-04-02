using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoingToFarmScript : MonoBehaviour
{
    public GameObject farmButton;

    // Start is called before the first frame update
    void Start()
    {
        //farmButton = GameObject.Find("teleportToFarm");

        farmButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Teleporting()
    {
        farmButton.SetActive(false);
        SceneManager.LoadScene("SampleScene");
    } 

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.tag == "Farm")
        {
            Debug.Log("collisison");
            farmButton.SetActive(true);


        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (gameObject.tag == "Farm")
        {
            Debug.Log("left");
            farmButton.SetActive(false);


        }
    }


    /* public void ButtonClicked()
    {
        farmButton.SetActive(false);
        SceneManager.LoadScene("SampleScene");
    }*/

}
