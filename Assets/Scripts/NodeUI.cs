using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    private Node _target;
    public GameObject ui;
    public Text upgradeCostText;
    public Button upgradeButton;

    public void SetTarget(Node target)
    {
        _target = target;

        transform.position = _target.GetBuildPosition();

        if(!target.isUpgraded)
        {
            upgradeCostText.text = "$" + _target.cupidBlueprint.upgradeCost;
            upgradeButton.interactable = true;
        } else
        {
            upgradeCostText.text = "UPGRADED";
            upgradeButton.interactable = false;
        }
        

        ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
    }

    public void Upgrade()
    {
        _target.UpgradeCupid();
        BuildManager.instance.DeselectNode();
    }
}
