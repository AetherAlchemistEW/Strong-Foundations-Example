using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    //VARIABLES
    //UI components
    public Image healthBacking;
    public Image healthFront;
    public Text healthText;

    //Our scriptable object
    public UISkinObject uiSkin;

    //The UI's private calculation of our health percentage
    private float healthPercentage; //we'll actually be treating this as 0..1 not 0..100

	// Use this for initialization
	void Start ()
    {
        //update UI skin
        UpdateSkin();

		//TODO: Subscribe to gameplay events
	}

    /*private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            UpdateHealth(2, 100);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            UpdateHealth(200, 200);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            UpdateHealth(50, 70);
        }
    }*/

    //We can pass values through with our events, this saves needing references everywhere
    void UpdateHealth(float currentHealth, float maxHealth) 
    {
        healthPercentage = currentHealth / maxHealth;
        healthFront.fillAmount = healthPercentage;
        healthText.text = "Health: " + currentHealth.ToString() + "/" + maxHealth.ToString();

        //This is a ternary operator, it's a neat shorthand form of condition for simple commands that decide an assignment
        //It's really similar to how if statements work in Excel (if that helps).
        //In this case, we're setting either the high health, or low health, colour depending on if our health is above 50%
        healthFront.color = healthPercentage > .5f ? uiSkin.highHealthColour : uiSkin.lowHealthColour;
        //ASSIGNMENT = QUERY ? TRUE VALUE : FALSE VALUE

        //I could have written that as an if-else but that would have been much longer and sort of overkill
    }

    //Take the values from our scriptable object and apply them to the UI
    //We'll get our custom inspector to call this in editor mode as well for us
    void UpdateSkin()
    {
        healthBacking.color = uiSkin.backingColour;
        healthFront.color = uiSkin.highHealthColour;
        //TODO: Font
    }
}
