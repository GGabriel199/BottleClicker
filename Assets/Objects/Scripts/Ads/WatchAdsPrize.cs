using UnityEngine;
using UnityEngine.SceneManagement;

public class WatchAdsPrize : MonoBehaviour
{
    public void OnButtonPress(){
        PlayerPrefs.DeleteKey("costSoda");
        PlayerPrefs.DeleteKey("costWine");
        PlayerPrefs.DeleteKey("costChoppMachine");
        SceneManager.LoadScene(0);
    }
}
