using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour {

    [Header ("Main Menu Items")]
    [SerializeField] Button play;
    [SerializeField] Image fader;
    [SerializeField] Animator fdAnim;

    [Header ("Cinematic animation")]
    [SerializeField] GameObject img;

    // Start is called before the first frame update
    void Start () {
        StartCoroutine (Welcome ());
    }

    IEnumerator Welcome () {
        Debug.Log ("Desvaneciendo imagen");
        fdAnim.SetBool ("Fade", false);
        yield return new WaitUntil (() => fader.color.a == 0);
        fader.gameObject.SetActive (false);
        Debug.Log ("Imagen desvanecida, imagen desactivada");
    }

    public void BStartGame () {
        StartCoroutine (StartGame ());
    }
    IEnumerator StartGame () {
        fader.gameObject.SetActive (true);
        fdAnim.SetBool ("Fade", true);
        yield return new WaitUntil (() => fader.color.a == 1);
        SceneManager.LoadScene ("SampleScene");
    }
}