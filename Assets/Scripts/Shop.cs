using UnityEngine;

public class Shop : MonoBehaviour
{
    public CupidBlueprint standardCupid;
    public CupidBlueprint rocketCupid;
    public CupidBlueprint laserCupid;

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void SelectStandardCupid()
    {
        buildManager.SelectCupidToBuild(standardCupid);
    }

    public void SelectRocketCupid()
    {
        buildManager.SelectCupidToBuild(rocketCupid);
    }

    public void SelectLaserCupid()
    {
        buildManager.SelectCupidToBuild(laserCupid);
    }
}
