using UnityEngine;

public class Slicing : MonoBehaviour
{
    public GameObject cutPart;
    public float Distance = 0.5f;

    
    public void Cut()
    {
        cutPart.transform.Translate(
        Vector3.right * Distance,
        Space.World
            );
    }
}
