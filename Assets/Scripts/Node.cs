using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public Vector3 positionOffset;

    [HideInInspector]
    public GameObject cupid;
    [HideInInspector]
    public CupidBlueprint cupidBlueprint;
    [HideInInspector]
    public bool isUpgraded = false;

    private Color defaultColor;
    private Renderer rend;

    BuildManager buildManager;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        defaultColor = rend.material.color;
        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;

        if (cupid != null)
        {
            buildManager.SelectNode(this);
            return;
        }

        if (!buildManager.CanBuild) return;

        BuildCupid(buildManager.GetCupidToBuild());
    }

    private void BuildCupid(CupidBlueprint blueprint)
    {
        if (PlayerStats.Money < blueprint.cost)
        {
            Debug.Log("NOT ENOUGH MONEY TO BUILD");
            return;
        }

        PlayerStats.Money -= blueprint.cost;

        GameObject createdCupid = Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        cupid = createdCupid;

        cupidBlueprint = blueprint;

        GameObject effect = Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 4f);

        Debug.Log("Cupid build!");
    }

    public void UpgradeCupid()
    {
        if (PlayerStats.Money < cupidBlueprint.upgradeCost)
        {
            Debug.Log("NOT ENOUGH MONEY TO UPGRADE");
            return;
        }

        PlayerStats.Money -= cupidBlueprint.upgradeCost;
        // get rid of old turret
        Destroy(cupid);
        // build a new one
        GameObject createdCupid = Instantiate(cupidBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        cupid = createdCupid;
        GameObject effect = Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 4f);

        isUpgraded = true;
    }

    public void SellCupid()
    {
        PlayerStats.Money += cupidBlueprint.GetSellAmount();

        GameObject effect = Instantiate(buildManager.sellEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 4f);

        Destroy(cupid);
        cupidBlueprint = null;
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;

        if (!buildManager.CanBuild) return;

        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor; 
        } else
        {
            rend.material.color = notEnoughMoneyColor;
        }
    }

    private void OnMouseExit()
    {
        rend.material.color = defaultColor;
    }
}
