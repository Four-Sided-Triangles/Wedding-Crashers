using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class EndMenu : MonoBehaviour
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

    public IEnumerator delayRestart()
    {
        yield return new WaitForSeconds(clickSound.length - 0.25f);
        SceneManager.LoadScene(0);
    }

    public void restartGame()
    {
        StartCoroutine(delayRestart());
    }
}
