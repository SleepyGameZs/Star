using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class gmscript : MonoBehaviour
{
    public GameObject playButton;

    public GameObject Title;

    public VideoPlayer CutScene;

    public GameObject videom;

    public GameObject skipbutton;

    public bool playing = false;

    void Start()
    {
        skipbutton.SetActive(false); //This is the play button that appears on the cutscene. 

        videom.SetActive(false); // The video will not play right away. 
    }
  
    void Update()
    {

    }

    public void PlayVideo()
    {
        skipbutton.SetActive(true);
        playButton.SetActive(false); //hide the first button

        GetComponent<AudioSource>().Play(); //Play the button click sound

        CutScene.Play();

        Title.SetActive(false); // hide the title screen
        videom.SetActive(true);

       
    }

    public void next()
    {
        GetComponent<AudioSource>().Play(); //Play the button click sound

        SceneManager.LoadScene("SampleScene");
    }
    
}