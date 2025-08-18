using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private List<Button> buttonsToDisable = new List<Button>();
    
    public void OpenPanel(GameObject panel)
    {
        if (Time.timeScale == 0) return;
        panel.SetActive(true);
        DisableButtons();
        Time.timeScale = 0;
    }
    
    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
        EnableButtons();
        Time.timeScale = 1;
    }

    private void DisableButtons()
    {
        foreach (var button in buttonsToDisable)
        {
            button.interactable = false;
        }    
    }
    
    private void EnableButtons()
    {
        foreach (var button in buttonsToDisable)
        {
            button.interactable = true;
        }    
    }
    
    public void Exit()
    {
        Application.Quit();
    }
    
}
