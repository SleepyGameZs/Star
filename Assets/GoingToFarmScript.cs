using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoingToFarmScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.tag == "Farm")
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
