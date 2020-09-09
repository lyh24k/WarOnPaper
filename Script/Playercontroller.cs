using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Playercontroller : MonoBehaviour {

	public int health=100;
	public float reload = 0.2f;
	public GameObject PrefabAmmo = null;
    public GameObject PrefabAmmo_2_left = null;
    public GameObject PrefabAmmo_2_right = null;
    public GameObject PrefabAmmo_3_mid = null;
    public GameObject PrefabAmmo_3_left = null;
    public GameObject PrefabAmmo_3_right = null;
    public GameObject GunPosition = null;
    public GameObject GunPosition_2_left = null;
    public GameObject GunPosition_2_right = null;
    private bool WeaponsActivated = true;
    public UI_Menu finalscore;
    public GameObject over;
    public Text maxscore;
    public Text curscore;
    private int kindofbullet;
    public AddScore scorechange;
    public AudioSource eattool;
    public AudioSource gameover;
    public AudioSource bgm;
    public AudioSource debuff;
    public GameObject PrefabBoom = null;
    // Use this for initialization
    void Start () {
        over.SetActive(false);
        kindofbullet = 1;
        //Debug.Log(PlayerPrefs.GetString("Maxscore"));
    }
	
	// Update is called once per frame
	void Update () {

        /*if (planeworldPos.x > transform.position.x) {
            transform.Translate (Vector3.right * speed);
        }
        if (planeworldPos.x < transform.position.x) {
            transform.Translate (Vector3.left * speed);
        }
        if (planeworldPos.y > transform.position.y) {
            transform.Translate (Vector3.up * speed);
        }
        if (planeworldPos.y < transform.position.y) {
            transform.Translate (Vector3.down * speed);
        }*/
        

    }
    void LateUpdate() {

            if (WeaponsActivated&&kindofbullet==1) {
			Instantiate (PrefabAmmo, GunPosition.transform.position, PrefabAmmo.transform.rotation);
			WeaponsActivated = false;
			Invoke ("ActivateWeapons", reload);
		}
        if (WeaponsActivated && kindofbullet == 2)
        {
            Instantiate(PrefabAmmo_2_left, GunPosition_2_left.transform.position, PrefabAmmo_2_left.transform.rotation);
            Instantiate(PrefabAmmo_2_right, GunPosition_2_right.transform.position, PrefabAmmo_2_right.transform.rotation);
            WeaponsActivated = false;
            Invoke("ActivateWeapons", reload);
        }
        if (WeaponsActivated && kindofbullet == 3)
        {
            Instantiate(PrefabAmmo_3_mid, GunPosition.transform.position, PrefabAmmo.transform.rotation);
            Instantiate(PrefabAmmo_3_left, GunPosition_2_left.transform.position, PrefabAmmo_2_left.transform.rotation);
            Instantiate(PrefabAmmo_3_right, GunPosition_2_right.transform.position, PrefabAmmo_2_right.transform.rotation);
            WeaponsActivated = false;
            Invoke("ActivateWeapons", reload);
        }
    }
	void ActivateWeapons(){
		WeaponsActivated = true;
	}
	void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "ebullet")
        {
            health -= 5;
            debuff.Play();
        }
		if(other.tag=="supply"||other.tag=="enemy"||other.tag=="Boss")
        {
            health -= 10;
            debuff.Play();
        }
        if (other.tag == "Tool")
        {
            kindofbullet = 2;
                eattool.Play();
        }
        if(other.tag=="health")
        {
            if (health >= 95)
                health = 100;
            else
                health += 10;

            eattool.Play();
        }
        if (other.tag == "debuff")
        {
            health -= 5;
            scorechange.score -= 50;
            debuff.Play();
        }
        if(other.tag=="score")
        {
            scorechange.score += 50;
            eattool.Play();
        }
        if (other.tag == "tool2")
        {
            kindofbullet = 3;
            eattool.Play();
        }
        if (health <= 0)
        {
            WriteScore(finalscore.score.text.Trim());
            over.SetActive(true);

            maxscore.text = PlayerPrefs.GetString("Maxscore");
            curscore.text = finalscore.score.text.Trim();
            Instantiate(PrefabBoom, transform.position, transform.rotation);
            gameover.Play();
            bgm.Stop();
            Destroy(gameObject);
        }

    }
     void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Boss")
        {
            health --;
        }
    }

    void WriteScore(string score)
    {
        string path = Application.persistentDataPath + "/"+PlayerPrefs.GetString("name") + ".txt";
        //Debug.Log(Application.persistentDataPath);
        if (Convert.ToInt32(score) > Convert.ToInt32(PlayerPrefs.GetString("Maxscore")))
        {
            if (File.Exists(path))
            {
            string[] msg = new string[4];
            msg[0] = PlayerPrefs.GetString("name");
            msg[1] = PlayerPrefs.GetString("password");
            msg[2] = score;
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(fs);
            for (int i = 0; i < 3; i++)
            {
                sw.WriteLine(msg[i]);
            }
            sw.Flush();
            sw.Close();
            fs.Close();
            PlayerPrefs.SetString("Maxscore", msg[2]);
            }
        }
    }
	IEnumerator OnMouseDown()  
	{  

		Vector3 ScreenSpace = Camera.main.WorldToScreenPoint(transform.position);  


		Vector3 offset = transform.position-Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,ScreenSpace.z));  

		//当鼠标左键按下时  
		while(Input.GetMouseButton(0))  
		{  
			//得到现在鼠标的2维坐标系位置  
			Vector3 curScreenSpace =  new Vector3(Input.mousePosition.x,Input.mousePosition.y,ScreenSpace.z);     
			//将当前鼠标的2维位置转化成三维的位置，再加上鼠标的移动量  
			Vector3 CurPosition = Camera.main.ScreenToWorldPoint(curScreenSpace)+offset;          
			//CurPosition就是物体应该的移动向量赋给transform的position属性 
			if(CurPosition.y>-3&&CurPosition.y<5&&CurPosition.x>-2.6&&CurPosition.x<2.6)
					transform.position = CurPosition;
			//Debug.Log (CurPosition);
			//这个很主要  
			yield return new WaitForFixedUpdate();  
		}  


	}
}
