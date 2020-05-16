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

    public void PlayGame()
    {
        StartCoroutine(DelaySceneLoad());
    }

    public IEnumerator DelaySceneLoad()
    {
        yield return new WaitForSeconds(clickSound.length - 0.25f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public IEnumerator DelayQuit()
    {
        yield return new WaitForSeconds(clickSound.length - 0.25f);
        Application.Quit();
    }

    public void QuitGame()
    {
        Debug.Log("DOBBY IS FREEEEEEE!!!");
        DelayQuit();
    }

}
