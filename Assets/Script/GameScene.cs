using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScene : MonoBehaviour
{
    public void GameSceneCtrl()
    {
        SceneManager.LoadScene("MainGame"); //어떤 씬으로 이동할 건지
        Debug.Log("Game Scenes Go");
    }
}
