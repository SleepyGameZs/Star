using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject hurbPanel;
    public GameObject jemmersPanel;

    void Start()
    {
        hurbPanel.SetActive(false);
//        jemmers.setActive(false);

    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            hurbPanel.SetActive(true);

     //       jemmers.setActive(false);
        }
        // if (other.gameObject.tag == "Jemmers")
        //  {
        //      hurbPanel.setActive(false);
        //       jemmers.setActive(true);
        //   }


    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            hurbPanel.SetActive(false);

            //       jemmers.setActive(false);
        }
        // if (other.gameObject.tag == "Jemmers")
        //  {
        //      hurbPanel.setActive(false);
        //       jemmers.setActive(true);
        //   }


    }

}
