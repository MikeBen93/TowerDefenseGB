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

    public GameObject standardCupidPrefab;
    public GameObject rocketCupidPrefab;
    public GameObject laserCupidPrefab;

    private CupidBlueprint cupidToBuild;

    public bool CanBuild { get { return cupidToBuild != null; } }

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

        Debug.Log("Cupid build! Money left: " + PlayerStats.Money);
    }

    public void SelectCupidToBuild(CupidBlueprint cupid)
    {
        cupidToBuild = cupid;
    }
}
