using UnityEngine;
using UnityEngine.SceneManagement;
public class Canon : MonoBehaviour {

    Vector3 dir;
    //variavel de referencia para poder desligar o botao depois de atirar
    GameObject fireButton;
    //variavel que guarda a camera, serve para fazer a conversao de pixel para mundo
    //ler documentação da unity Camera.ScreenToWorldPoint
    Camera main;

	void Start () {
        fireButton = GameObject.Find("FireButton");
        main = Camera.main;
	}
	
	void Update ()
    {
        if (Input.touchCount > 0)
        {
            if(Input.touches[0].phase == TouchPhase.Began || Input.touches[0].phase == TouchPhase.Moved)
            { 
                dir = main.ScreenToWorldPoint(Input.GetTouch(0).position);//conversao de pixels pra "metro"
                dir -= transform.position;
                dir.z = 0;
                transform.up = (dir/dir.magnitude);
            }
        }
   	}
}
