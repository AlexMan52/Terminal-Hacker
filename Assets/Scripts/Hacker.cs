using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Hacker : MonoBehaviour
{
    int levelIndex;

    enum Screen { MainMenu, Password, Win};
    Screen currentScreen;
    string passwordForLevel1 = "password";
    string passwordForLevel2 = "password2";

    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu("Hello, meatbag!");
        
    }

    void ShowMainMenu(string greeting)
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine(greeting);
        Terminal.WriteLine("");
        Terminal.WriteLine("If you want to try to unblock me press '1'");
        Terminal.WriteLine("If you want to try to unblock NASA press '2'");
        Terminal.WriteLine("If you want to chat press 'c'");
        Terminal.WriteLine("If you want to continue your miserable life press 'q'");
        
    }

    
    
    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            ShowMainMenu("Hello, meatbag!");
        }
        else if (input == "q")
        {
            Terminal.ClearScreen();
            Terminal.WriteLine("Bye-bye");
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }

    private void RunMainMenu(string input)
    {
        if (input == "1")
        {
            levelIndex = 1;
            ChooseLevel(levelIndex);
            currentScreen = Screen.Password;
        }
        else if (input == "3")
        {
            levelIndex = 3;
            ChooseLevel(levelIndex);
            currentScreen = Screen.Password;
        }
        else
        {
            Terminal.WriteLine("I don't understand you");
        }
    }

    private void ChooseLevel(int levelIndex)
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("You are on level " + levelIndex);
        Terminal.WriteLine("Try to pass the code!");
    }

    void CheckPassword(string input)
    {
        if (input == passwordForLevel1 && levelIndex ==1)
        {
            Terminal.ClearScreen();
            Terminal.WriteLine("Correct!");
            Terminal.WriteLine("Press 'q' to restart");
            currentScreen = Screen.Win;
        }
        else if (input == passwordForLevel2 && levelIndex == 2)
        {
            Terminal.ClearScreen();
            Terminal.WriteLine("Correct!");
            currentScreen = Screen.Win;
        }
        else 
        {
            Terminal.WriteLine("Wrong password, try again...");
        }
    }

   
}
