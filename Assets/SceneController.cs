using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
            SceneManager.LoadScene(nextScene);

        }
    }
}
