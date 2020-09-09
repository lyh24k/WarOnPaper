using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Signup : MonoBehaviour {
    public Button btn;

    public InputField inputName;
    public InputField inputPaswd;
    public GameObject Ts;
    public Text msgtext;
    // Use this for initialization
    void Start () {
        btn.onClick.AddListener(OnClick);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    void OnClick()
    {
        if (inputName.text.Trim() == "")
        {
            msgtext.text = "请输入用户名";
            Ts.SetActive(true);
            Invoke("SetTextEmpty", 1);//延时1s
        }
        else if(inputPaswd.text.Trim()==""){
            msgtext.text = "请输入密码";
            Ts.SetActive(true);
            Invoke("SetTextEmpty", 1);
        }
        else
        {
            string path = Application.persistentDataPath +"/"+ inputName.text.Trim() + ".txt";
            if (File.Exists(path))
            {
                msgtext.text = "用户名已存在";
                Ts.SetActive(true);
                Invoke("SetTextEmpty", 1);
            }
            else
            {
                UserWrite(path);
                SceneManager.LoadScene("Log");
            }
        }
    }
    //注册写入用户信息
    void UserWrite(string path )
    {

        FileStream fs = new FileStream( path,  FileMode.Create);
        string usermessage = inputName.text.Trim()+"\r\n"+inputPaswd.text.Trim()+"\r\n"+"0";
        StreamWriter sw = new StreamWriter(fs);
        sw.Write(usermessage);
        sw.Flush();
        sw.Close();
        fs.Close();
    }
    void SetTextEmpty()
    {
        Ts.SetActive(false);
    }
}
