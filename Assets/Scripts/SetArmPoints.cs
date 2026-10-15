using UnityEngine;

public class SetArmPoints : MonoBehaviour
{
    [SerializeField] private Transform[] points;
    [SerializeField] private ArmMovement line;

    private void Start()
    {
        line.SetUpLine(points);
    }

}
