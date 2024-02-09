using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    private int Player1Points;
    private int Player2Points;
    public TMP_Text Player1PointsText;
    public TMP_Text Player2PointsText;
    public static GameManagerScript Instance;
    private bool pausedGame = false;
    public LifeBarScript lifebar1;
    public LifeBarScript lifebar2;
    public TMP_Text WinLooseText1;
    public TMP_Text WinLooseText2;


    public RechargementTextBehavior reloadingMessage1;
    public RechargementTextBehavior reloadingMessage2;
    public ProgressBarScript progressBar1;
    public ProgressBarScript progressBar2;



    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        Instance = this;
        Player1Points = 0;
        Player2Points = 0;
    }

    public void restart()
    {
        pausedGame = false;
        MenuManager.Instance.restartGame();
    }   

    public void callCoroutinePauseGame()
    {
        Debug.Log("Calling Coroutine from gameManager..");
        StartCoroutine(callPauseGame());
    }

    public IEnumerator callPauseGame() {
        yield return new WaitForSeconds(7);
        Debug.Log("Calling PauseGame from coroutine..");
        MenuManager.Instance.PauseGame();
    }

    public void AttributePoints(bool player1)
    {
        if (player1)
        {
            Player1Points++;
            Player1PointsText.text = $"Points: {Player1Points}";
        }
        else
        {
            Player2Points++;
            Player2PointsText.text = $"Points: {Player2Points}";
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Player1PointsText.text = $"Points: {Player1Points}";
        Player2PointsText.text = $"Points: {Player2Points}";
    }


    private void FixedUpdate()
    {
        Player1PointsText.text = $"Points: {Player1Points}";
        Player2PointsText.text = $"Points: {Player2Points}";
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !pausedGame)
        {
            MenuManager.Instance.PauseGame();
            pausedGame = true;
        }

        else if (Input.GetKeyDown(KeyCode.Escape) && pausedGame)
        {
            MenuManager.Instance.ResumeGame();
            pausedGame = false;
        }
    }
}
