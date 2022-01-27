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

    private GameObject cupidToBuild;

    public GameObject GetCupidToBuild()
    {
        return cupidToBuild;
    }

    public void SetCupibToBuild(GameObject cupid)
    {
        cupidToBuild = cupid;
    }
}
