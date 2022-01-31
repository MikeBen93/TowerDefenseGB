using UnityEngine;

public class NodeUI : MonoBehaviour
{
    private Node _target;
    public GameObject ui;

    public void SetTarget(Node target)
    {
        _target = target;

        transform.position = _target.GetBuildPosition();

        ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
    }
}
