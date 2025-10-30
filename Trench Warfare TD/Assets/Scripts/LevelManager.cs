using System.Data;
using System.Diagnostics.CodeAnalysis;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    public static LevelManager main;

    [Header("Attributes")]
    [SerializeField] private string SceneToChangeTo;
    [SerializeField] private int endWave;
    [SerializeField] public int currentWave;

    public Transform startPoint;
    public Transform[] path;
    public int currency;
    public int lives;
    public int alive;
    public int victory;
    private void Awake()
    {
        main = this;
    }
    private void Start()
    {
        lives = 100;
        currency = 100;
        alive = 0;
        victory = 0;
        Time.timeScale = 1;
        endWave = 5;
        }

    public void IncreaseCurrency(int amount)
    {
        currency += amount;
    }

    public void LoseLives(int amount)
    {
        lives -= amount;
        Debug.Log("You Are losing lives!!");
    }
    public bool SpendCurrency(int amount)
    {
        if (amount <= currency)
        {
            currency -= amount;
            return true;
        }
        else
        {
            Debug.Log("You don't have enough to purchase this right now!");
            return false;
        }
        }
    private void Update()
    {
      if (lives <= 0)
        {
               Time.timeScale = 0;
               Debug.Log("You Died!!");
            alive = 1;
            SceneManager.LoadScene(SceneToChangeTo, LoadSceneMode.Single);
        }  
      if (currentWave >= endWave)
        {
            Time.timeScale = 0;
            SceneManager.LoadScene(SceneToChangeTo, LoadSceneMode.Single);
            victory = 1;

        }
           }
        }
       
