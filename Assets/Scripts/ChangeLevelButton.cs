using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangeLevelButton : MonoBehaviour {
    int actualLevel = 0,nextLevel = 0;
    public GameObject[] levels;

    //acontece quando a cena é criada/recriada
    void Awake()
    {
        //não destroi esse botao, pq tbm ta servindo de controlador
        DontDestroyOnLoad(gameObject);
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        //faz o tempo voltar a seguir normal
        Time.timeScale = 1;
        //cria o gameobject pai que guarda a estrutura fisica do level
        Instantiate(levels[nextLevel]);
    }

    //liga o botao de mudar os niveis
    public void activate(bool lose)
    {
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<BoxCollider2D>().enabled = true;
        //se perder, o botao volta ao nivel atual
        if (lose)
            nextLevel = actualLevel;
        //senao, faz o jogo seguir
        //implementar logica de sequencia do jogo dentro deste método
        setNextLevel(actualLevel);
        //faz o jogo parar de rodar
        Time.timeScale = 0;
    }

    //quando tocar no botao
    void OnMouseDown()
    {
        //recarrega a cena 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //desliga o botao
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
    }

    //metodo de controle para troca de niveis
    void setNextLevel(int actualLevel)
    {
        if (actualLevel + 1 <= levels.Length)
            nextLevel = actualLevel++;
    }
}
