using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackGroundAnim : MonoBehaviour
{
    public GameObject playerLocation;
    public float[] locationX;
    public float[] locationY;
    public float locationZ;

    public void Blue()
    {
        FindObjectOfType<SoundManager>().Play("Click");
        Vector3 locationBlue = new Vector3(locationX[0],locationY[0], locationZ);
        playerLocation.transform.position = locationBlue;

        PlayerPrefs.SetFloat("LocationX", playerLocation.transform.position.x);
        PlayerPrefs.SetFloat("LocationY", playerLocation.transform.position.y);
    }

    public void Tiles()
    {
        FindObjectOfType<SoundManager>().Play("Click");
        Vector3 locationTiles = new Vector3(locationX[1],locationY[1], locationZ);
        playerLocation.transform.position = locationTiles;

        PlayerPrefs.SetFloat("LocationX", playerLocation.transform.position.x);
        PlayerPrefs.SetFloat("LocationY", playerLocation.transform.position.y);
    }

    public void Sky()
    {
        FindObjectOfType<SoundManager>().Play("Click");
        Vector3 locationSky = new Vector3(locationX[2],locationY[2], locationZ);
        playerLocation.transform.position = locationSky;

        PlayerPrefs.SetFloat("LocationX", playerLocation.transform.position.x);
        PlayerPrefs.SetFloat("LocationY", playerLocation.transform.position.y);
    }

    public void Industrial(){
        FindObjectOfType<SoundManager>().Play("Click");
        Vector3 locationInd = new Vector3(locationX[3],locationY[3], locationZ);
        playerLocation.transform.position = locationInd;

        PlayerPrefs.SetFloat("LocationX", playerLocation.transform.position.x);
        PlayerPrefs.SetFloat("LocationY", playerLocation.transform.position.y);
    }
}
