using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //int i;
    //private List<GameObject> tmpList;
    //private PlayerControls controls;
    //private Scene OverWorld;
    // Start is called before the first frame update
    
    private void Awake()
    {
        //OverWorld = SceneManager.GetActiveScene();
        if (GameObject.FindGameObjectsWithTag("GameManager").Length >= 1)
        {
            Destroy(gameObject);
            return;
        }
        //controls = new PlayerControls();
        DontDestroyOnLoad(gameObject);
    }
    //private void OnEnable()
    //{
    //    controls.Enable();
    //    controls.Debug.SceneChange.performed += _ => SceneChange();
    //}
    //private void OnDisable()
    //{
    //    controls.Disable();
    //    controls.Debug.SceneChange.performed -= _ => SceneChange();
    //}
    public void SceneChange(int i)
    {
        //i++;
        //i = i % 2;
        SceneManager.LoadScene(i);
        //if (i == 0)
        //{
        //    SceneManager.SetActiveScene(SceneManager.GetSceneAt(0));
        //    //SceneManager.UnloadSceneAsync(1);
        //}
        //if (i == 1)
        //{
        //    SceneManager.LoadScene(i);
        //}

    }
    //public void BattleScene(List<GameObject> keepList)
    //{
    //    SceneManager.LoadScene(1);
    //}
}