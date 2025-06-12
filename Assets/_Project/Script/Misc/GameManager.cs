using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // potrete chiamare le funzioni di questa classe così --> GameManager.Instance.NomeFunzione();
    public static GameManager Instance { get; private set; }

    public UIManager uiManager;

    // In che stato si trova il gioco
    public enum GameState { MainMenu, Playing, Paused, GameOver }


    //Variabili da mostrare a schermo
    [SerializeField] private GameState _currentState;
    [SerializeField] private int _enemiesKilled = 0;
    [SerializeField] private float _timeSurvived = 0f;

    //Properties di quelle variabili

    public GameState CurrentState
    {
        get { return _currentState; }
        private set { _currentState = value; }
    }
    public int EnemiesKilled
    {
        get { return _enemiesKilled; }
        private set { _enemiesKilled = value; }
    }
    public float TimeSurvived
    {
        get { return _timeSurvived; }
        private set { _timeSurvived = value; }
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    void Update()
    {
        //facciamo partire il timer quando la partita è in Playing
        if (CurrentState == GameState.Playing)
        {
            TimeSurvived += Time.deltaTime;
            uiManager.UpdateTime(_timeSurvived); //aggiornare timer a schermo
        }
    }

    /////////////////////// METODI UTILIZZABILI /////////////////////////////////////

    private void ChangeState(GameState newState)
    {
        _currentState = newState; 

        switch (_currentState)
        {
            case GameState.MainMenu:
                // Logica per quando torniamo al menu
                Time.timeScale = 1f;
                break;
            case GameState.Playing:
                // Logica per quando inizia il gioco
                Time.timeScale = 1f;
                break;
            case GameState.Paused:
                // Logica per la pausa
                Time.timeScale = 0f; // Ferma il tempo!
                break;
            case GameState.GameOver:
                // Logica per la fine del gioco
                Time.timeScale = 0f; // Ferma il tempo!
                uiManager.ShowGameOverScreen(); // Chiedi alla UI di mostrare la schermata
                break;
        }
    }

    public void StartGame()
    {
        _enemiesKilled = 0;
        _timeSurvived = 0f;
        ChangeState(GameState.Playing);
        uiManager.ShowGameScreen();
    }

    public void TogglePause()
    {
        if (_currentState == GameState.Playing)
        {
            ChangeState(GameState.Paused);
            uiManager.ShowPauseScreen(true);
        }
        else if (_currentState == GameState.Paused)
        {
            ChangeState(GameState.Playing);
            uiManager.ShowPauseScreen(false);
        }
    }
    public void PlayerDied()
    {
        ChangeState(GameState.GameOver);
    }

    public void AddKill()
    {
        if (_currentState != GameState.Playing) return;
        _enemiesKilled++;
        uiManager.UpdateKills(_enemiesKilled);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }    

    //public void LevelUp()
    //{
    //    string nextLevel = "Level2";
    //     
    //}

}
