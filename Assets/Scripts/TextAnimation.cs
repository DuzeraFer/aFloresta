using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextAnimation : MonoBehaviour
{
    public Animator TextAnim;

    private void OnBecameVisible()
    {
        TextAnim.SetBool("IsVisible", true);
    }

    private void OnBecameInvisible()
    {
        TextAnim.SetBool("IsVisible", false);
    }
}
