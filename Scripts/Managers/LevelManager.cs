using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelManager : MonoBehaviour
{
    [Header("Attributes")] 
    [SerializeField] private int baseLives = 100;
    [SerializeField] private int baseCurrency = 100;
    [SerializeField] private int startWave = 1;
    
    public static LevelManager main; // static reference
    
    /* The path is how the enemies navigate the map, the path consists of points.
        The enemies go from point to point until they reach the end of the map */
    public Transform[] Path;
    public Transform StartPoint;
    
    
    public event Action<int> OnLivesChanged;
    public event Action<int> OnWaveChanged;
    public event Action<int> OnCurrencyChanged;
    public event Action OnGameOver;
    

    public int currWave;
    public int currency;
    public int livesCount;
    
    private void Awake()
    {
        if (main != null && main != this)
        {
            Destroy(gameObject);
            return;
        }
        main = this;
    }

    private void Start()
    {
        currWave = startWave;
        currency = baseCurrency;
        livesCount = baseLives;
        
        OnLivesChanged?.Invoke(livesCount);
        OnCurrencyChanged?.Invoke(currency);
        OnWaveChanged?.Invoke(startWave);
    }

    public void IncreaseCurrency(int amount)
    {
        currency += amount;
        OnCurrencyChanged?.Invoke(currency);
    }

    // Used when puchasing items
    public bool SpendCurrency(int amount)
    {
        // check if the player has enough currency
        if (amount <= currency)
        {
            currency -= amount;
            OnCurrencyChanged?.Invoke(currency);
            return true;
        }
        else
        {
            Debug.Log("Not enough currency");
            return false;
        }
    }
    public void IncreaseLives(int amount)
    {
        livesCount += amount;
        OnLivesChanged?.Invoke(livesCount);
    }
    
    // decrease amount of lives and check if player loses 
    public void LoseLives(int amount)
    {
        livesCount = Mathf.Max(0, livesCount - amount);
        OnLivesChanged?.Invoke(livesCount);

        if (livesCount <= 0)
        {
            EndGame();
        }
    }
    private void EndGame()
    {
        Debug.Log("Game Over");
        // Optional: Freeze game, show UI, disable spawner, etc.
        Time.timeScale = 0f;
        OnGameOver?.Invoke(); 
    }
    
    // Sets the wave and invokes OnWaveChange, which gets used in menu to update the wave text
    public void SetWave(int wave)
    {
        currWave = wave;
        OnWaveChanged?.Invoke(currWave);
    }

    public int GetCurrentWave()
    {
        return currWave;
    }

}
