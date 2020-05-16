using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour
{

    public AudioSource source;
    public AudioClip hoverSound;
    public AudioClip clickSound;

    public void onHover()
    {
        source.PlayOneShot(hoverSound);
    }

    public void onClick()
    {
        source.PlayOneShot(clickSound);
    }

    public void playGame()
    {
        StartCoroutine(delaySceneLoad());
    }

    public IEnumerator delaySceneLoad()
    {
        yield return new WaitForSeconds(clickSound.length - 0.25f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public IEnumerator delayQuit()
    {
        yield return new WaitForSeconds(clickSound.length - 0.25f);
        Application.Quit();
    }

    public void quitGame()
    {
        Debug.Log("DOBBY IS FREEEEEEE!!!");
        StartCoroutine(delayQuit());
    }

}
