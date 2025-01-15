using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneController : MonoBehaviour
{

    public GameObject player;
    public GameObject CanvasPlayer;
    public GameObject Cutscene;
    void Start()
    {
        Cutscene.SetActive(true);
        player.SetActive(false);
        CanvasPlayer.SetActive(false);
        Invoke(nameof(EndCutScene),25);
    }

    public void EndCutScene()
    {
        player.SetActive(true);
        CanvasPlayer.SetActive(true);
        Cutscene.SetActive(false);
    }
    

}
