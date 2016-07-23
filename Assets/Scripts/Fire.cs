using UnityEngine;
using System.Collections;
    
public class Fire : MonoBehaviour
{
    public float force { get; set; }
    public bool canShot { get; set; }
    private bool charging;
    void Start() { force = 30; }

    public void turnOffCanon()
    {
        canShot = false;
        GameObject.Find("Canon").GetComponent<Canon>().enabled = false;
    }

    public void addForce()
    {
        charging = true;
    }
    public void fire()
    {
        charging = false;
        canShot = true;
        gameObject.SetActive(false);
    }

    void Update()
    {
        if (force < 150 && charging) { 
            force += Time.deltaTime * 30;
        }
    }
}
