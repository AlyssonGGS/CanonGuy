using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ChangeSceneButton : MonoBehaviour
{
    [Tooltip("Escreva o nome da cena aqui")]
    public string scene;
    void OnMouseDown()
    {
        SceneManager.LoadScene(scene);
    }
}
