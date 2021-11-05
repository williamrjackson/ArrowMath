using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    /// Static Singleton behavior
    protected static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                // Create object
                GameObject newGO = new GameObject();
                // Name it
                newGO.name = "GameManager";
                // Add Component
                _instance = newGO.AddComponent<GameManager>();
            }
            return _instance;
        }
    }
    public UnityAction StateHasChanged;
    public enum GameState {Playing, Paused, WinMenu, GameOverMenu, Launch}
    public GameState _currentState = GameState.Launch;
    public static GameState CurrentState 
    {
        get => Instance._currentState;
        set
        {
            if (value != Instance._currentState)
            {
                Instance._currentState = value;
                Instance.StateHasChanged();
            }
        }
    }
    void Awake ()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this);
        }
    }
}
