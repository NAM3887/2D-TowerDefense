using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Handles tower selection and tower array
public class BuildManager : MonoBehaviour
{
    public static BuildManager main; // static reference

    [Header("References")]
    /* this array of towers is used when building and selecting towers in the menu
        when the player clicks a button in the menu it changes selected tower int,
        which gets used as the index for the towers array */
    [SerializeField] private Tower[] towers;
    private int selectedTower = 0;

    private void Awake()
    {
        main = this; // set the reference to this
    }

    public Tower GetSelectedTower()
    {
        return towers[selectedTower]; // return the selected tower from the array of towers
    }

    public void SetSelectTower(int _selectedTower)
    {
        selectedTower = _selectedTower;
    }
    
}
