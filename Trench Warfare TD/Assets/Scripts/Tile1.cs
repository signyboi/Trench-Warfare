using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
public class Tile1 : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private int captured;
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Color srcolor;
    [SerializeField] private string SceneToChangeTo;

    private Color StartColor;

    void Start()
    {
        StartColor = sr.color;
        captured = 0;
    }

    // Update is called once per frame
    void Update()
    {
        captured = LevelManager.main.alive;
        if (captured == 1 )
        {
            sr.color = Color.red;
        }
    }
    private void OnMouseDown()
    {
        SceneManager.LoadScene(SceneToChangeTo, LoadSceneMode.Single);
    }
}
