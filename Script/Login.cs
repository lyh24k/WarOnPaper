using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Login : MonoBehaviour {

	public InputField inputName;
	public InputField inputpassword;
	public Button btnlog;
	public Button btnreg;
    //const string MsgPath = "\\UnityProject\\study1\\Assets\\User\\";
    public GameObject Ts;
    public Text msgtext;
    // Use this for initialization
    void Start () {
		btnlog.onClick.AddListener (LogIn);
		btnreg.onClick.AddListener (Register);
        if (PlayerPrefs.GetInt("auto")==0)
        {
            AutoLog();
        }
	}
	
	// Update is called once per frame
	void Update () {

	}
	void LogIn(){
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (inputName.text.Trim() == "")
        {
            msgtext.text = "请输入用户名";
            Ts.SetActive(true);
            Invoke("SetTextEmpty", 1);
        }
        else if (inputpassword.text.Trim() == "")
        {
            msgtext.text = "请输入密码";
            Ts.SetActive(true);
            Invoke("SetTextEmpty", 1);
        }
        else
        {
            //string path = MsgPath + inputName.text.Trim() + ".txt";
            string path = Application.persistentDataPath+"/"+inputName.text.Trim() + ".txt";
            if (File.Exists(path))
            {
                StreamReader sr = new StreamReader(path);
                string[] line = new string[4];
                int i = 0;
                while ((line[i] = sr.ReadLine()) != null)
                {
                    //Debug.Log(line[i]);
                    i++;
                }
                sr.Close();
                if (string.Equals(inputpassword.text.Trim(), line[1]))
                {
                    PlayerPrefs.SetString("name",inputName.text.Trim());
                    PlayerPrefs.SetString("password", inputpassword.text.Trim());
                    PlayerPrefs.SetString("Maxscore", line[2]);
                    PlayerPrefs.SetInt("auto",0);
                    SceneManager.LoadScene("GUI");
                }
                else
                {
                    msgtext.text = "密码错误";
                    Ts.SetActive(true);
                    Invoke("SetTextEmpty", 1);
                }
            }
            else
            {
                msgtext.text = "用户名不存在";
                Ts.SetActive(true);
                Invoke("SetTextEmpty", 1);
            }
        }
	}
	void Register(){
        SceneManager.LoadScene("register");
	}
    void SetTextEmpty()
    {
        Ts.SetActive(false);
    }
    void AutoLog()
    {
        string path = Application.persistentDataPath + "/" + PlayerPrefs.GetString("name") + ".txt";
        if (File.Exists(path))
        {
            StreamReader sr = new StreamReader(path);
            string[] line = new string[4];
            int i = 0;
            while ((line[i] = sr.ReadLine()) != null)
            {
                //Debug.Log(line[i]);
                i++;
            }
            sr.Close();
            if (string.Equals(PlayerPrefs.GetString("password"), line[1]))
            {
                SceneManager.LoadScene("GUI");
            }
        }
       }
}
