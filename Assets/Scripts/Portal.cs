using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour {
    public GameObject other;
    public Vector3 getPairPosition()
    {
        return other.transform.position;
    }
}
