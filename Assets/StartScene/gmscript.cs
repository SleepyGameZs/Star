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

    //public GameObject CutSceneVideo;

    public VideoPlayer CutScene;

    public GameObject videom;

    public GameObject skipbutton;

    public bool playing = false;

    void Start()
    {
        skipbutton.SetActive(false);

        videom.SetActive(false);
    }
  
    void Update()
    {

    }

    public void PlayVideo()
    {
        CutScene.Play();

        skipbutton.SetActive(true);

        Title.SetActive(false);
        videom.SetActive(true);

       
    }

    public void next()
    {
        SceneManager.LoadScene("SampleScene");
    }
    
}