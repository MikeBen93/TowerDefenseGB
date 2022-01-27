using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void PurchaseStandardCupid()
    {
        buildManager.SetCupibToBuild(buildManager.standardCupidPrefab);
    }

    public void PurchaseRocketCupid()
    {
        buildManager.SetCupibToBuild(buildManager.rocketCupidPrefab);
    }

    public void PurchaseLaserCupid()
    {
        buildManager.SetCupibToBuild(buildManager.laserCupidPrefab);
    }
}
