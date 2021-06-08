using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<GameObject> objHP = new List<GameObject>();
    public static GameManager instance = null;
    public static int hp = 5;
    public static int maxHp;
    public static bool IsAttack_Return = false;
    bool Pigit;

    public GameObject CharacterPigit1;
    public GameObject CharacterPigit3;
    public GameObject CharacterPigit5;
    public GameObject CharacterPigit7;
    public GameObject CounterSkill;
    public GameObject JupiterSkill;
    public GameObject ReaperSkill;
    public GameObject StrikerSkill;
    public GameObject MenuSet;

    public GameObject current;

    public P_Charactor player;

    public string CurScene { get; set; }

    private void Awake()
    {
    }
    private void Start()
    {
        maxHp = hp;
        instance = this;
        Pigit = false;

        ReSetSel();
    }

    //다시 시작하는 함수
    public void ReTry()
    {
        SceneManager.LoadScene(CurScene);
    }
    public void ChangeScene(string name)
    {
        SceneManager.LoadScene(name);
        CurScene = name;
    }
    public void GameExit()
    {
        ChangeScene("Title2");
    }

    public void GameContinue()
    {
        Time.timeScale = 1;
    }
    void Update()
    {
        if (!player)
            player = GameObject.FindWithTag("Player").GetComponent<P_Charactor>();

        if (Input.GetKeyDown(KeyCode.O))
        {
            hp++;
        }


        if (Input.GetButtonDown("Cancel"))
        {
            if (MenuSet.activeSelf)
            {
                MenuSet.SetActive(false);
                Time.timeScale = 1;
            }

            else
            {
                MenuSet.SetActive(true);
                Time.timeScale = 0;
            }


        }

        switch (hp)
        {
            case 0:
                objHP[4].SetActive(false);
                objHP[3].SetActive(false);
                objHP[2].SetActive(false);
                objHP[1].SetActive(false);
                objHP[0].SetActive(false);
                break;
            case 1:
                objHP[3].SetActive(false);
                objHP[2].SetActive(false);
                objHP[1].SetActive(false);
                objHP[0].SetActive(false);
                break;
            case 2:
                objHP[2].SetActive(false);
                objHP[1].SetActive(false);
                objHP[0].SetActive(false);
                break;
            case 3:
                objHP[1].SetActive(false);
                objHP[0].SetActive(false);
                break;
            case 4:
                objHP[0].SetActive(false);
                break;
            case 5:
                objHP[4].SetActive(true);
                objHP[3].SetActive(true);
                objHP[2].SetActive(true);
                objHP[1].SetActive(true);
                objHP[0].SetActive(true);
                break;
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            if (player.info.hp.isDie)
                return;
            foreach (var item in player.info.skills)
                if (item.delay.isDelay)
                    return;
            if (IsAttack_Return)
            {
                Debug.Log("응 리턴이야~");
                return;
            }
            CharacterPigit1.SetActive(true);
            CharacterPigit3.SetActive(true);
            CharacterPigit5.SetActive(true);
            CharacterPigit7.SetActive(true);

            Pigit = true;
        }
        if (Pigit == true)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                CharacterPigit3.SetActive(false);
                CharacterPigit5.SetActive(false);
                CharacterPigit7.SetActive(false);
                CounterSkill.SetActive(true);
                StrikerSkill.SetActive(false);
                ReaperSkill.SetActive(false);
                JupiterSkill.SetActive(false);
                Pigit = false;
                ObjectManager.PlayerSelect = 0;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                CharacterPigit1.SetActive(false);
                CharacterPigit5.SetActive(false);
                CharacterPigit7.SetActive(false);
                CounterSkill.SetActive(false);
                StrikerSkill.SetActive(false);
                ReaperSkill.SetActive(false);
                JupiterSkill.SetActive(true);
                Pigit = false;
                ObjectManager.PlayerSelect = 3;
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                CharacterPigit1.SetActive(false);
                CharacterPigit3.SetActive(false);
                CharacterPigit7.SetActive(false);
                CounterSkill.SetActive(false);
                StrikerSkill.SetActive(true);
                ReaperSkill.SetActive(false);
                JupiterSkill.SetActive(false);
                Pigit = false;
                ObjectManager.PlayerSelect = 1;
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                CharacterPigit1.SetActive(false);
                CharacterPigit3.SetActive(false);
                CharacterPigit5.SetActive(false);
                CounterSkill.SetActive(false);
                StrikerSkill.SetActive(false);
                ReaperSkill.SetActive(true);
                JupiterSkill.SetActive(false);
                Pigit = false;
                ObjectManager.PlayerSelect = 2;
            }

        }
    }

    void ReSetSel()
    {
        CharacterPigit1.SetActive(true);
        CharacterPigit3.SetActive(true);
        CharacterPigit5.SetActive(true);
        CharacterPigit7.SetActive(true);

        switch (ObjectManager.OldPlayerSelect)
        {
            case 0:
                CharacterPigit3.SetActive(false);
                CharacterPigit5.SetActive(false);
                CharacterPigit7.SetActive(false);
                CounterSkill.SetActive(true);
                StrikerSkill.SetActive(false);
                ReaperSkill.SetActive(false);
                JupiterSkill.SetActive(false);
                break;
            case 1:
                CharacterPigit1.SetActive(false);
                CharacterPigit3.SetActive(false);
                CharacterPigit7.SetActive(false);
                CounterSkill.SetActive(false);
                StrikerSkill.SetActive(true);
                ReaperSkill.SetActive(false);
                JupiterSkill.SetActive(false);
                break;
            case 2:
                CharacterPigit1.SetActive(false);
                CharacterPigit3.SetActive(false);
                CharacterPigit5.SetActive(false);
                CounterSkill.SetActive(false);
                StrikerSkill.SetActive(false);
                ReaperSkill.SetActive(true);
                JupiterSkill.SetActive(false);
                break;
            case 3:
                CharacterPigit1.SetActive(false);
                CharacterPigit5.SetActive(false);
                CharacterPigit7.SetActive(false);
                CounterSkill.SetActive(false);
                StrikerSkill.SetActive(false);
                ReaperSkill.SetActive(false);
                JupiterSkill.SetActive(true);
                break;
        }
    }
}
