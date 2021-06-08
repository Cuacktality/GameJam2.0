using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour {

    [Header ("Main Menu Items")]
    [SerializeField] GameObject mainPanel;
    [SerializeField] Button play;
    [SerializeField] Button next;
    [SerializeField] Image fader;
    [SerializeField] Animator fdAnim;
    [SerializeField] TMP_Text upT;
    [SerializeField] TMP_Text lwT;

    [Header ("Cinematic animation")]
    [SerializeField] GameObject[] img;
    [SerializeField] int cN = 0;

    private Color tP = new Color32 (255, 255, 255, 0);
    private Color wT = new Color32 (255, 255, 255, 255);
    private Color bK = new Color32 (0, 0, 0, 255);

    // Start is called before the first frame update
    void Start () {
        upT.gameObject.GetComponent<TextMeshProUGUI> ().color = tP;
        lwT.gameObject.GetComponent<TextMeshProUGUI> ().color = tP;
        next.gameObject.SetActive (false);
        StartCoroutine (Welcome ());
        for (int i = 0; i <= img.Length - 1; i++) {
            img[i].SetActive (false);
            img[i].gameObject.GetComponent<Image> ().color = tP;
        }
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
        fader.color = Color.Lerp (fader.color, tP, 4f);
        fader.gameObject.SetActive (false);
        mainPanel.SetActive (false);
        img[0].SetActive (true);
        img[0].gameObject.GetComponent<Image> ().color = Color.Lerp (tP, wT, 2f);
        cN = 1;
        next.gameObject.SetActive (true);
    }

    public void BNext () {
        switch (cN) {
            case 1:
                {
                    img[0].SetActive (false);
                    img[1].SetActive (true);
                    img[1].gameObject.GetComponent<Image> ().color = Color.Lerp (tP, wT, 2f);
                    cN = 2;
                    break;
                }
            case 2:
                {
                    img[1].SetActive (false);
                    img[2].SetActive (true);
                    img[2].gameObject.GetComponent<Image> ().color = Color.Lerp (tP, wT, 2f);
                    cN = 3;
                    break;
                }
            case 3:
                {
                    img[2].SetActive (false);
                    img[3].SetActive (true);
                    img[3].gameObject.GetComponent<Image> ().color = Color.Lerp (tP, wT, 2f);
                    cN = 4;
                    break;
                }
            case 4:
                {
                    StartCoroutine (LoadGame ());
                    break;
                }
        }
    }

    IEnumerator LoadGame () {

        fader.gameObject.SetActive (true);
        fdAnim.SetBool ("Fade", true);
        yield return new WaitUntil (() => fader.color.a == 1);
        SceneManager.LoadScene ("Level3");
    }
}