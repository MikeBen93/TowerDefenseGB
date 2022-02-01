using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public CupidBlueprint standardCupid;
    public CupidBlueprint rocketCupid;
    public CupidBlueprint laserCupid;

    public Text standardCupidCostText;
    public Text rocketCupidCostText;
    public Text laserCupidCostText;

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
        standardCupidCostText.text = "$" + standardCupid.cost;
        rocketCupidCostText.text = "$" + rocketCupid.cost;
        laserCupidCostText.text = "$" + laserCupid.cost;
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
