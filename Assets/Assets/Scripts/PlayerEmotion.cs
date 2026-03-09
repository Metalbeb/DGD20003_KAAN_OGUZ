using UnityEngine;

public class PlayerEmotion : MonoBehaviour
{
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void WinChallenge()
    {
        animator.SetTrigger("Happy");
    }

    public void FailChallenge()
    {
        animator.SetTrigger("Sad");
    }

    public void FinalWin()
    {
        animator.SetTrigger("Dance");
    }
}