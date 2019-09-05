using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{

    public string hitTag = "Player";

    public void ResetPlayer()
    {
        StartCoroutine(Die());

        
    }

    IEnumerator Die()
    {        
        yield return new WaitForSeconds(0.4f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
