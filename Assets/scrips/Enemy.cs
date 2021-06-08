using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D Myrig;
    public float speed;
    public GameObject menu, boton;
    public Transform target;
    void Start()
    {
        Myrig = GetComponent<Rigidbody2D>();
            }

    
    void Update()
    {
        Debug.Log(speed);
        StartCoroutine(IniciarCorutina());
    }
    
    IEnumerator IniciarCorutina()
    {
        yield return new WaitForSeconds(1.2f);
        Myrig.velocity = new Vector2(speed, Myrig.velocity.y);
        transform.position = Vector3.MoveTowards(transform.position, target.position, 0.01f);
        
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
            speed = 0;
            StartCoroutine(Resetearmenu());
        }
    }
}
