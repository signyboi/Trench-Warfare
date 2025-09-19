using UnityEngine;

public class Plot : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Color hoverColour;

    private GameObject tower;
    private Color startColour;

    private void Start()
    {
        startColour = sr.color;
    }
    private void OnMouseEnter()
    {
        sr.color = hoverColour;
    }

    private void OnMouseExit()
    {
        sr.color = startColour;
    }
    private void OnMouseDown()
    {
        if (tower != null) return;

             Tower towerToBuild = BuildManager.main.GetSelectedTower();

        
        if (towerToBuild.cost > LevelManager.main.currency)
        {
            Debug.Log("You can't afford this!");
            return;
        }

        LevelManager.main.SpendCurrency(towerToBuild.cost);

        tower = Instantiate(towerToBuild.prefab, transform.position, Quaternion.identity);

    }
}

