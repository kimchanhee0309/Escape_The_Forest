using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScene : MonoBehaviour
{
    public void GameSceneCtrl()
    {
        SceneManager.LoadScene("MainGame"); //� ������ �̵��� ����
        Debug.Log("Game Scenes Go");
    }
}
