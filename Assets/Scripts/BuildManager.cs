using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More the one BuildManager in scene");
            return;
        }
        instance = this;
    }

    public GameObject buildEffect;

    private CupidBlueprint cupidToBuild;
    private Node selectedNode;

    public NodeUI nodeUI;

    public bool CanBuild { get { return cupidToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= cupidToBuild.cost; } }

    public void BuildCupidOn(Node node)
    {
        if(PlayerStats.Money < cupidToBuild.cost)
        {
            Debug.Log("NOT ENOUGH MONEY TO BUILD");
            return;
        }

        PlayerStats.Money -= cupidToBuild.cost;

        GameObject cupid =  Instantiate(cupidToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.cupid = cupid;
        GameObject effect = Instantiate(buildEffect, node.GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 4f);

        Debug.Log("Cupid build! Money left: " + PlayerStats.Money);
    }

    public void SelectCupidToBuild(CupidBlueprint cupid)
    {
        cupidToBuild = cupid;
        DeselectNode();
    }

    public void SelectNode(Node node)
    {
        if (selectedNode == node)
        {
            DeselectNode();
            return;
        }

        selectedNode = node;
        cupidToBuild = null;

        nodeUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }
}
