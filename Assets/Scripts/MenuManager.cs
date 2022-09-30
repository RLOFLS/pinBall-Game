using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{

    public TMP_InputField inputName;
    public TMP_Text titleText;
    
    // Start is called before the first frame update
    void Start()
    {
        if (DataManager.Instance != null)
        {
        	titleText.text = "Best Score: " + DataManager.Instance.maxName + " : " + DataManager.Instance.score;
        	inputName.text = DataManager.Instance.playerName;
        }
    }
    
    public void OnEndInputName()
    {
    	string inputN = inputName.text.Trim();
    	if (DataManager.Instance != null && inputN != "") {
    	    DataManager.Instance.playerName = inputN;
    	}
    }
    
    public void StartGame()
    {
    	SceneManager.LoadScene(1);
    }
    
    public void QuitGame()
    {
#if UNITY_EDITOR
	EditorApplication.ExitPlaymode();
#else
	Application.Quit();
#endif 
   
    }
}
