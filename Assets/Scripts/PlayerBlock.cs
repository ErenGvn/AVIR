using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerBlock : MonoBehaviour
{
    [SerializeField]
    private Transform[] controllers = new Transform[2];

    [SerializeField]
    private Transform playerpos;

    [SerializeField]
    private GameObject blockicon;


    [SerializeField]
    private GameObject pausepanel;


    private PlayerHealth playerHealth;


    [SerializeField]
    private float maxhanddistanceval;

    private float startplayerblock;

    private bool isinBlock = false;
    private bool blockbool;

    private bool pauseflag = false;

    [SerializeField]
    private GameObject LosePanel;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
        Time.timeScale = 1;
        LosePanel.SetActive(false);


    }


    private void BlockingStance()
    {
        Vector3 handmidpoint = Vector3.Lerp(controllers[0].position, controllers[1].position, 0.5f);

        float handplayerdistance = Vector3.Distance(playerpos.position, handmidpoint);
        if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
        Debug.LogError(handplayerdistance);
        if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger) && OVRInput.Get(OVRInput.Button.SecondaryHandTrigger) && handplayerdistance<maxhanddistanceval)
        {
            playerHealth.blockmultiplier = 0.35f;

            blockicon.SetActive(true);
            Debug.Log("player blocked");

        }
        else
        {
            playerHealth.blockmultiplier = 1;
            blockbool = false;
            isinBlock = false;
            blockicon.SetActive(false);


        }



    }

    

    void PauseGame()
    {
        Time.timeScale = 0;
        pauseflag = true;
    }
    void ResumeGame()
    {
        Time.timeScale = 1;
        pauseflag = false;
    }

    private IEnumerator DefeatRoutine()
    {
  

        LosePanel.SetActive(true);

        yield return new WaitForSeconds(4);

        SceneManager.LoadScene("MenuScene");

    }


    // Update is called once per frame
    void Update()
    {
        if (isinBlock && !blockbool)
        {
            startplayerblock = Time.time;
            blockbool = true;


        }


        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            Debug.Log("bastý");
            if (!pauseflag)
            {
                PauseGame();
                pausepanel.SetActive(true);
            }

            else
            {
                ResumeGame();
                pausepanel.SetActive(false);
            }
                
        }

        if(OVRInput.GetDown(OVRInput.Button.Two))
        {
            if(pauseflag)
                SceneManager.LoadScene("MenuScene");
        }

        if (playerHealth.currentHealth <= 0)
        {
            StartCoroutine(DefeatRoutine());
        }


        BlockingStance();






    }
}
