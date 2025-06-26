using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransistionScenes : MonoBehaviour
{
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMaze");
    }
}
