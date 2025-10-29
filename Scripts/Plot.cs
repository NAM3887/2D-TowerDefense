using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// Plot.cs will handle the clicking and the placing of towers on plots
public class Plot : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SpriteRenderer sr; // reference to the sprite of this plot
    [SerializeField] private Color HoverColor; // used when changing the color of the plot when the user has their mouse over this plot
   
    private GameObject tower;
    private Color StartColor;

    private void Start()
    {
        StartColor = sr.color; // save the starting color so we can revert it back if it gets changed
    }

    // when the mouse moves over the collider on the object change the color of this plot
    private void OnMouseEnter()
    {
        sr.color = HoverColor; 
    }

    // When the user clicks the mouse
    private void OnMouseDown()
    {
        // handle when player misclicks the backgound of the menu and/or misses the button
        if(EventSystem.current.IsPointerOverGameObject()) return; // we don't want to build a tower so return
        
        // this is when the player clicks the plot when there is a tower already occupying it
        if (tower != null) return; // todo add menu to upgrade or sell  tower
        
        // Get the tower that needs to be built
        Tower towerToBuild = BuildManager.main.GetSelectedTower();
        
        // Handle Currency when building
        if (towerToBuild.cost > LevelManager.main.currency) // Handle when the player can't afford the tower
        {   
            // TODO add UI popup to display this message
            Debug.Log("Not enough money");
            return;
        }
        // Spend the currency
        LevelManager.main.SpendCurrency(towerToBuild.cost);
        
        // Build tower
        tower = Instantiate(towerToBuild.prefab, transform.position, Quaternion.identity);
        // TODO add some sort of effect maybe sound or vfx or a popup
        Debug.Log("Build tower here" + name);
    }

    // Called when the mouse leaves this plots collider, revert the color of the plot back to the start color
    private void OnMouseExit()
    {
        sr.color = StartColor;
    }
}
