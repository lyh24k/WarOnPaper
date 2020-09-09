using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Control : MonoBehaviour {

	//SpriteRenderer Sprite_Renderer;
    public GameObject confirm;
    public GameObject help;
	// Use this for initialization
	void Start () {
        confirm.SetActive(false);
        help.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			
            confirm.SetActive(true);
        }
	}

	void OnMouseUp(){
        if (gameObject.name == "begin") {
            

            SceneManager.LoadScene("one");
        } else if (gameObject.name == "exit") {
			

            SceneManager.LoadScene("GUI");
        }
		else if (gameObject.name == "mainexit") {
			

            confirm.SetActive(true);
        }
        else if (gameObject.name == "gobutton")
        {


            SceneManager.LoadScene("GUI");
        }
        else if (gameObject.name == "yes")
        {


            SceneManager.LoadScene("GUI");
        }
        else if (gameObject.name == "no")
        {
            

            Application.Quit();
        }
        else if (gameObject.name == "exitlog")
        {
            
            PlayerPrefs.SetInt("auto", 1);
            SceneManager.LoadScene("Log");
        }
        else if(gameObject.name=="help")
        {
            help.SetActive(true);
            //Debug.Log(help.active);
        }
        else if (gameObject.name == "helpconfirm")
        {
            help.SetActive(false);
        }
    }
}
