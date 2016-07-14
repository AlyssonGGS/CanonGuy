﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ChangeSceneButton : MonoBehaviour
{
    //variavel que armazena o nome da proxima cena a ser carregada
    [Tooltip("Escreva o nome da cena aqui")]
    public string scene;//jeito de usar-> Coloque o prefab deste botão no mundo e de o nome da cena que deseja carregar
    //as cenas tem que ser cadastradas no file->build settings
    //quando for criar alguma cena, seja de vitoria, derrota, menu, etc, tem que salvar dentro da pasta de scenes e depois colocar no build setings
    void OnMouseDown()
    {
        SceneManager.LoadScene(scene);
    }
}
