using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cierras : MonoBehaviour
{
    public GameObject menu, boton;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Resetearmenu()
    {
        yield return new WaitForSeconds(1.8f);
        Time.timeScale = 0;
        menu.SetActive(true);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            boton.SetActive(false);
            
            StartCoroutine(Resetearmenu());
        }
    }
}
