using UnityEngine;
using System.Collections;

public class InterfaceManager : MonoBehaviour
{
    public Animator changeLevel,changeScene,fade;

    public void playButtonsAnimation()
    {
        changeLevel.Play(changeLevel.runtimeAnimatorController.animationClips[0].name);
        changeScene.Play(changeScene.runtimeAnimatorController.animationClips[0].name);
        fade.Play(fade.runtimeAnimatorController.animationClips[0].name);
    }
}
