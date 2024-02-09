using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    public GameObject Panel;
    public void MoveToGameScene1()
    {
        SceneManager.LoadScene(1);
    }

    public void restartGame()
    {
        ResumeGame();
        GameManagerScript.Instance.WinLooseText1.SetText("");
        GameManagerScript.Instance.WinLooseText2.SetText("");
        GameManagerScript.Instance.lifebar1.Reset();
        GameManagerScript.Instance.lifebar2.Reset();
        MoveToGameScene1();
    }

    public void PauseGame()
    {
        Debug.Log("Pause Game ??.");
        Time.timeScale = 0;
        if(Panel!=null)
            Panel.SetActive(true);
    }
    public void ResumeGame()
    {
        if(Panel!= null)
            Panel.SetActive(false);
        Time.timeScale = 1;
    }

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
