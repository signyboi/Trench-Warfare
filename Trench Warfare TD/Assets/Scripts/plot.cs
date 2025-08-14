using UnityEngine;

public class plot : MonoBehaviour
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

        GameObject towerToBuild = BuildManager.main.GetSelectedTower();
        tower =Instantiate(towerToBuild, transform.position, Quaternion.identity);
    }
}

