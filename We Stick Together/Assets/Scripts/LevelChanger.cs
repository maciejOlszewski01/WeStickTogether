using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelChanger : MonoBehaviour
{
    // Start is called before the first frame update


    // Update is called once per frame
    public Animator animator;

    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        animator.SetBool("fadeOut", true);
    }


}
