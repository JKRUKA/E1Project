using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuButton : MonoBehaviour
{

    [SerializeField] Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        foreach(Transform child in transform.parent.gameObject.transform)
        {
            Debug.Log("Loop ran");
            child.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            child.GetComponent<Rigidbody2D>().gravityScale = 50f;
            child.GetComponent<Rigidbody2D>().AddForce(1600 * new Vector2(Random.Range(-6f, 6f), 15f));
            child.GetComponent<Rigidbody2D>().AddTorque(Random.Range(-10f, 10f));
        }
    }

    public void PlayGame()
    {
        StartCoroutine(SwitchScene(2f, "Main Level"));
    }

    public void Credits()
    {
        StartCoroutine(SwitchScene(2f, "Credits"));
    }

    public void ExitGame()
    {
        // Should work for WebGL builds
        #if (UNITY_EDITOR)
            UnityEditor.EditorApplication.isPlaying = false;
        #elif (UNITY_STANDALONE) 
            Application.Quit();
        #elif (UNITY_WEBGL)
            Application.OpenURL("https://heborine.itch.io/deskenestration");
        #endif
    }

    public void Options()
    {
        StartCoroutine(SwitchScene(2f, "Options Menu"));
    }

    private IEnumerator SwitchScene(float d, string sc)
    {
        yield return new WaitForSeconds(d);
        SceneManager.LoadScene(sc);
    }
}
