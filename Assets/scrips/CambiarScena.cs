using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarScena : MonoBehaviour
{
    public string nombre;
    public Animator anim;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        anim.SetBool("Cambiar", true);
        StartCoroutine(Scena());
    }
    IEnumerator Scena()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(nombre);
    }
}
