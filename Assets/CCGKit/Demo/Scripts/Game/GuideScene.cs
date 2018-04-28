using System.Collections.Generic;
using System.IO;
using System.Collections;

using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using FullSerializer;
using TMPro;

#if ENABLE_MASTER_SERVER_KIT

using System.Collections;

using MasterServerKit;

#endif

using CCGKit;

/// <summary>
/// For every scene in the demo game, we create a specific game object to handle the user-interface
/// logic belonging to that scene. The home scene just contains the button delegates that trigger
/// transitions to other scenes or exit the game.
/// </summary>
public class GuideScene : BaseScene
{
    [SerializeField]
    private Image GuidePicture;
    [SerializeField]
    private Sprite Guide1;
    [SerializeField]
    private Sprite Guide2;

    private void Awake()
    {
        Assert.IsNotNull(GuidePicture);
        Assert.IsNotNull(Guide1);
        Assert.IsNotNull(Guide2);
    }

    private void Start()
    {
        Application.targetFrameRate = 60;

    }

    public void OnLeftButtonPressed()
    {
        if (GuidePicture.sprite == Guide1)
            GuidePicture.sprite = Guide2;
        else
            GuidePicture.sprite = Guide1;
    }

    public void OnRightButtonPressed()
    {
        if (GuidePicture.sprite == Guide1)
            GuidePicture.sprite = Guide2;
        else
            GuidePicture.sprite = Guide1;
    }

    public void OnBackButtonPressed()
    {
        SceneManager.LoadScene("Home");
    }
}