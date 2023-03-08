using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    SceneController sceneController;

    private void Update()
    {
        int actualScene = SceneManager.GetActiveScene().buildIndex;
        switch (actualScene)
        {
            case 0:
            case 2:
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    SceneManager.LoadScene(actualScene + 1);
                }
                break;
            default:
                break;
        }


    }
    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
            SceneManager.LoadScene(nextScene);

        }
    }
}
