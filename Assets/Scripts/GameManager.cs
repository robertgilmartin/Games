using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /** Game States
     * 1) Menu
     * 2) InGame
     * 3) GameOver
     * 4) Pause
     * */

    //Enum can be used for constant variables, or to make a list of GameStates. There integers actually similar than an array or List indexes. 
    public enum GameState
    {
        Menu,
        InGame,
        GameOver,
    }

    public GameState currentGameState = GameState.Menu;

    /**
     * Instance is a copy of some template or class. 
     * And Instantiate means create an instance. F.e. an object of a certain class.
     * Now we are creating a GameManager Object called sharedInstance to have all the properties from the Game Manager of that Object.
     * It is called shared because we can access to this GameManager with the next method GetInstance().
     */

    private static GameManager sharedInstance;

    //This "this" reffers to the object with this Game Manager script attached. 
    private void Awake()
    {
        sharedInstance = this;
    }

    // This method is a getter to get all the Game Manager settings in this object. 
    // So we can access to this Game manager instance from other classes using this method with no need to create variables GameManager type. Just directly using the GetInstance function it's enough. 
    public static GameManager GetInstance()
    {
        return sharedInstance;
    }

    // Start our game
    public void StartGame()
    {
        ChangeGameState(GameState.InGame);
    }

    private void Start()
    {
        //StartGame();
        BackToMainMenu();
    }

    // Called when player dies
    public void GameOver()
    {
        ChangeGameState(GameState.GameOver);
    }

    // Called when player quits the game and go back to the main menu
    public void BackToMainMenu()
    {
        ChangeGameState(GameState.Menu);
    }

    void ChangeGameState(GameState newGameState )
    {
        /**
         * Instead of use if else for the enum elements.
         * We can better use the switch statement for a better coding performance. 
         */

        //if(newGameState == GameState.Menu)
        //{
        //    //Let's load the MainMenu Scene

        //}
        //else if (newGameState == GameState.InGame)
        //{
        //    //Let's load the game Scene
        //}
        //else if(newGameState == GameState.GameOver)
        //{
        //    //Let's load the end game Scene
        //}

        //Inside the cases we do the action to switch the scene
        switch(newGameState)
        {
            case GameState.Menu:
                //Let's load the MainMenu Scene
                break;
            case GameState.InGame:
                //Let's load the game Scene
                break;
            case GameState.GameOver:
                //Let's load the end game Scene
                break;
            default:
                newGameState = GameState.InGame;
                break;
        }

        //Here we are updating the class attribute.
        currentGameState = newGameState;
    }
}
