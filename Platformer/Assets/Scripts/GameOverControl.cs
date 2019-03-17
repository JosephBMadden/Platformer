using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverControl : MonoBehaviour
{
    public Text title;
    private Animator anim;
    public Player player;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    //called when object is activated
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (MasterControl.Instance.lives <= 0 && anim.GetCurrentAnimatorStateInfo(0).IsName("Waiting"))
        {
            //Debug.Log("lives: " + MasterControl.Instance.lives);
            anim.SetTrigger("FadeIn");
        }
    }

    public void SelectMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
        MasterControl.Instance.lives = 3;
        ((Player)player.GetComponent(typeof(Player))).Revive();
    }

    public void SelectContinue()
    {
        MasterControl.Instance.lives = 3;
        anim.SetTrigger("FadeOut");
        anim.ResetTrigger("FadeIn"); //because trigger gets set 45x //???
        ((Player) player.GetComponent(typeof(Player))).Revive();
    }
}
