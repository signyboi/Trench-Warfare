using UnityEngine;

public class LevelOneStatus : MonoBehaviour
{
    public static LevelOneStatus main;
      [Header("Attributes")]
    [SerializeField]  public int alive;
    void Start()
    {
        alive = LevelManager.main.alive;
    }

    // Update is called once per frame
    void Update()
    {
        alive = LevelManager.main.alive;
        if (alive == 1)
        {

        }
    }
}
