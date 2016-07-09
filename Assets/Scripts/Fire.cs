using UnityEngine;
using System.Collections;
    
public class Fire : MonoBehaviour
{
    public float force { get; set; }
    public bool canShot { get; set; }

    void Start() { force = 30; }

    void OnMouseDown()
    {
        canShot = false;
        GameObject.Find("Canon").GetComponent<Canon>().enabled = false;
    }

    void OnMouseOver()
    {
       if(Input.touchCount > 0 && force < 150)
        force += Time.deltaTime * 30;
    }
    void OnMouseUp()
    {
        canShot = true;
        GetComponent<Renderer>().enabled = false;
    }
}
