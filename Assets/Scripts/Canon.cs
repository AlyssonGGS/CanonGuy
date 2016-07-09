using UnityEngine;
using UnityEngine.SceneManagement;
public class Canon : MonoBehaviour {

    Vector3 dir;
    GameObject fireButton;
    Camera main;
	// Use this for initialization
	void Start () {
        fireButton = GameObject.Find("FireButton");
        main = Camera.main;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.touchCount > 0)
        {
            dir = main.ScreenToWorldPoint(Input.GetTouch(0).position);//conversao de pixels pra "metro"
            dir -= transform.position;
            dir.z = 0;
            transform.up = (dir/dir.magnitude);
        }
   	}
}
