using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonMenu : MonoBehaviour
{
    private Button optionButton;
    public GameManager gameManager;

    public string[] options;

    // Start is called before the first frame update
    void Start()
    {
        options = new string[5]{ "Pistol_button", "Mortar_button", "Machinegun_button", "Shield_button", "Current_button" };
;
        optionButton = gameObject.GetComponent<Button>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        
        optionButton.onClick.AddListener(ChooseWeapon);
    }

   void ChooseWeapon()
    {
        if (gameManager.canTakeWeapon)
        {
            switch (gameObject.tag)
            {
                case "Pistol_button":
                    gameManager.currentOption = 0;
                    gameManager.currentButton.transform.GetChild(0).transform.GetChild(0).GetComponent<Image>().sprite =
                        gameManager.spriteArray[3];
                    Debug.Log("sp " + gameManager.spriteArray[3]);
                    break;
                case "Mortar_button":
                    gameManager.currentOption = 1;
                    gameManager.currentButton.transform.GetChild(0).transform.GetChild(0).GetComponent<Image>().sprite =
                         gameManager.spriteArray[0];
                    Debug.Log("sp " + gameManager.spriteArray[0]);
                    break;
                case "Machinegun_button":
                    gameManager.currentOption = 2;
                    gameManager.currentButton.transform.GetChild(0).transform.GetChild(0).GetComponent<Image>().sprite =
                         gameManager.spriteArray[1];
                    Debug.Log("sp " + gameManager.spriteArray[1]);
                    break;
                case "Shield_button":
                    gameManager.currentOption = 3;
                    gameManager.currentButton.transform.GetChild(0).transform.GetChild(0).GetComponent<Image>().sprite =
                        gameManager.spriteArray[2];
                    Debug.Log("sp " + gameManager.spriteArray[2]);
                    break;
                case "Current_button":
                     Debug.Log("option active " + options[gameManager.currentOption]);
                    break;
            }


            gameManager.hideButton = gameObject;
           
        }

        
    }

    
}
