using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 positionOffset;

    private GameObject cupid;
    private Color defaultColor;
    private Renderer rend;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        defaultColor = rend.material.color;
    }

    private void OnMouseDown()
    {
        if (cupid != null)
        {
            Debug.Log("Can't build there!");
            return;
        }

        GameObject cupidToBuild = BuildManager.instance.GetCupidToBuild();
        cupid = Instantiate(cupidToBuild, transform.position + positionOffset, transform.rotation);
    }

    private void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = defaultColor;
    }
}
