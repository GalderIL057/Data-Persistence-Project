using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
    [SerializeField] InputField inputPlayerName;

    public void StartGame()
    {        
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();    
#else
        Application.Quit();
#endif
    }

    public void BakcMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ReadField()
    {
        if (DataPlayer.instance != null)
        {
            DataPlayer.instance.playerName = inputPlayerName.text;
        }
    }

}
