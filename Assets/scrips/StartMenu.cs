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
    [SerializeField] TMP_Text upT;
    [SerializeField] TMP_Text lwT;
    [Header ("Cinematic animation")]
    [SerializeField] GameObject img;

    private Color tP = new Color32 (255, 255, 255, 0);
    private Color wT = new Color32 (255, 255, 255, 190);

    // Start is called before the first frame update
    void Start () {
        upT.gameObject.GetComponent<TextMeshProUGUI> ().color = tP;
        lwT.gameObject.GetComponent<TextMeshProUGUI> ().color = tP;
        StartCoroutine (Welcome ());
    }

    IEnumerator Welcome () {
        fdAnim.SetBool ("Fade", false);
        yield return new WaitUntil (() => fader.color.a == 0);
        fader.gameObject.SetActive (false);
        upT.gameObject.GetComponent<TextMeshProUGUI> ().color = Color.Lerp (tP, wT, 1f);
        lwT.gameObject.GetComponent<TextMeshProUGUI> ().color = Color.Lerp (tP, wT, 3f);
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