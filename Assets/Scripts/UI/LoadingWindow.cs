using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingWindow : MonoBehaviour
{
    
    private Animator anim;
    [SerializeField] private GameObject[] playerVisuality;
    AsyncOperation asyncLoad;

    void Start()
    {

        for (int i = 0; i < playerVisuality.Length; ++i)
        {
            anim = playerVisuality[i].GetComponent<Animator>();
            anim.SetBool("isMoving", true);
        }
        

        StartCoroutine(LoadNextSceneAfterTime(5));  

    }  

 

    IEnumerator LoadNextSceneAfterTime(float time)  

    {  

        yield return new WaitForSeconds(time);  

 

        // Загрузить следующую сцену  

        asyncLoad = SceneManager.LoadSceneAsync("Introduction", LoadSceneMode.Single); 
        /*if (asyncLoad.isDone)
        {
            for (int i = 0; i < playerVisuality.Length; ++i)
            {
                anim = playerVisuality[i].GetComponent<Animator>();
                anim.SetBool("isMoving", false);
            }
        }*/

    }

}
