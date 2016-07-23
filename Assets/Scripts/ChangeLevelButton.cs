using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangeLevelButton : MonoBehaviour {
    int actualLevel = 0;
    public GameObject[] levels;

    //acontece quando a cena é criada/recriada
    void Awake()
    {
        try {
            actualLevel = PlayerPrefs.GetInt("actualLevel");
        } catch(System.Exception e)
        {
            actualLevel = 0;
        }
        //cria o gameobject pai que guarda a estrutura fisica do level
        Instantiate(levels[actualLevel]);
    }

    //liga o botao de mudar os niveis
    public void setState(bool lose)
    {
        /*GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<BoxCollider2D>().enabled = true;*/
        //se perder, o botao volta ao nivel atual
        if (lose)
            PlayerPrefs.SetInt("actualLevel", actualLevel);
        //senao, faz o jogo seguir
        //implementar logica de sequencia do jogo dentro deste método
        setNextLevel(actualLevel);
        //faz o jogo parar de rodar
        //Time.timeScale = 0;
    }

    //quando tocar no botao
    public void changeLevel()
    {
        //recarrega a cena 
        GetComponent<Animator>().SetBool("clicked", true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //desliga o botao
        /*GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;*/
    }

    //metodo de controle para troca de niveis
    void setNextLevel(int actualLevel)
    {
        if (actualLevel + 1 <= levels.Length)
            PlayerPrefs.SetInt("actualLevel", actualLevel++);
    }
}
