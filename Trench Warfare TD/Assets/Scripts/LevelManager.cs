using System.Data;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    public static LevelManager main;

    [Header("Attributes")]
    [SerializeField] private string SceneToChangeTo;

    public Transform startPoint;
    public Transform[] path;
    public int currency;
    public int lives;
    public int alive;
    private void Awake()
    {
        main = this;
    }
    private void Start()
    {
        lives = 100;
        currency = 100;
        alive = 0;
        Time.timeScale = 1;
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
    }
    
    }

