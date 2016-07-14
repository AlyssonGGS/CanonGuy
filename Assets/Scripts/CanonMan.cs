using UnityEngine;
using UnityEngine.SceneManagement;
public class CanonMan : MonoBehaviour
{
    Fire fireButton;
    ChangeLevelButton changeLevelButton;
    Rigidbody2D rigidbody;
    SpriteRenderer renderer;
    //variavel de controle para dizer se ele acabou de sair de um transporte ou n
    bool teleport;
    // Use this for initialization
    void Start()
    {
        fireButton = GameObject.Find("FireButton").GetComponent<Fire>();
        changeLevelButton = GameObject.Find("NextLevelButton").GetComponent<ChangeLevelButton>();

        rigidbody = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
        
        teleport = false;
    }

    // Update is called once per frame
    void Update()
    {
        //caso possa atirar
        if (fireButton.GetComponent<Fire>().canShot)
        {
            //liga a gravidade
            rigidbody.gravityScale = 1;
            //adiciona a força de movimento de acordo com a direção do canhão(transform.parent.up)
            rigidbody.AddForce(transform.parent.up * fireButton.force, ForceMode2D.Impulse);
            //desliga o canhao
            fireButton.canShot = false;
            //desliga a ligação entre canhao e homem bala
            transform.SetParent(null);
        }
        //quando estiver em movimento
        if (!transform.parent)
        {
            ///ajeita a posição do personagem de acordo com o movimento
            if (rigidbody.velocity != Vector2.zero)
                transform.up = rigidbody.velocity.normalized;
            //ajeita a direção do sprite
            if (rigidbody.velocity.x > 0)
                renderer.flipX = false;
            else
                renderer.flipX = true;
        }
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        //se colidir com o chao ou parede
        if (c.gameObject.CompareTag("Ground") || c.gameObject.CompareTag("Wall"))
        {
            //religa o botao dizendo que perdeu(é a parte do true)
            changeLevelButton.activate(true);
        }
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        //caso toque no portal
        if (c.gameObject.CompareTag("Portal") && !teleport)
        {
            //manda o player pra posição do par do portal
            rigidbody.position = c.gameObject.GetComponent<Portal>().getPairPosition();
            //logica do teleporte
            teleport = true;
        }
        else if (c.gameObject.CompareTag("Spring"))
        {
            //Adiciona uma nova força na direção da mola de acordo com a velocidade e o fato de multiplicação da mola
            rigidbody.AddForce(c.gameObject.transform.up * c.gameObject.GetComponent<Mola>().mult * rigidbody.velocity.magnitude, ForceMode2D.Impulse);
        }
        else if (c.gameObject.CompareTag("Target"))
        {
            //religa o botao dizendo que ganhou(é a parte do false)
            changeLevelButton.activate(false);
        }
    }

    void OnTriggerExit2D(Collider2D c)
    {
        if (c.gameObject.CompareTag("Portal") && !teleport)
        {
            teleport = false;
        }
    }
}
