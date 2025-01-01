using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Main Code of the BookshelfLL_AnimationScript was written by: Wendt Hendrik
/// </summary>
public class PauseMenu_Script : MonoBehaviour
{
    // Reference to the Canvas that holds the pause menu UI
    public Canvas targetCanvas;

    // Reference to the Character_Controller to enable/disable player controls
    public Character_Controller characterController;

    // Reference to the Continue button to resume the game
    public Button continueButton;

    // Boolean flag to track whether the game is paused or not
    private bool isPaused = false;

    private void Start()
    {
        // Add the ClickedContinue method to the continueButton's onClick event
        continueButton.onClick.AddListener(ClickedContinue);
    }

    /// <summary>
    /// Update is called once per frame
    /// Method to check for player input and toggle the pause menu visibility
    /// </summary>
    private void Update()
    {
        // Toggle the pause menu when the Tab key is pressed
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            TogglePauseMenu();
        }

        // Exit the pause menu when the Escape key is pressed, but only if the game is paused
        if (Input.GetKeyDown(KeyCode.Escape) && isPaused)
        {
            ExitPauseMenu();
        }
    }

    /// <summary>
    /// Toggles the pause menu's visibility and controls
    /// </summary>
    private void TogglePauseMenu()
    {
        // Toggle the pause state between paused and unpaused
        isPaused = !isPaused;

        // Ensure the targetCanvas is assigned before attempting to toggle it
        if (targetCanvas != null)
        {
            // Check if the canvas is active, then toggle its visibility
            bool isActive = targetCanvas.gameObject.activeSelf;
            targetCanvas.gameObject.SetActive(!isActive);

            // Disable or enable player controls based on whether the game is paused
            if (isPaused)
            {
                characterController.DisableControls();  // Disable movement and actions
            }
            else
            {
                characterController.EnableControls();  // Re-enable movement and actions
            }
        }
        else
        {
            // Log an error if no Canvas is assigned to the script
            Debug.LogError("No Canvas assigned to the script.");
        }
    }

    /// <summary>
    /// Called when the continue button is clicked to exit the pause menu.
    /// </summary>
    private void ClickedContinue()
    {
        ExitPauseMenu();
    }

    /// <summary>
    /// Exits the pause menu, resumes the game, and hides the pause menu UI.
    /// </summary>
    private void ExitPauseMenu()
    {
        // Set the isPaused flag to false to indicate the game is no longer paused
        isPaused = false;

        // Hide the pause menu by disabling the targetCanvas
        targetCanvas.gameObject.SetActive(false);

        // Re-enable player controls so the player can continue interacting
        characterController.EnableControls();
    }
}
