// Copyright (C) 2016-2017 David Pol. All rights reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement,
// a copy of which is available at http://unity3d.com/company/legal/as_terms.

using System.Collections;

using UnityEngine;
using UnityEngine.Assertions;

using DG.Tweening;
using TMPro;

using System;

/// <summary>
/// This class wraps the game scene's user interface and it is mostly updated when the server
/// sends updated information to the client.
/// </summary>
public class GameUI : MonoBehaviour
{
    public GameObject playerActiveBackground;
    public GameObject playerInactiveBackground;
    public GameObject opponentActiveBackground;
    public GameObject opponentInactiveBackground;
    public GameObject playerAvatarBorder;
    public GameObject playerAvatarGlow;
    public GameObject opponentAvatarBorder;
    public GameObject opponentAvatarGlow;

    public TextMeshPro playerNameText;
    public TextMeshPro opponentNameText;

    public TextMeshPro playerCastleText;
    public TextMeshPro opponentCastleText;

    public TextMeshPro playerDeckText;
    public TextMeshPro opponentDeckText;
    public TextMeshPro playerHandText;
    public TextMeshPro opponentHandText;
    public TextMeshPro playerGraveyardText;
    public TextMeshPro opponentGraveyardText;

    public PlayerManaBar playerManaBar;
    public TextMeshPro opponentManaText;

    public TextMeshPro playerDefenseText;
    public TextMeshPro opponentDefenseText;
    //public TextMeshPro playerGenhpText;
    //public TextMeshPro opponentGenhpText;

    public TextMeshPro playerWorkersText;
    public TextMeshPro opponentWorkersText;
    public TextMeshPro playerBricksText;
    public TextMeshPro opponentBricksText;
    public TextMeshPro playerSoldiersText;
    public TextMeshPro opponentSoldiersText;
    public TextMeshPro playerWeaponText;
    public TextMeshPro opponentWeaponText;
    public TextMeshPro playerMagicText;
    public TextMeshPro opponentMagicText;
    public TextMeshPro playerCrystalsText;
    public TextMeshPro opponentCrystalsText;


    public SpriteRenderer endTurnSprite;
    public TextMeshPro endTurnTitleText;
    public TextMeshPro endTurnTimeText;
    public EndTurnButton endTurnButton;

    public AudioClip attackAudioSource;
    public AudioClip buildAudioSource;

    private void Awake()
    {
        Assert.IsNotNull(playerActiveBackground);
        Assert.IsNotNull(playerInactiveBackground);
        Assert.IsNotNull(opponentActiveBackground);
        Assert.IsNotNull(opponentInactiveBackground);
        Assert.IsNotNull(playerAvatarBorder);
        Assert.IsNotNull(playerAvatarGlow);
        Assert.IsNotNull(opponentAvatarBorder);
        Assert.IsNotNull(opponentAvatarGlow);
        Assert.IsNotNull(playerNameText);
        Assert.IsNotNull(opponentNameText);
        Assert.IsNotNull(playerCastleText);
        Assert.IsNotNull(opponentCastleText);
        Assert.IsNotNull(playerDeckText);
        Assert.IsNotNull(opponentDeckText);
        Assert.IsNotNull(playerHandText);
        Assert.IsNotNull(opponentHandText);
        Assert.IsNotNull(playerGraveyardText);
        Assert.IsNotNull(opponentGraveyardText);
        Assert.IsNotNull(playerManaBar);
        Assert.IsNotNull(opponentManaText);
        Assert.IsNotNull(endTurnSprite);
        Assert.IsNotNull(endTurnTitleText);
        Assert.IsNotNull(endTurnTimeText);
        Assert.IsNotNull(endTurnButton);

        Assert.IsNotNull(playerDefenseText);
        Assert.IsNotNull(opponentDefenseText);
        //Assert.IsNotNull(playerGenhpText);
        //Assert.IsNotNull(opponentGenhpText);

        Assert.IsNotNull(playerWorkersText);
        Assert.IsNotNull(opponentWorkersText);
        Assert.IsNotNull(playerBricksText);
        Assert.IsNotNull(opponentBricksText);
        Assert.IsNotNull(playerSoldiersText);
        Assert.IsNotNull(opponentSoldiersText);
        Assert.IsNotNull(playerWeaponText);
        Assert.IsNotNull(opponentWeaponText);
        Assert.IsNotNull(playerMagicText);
        Assert.IsNotNull(opponentMagicText);
        Assert.IsNotNull(playerCrystalsText);
        Assert.IsNotNull(opponentCrystalsText);

        Assert.IsNotNull(attackAudioSource);
        Assert.IsNotNull(buildAudioSource);
    }
    //private AudioSource _audioSource = this.gameObject.AddComponent<AudioSource>();

    private void playAttackAudio()
    {
        AudioSource _audioSource = this.gameObject.AddComponent<AudioSource>();
        AudioClip audioClip = attackAudioSource;
        _audioSource.loop = false;
        _audioSource.clip = audioClip;
        _audioSource.Play();
    }

    private void playBuildAudio()
    {
        AudioSource _audioSource = this.gameObject.AddComponent<AudioSource>();
        AudioClip audioClip = buildAudioSource;
        _audioSource.loop = false;
        _audioSource.clip = audioClip;
        _audioSource.Play();
    }

    private IEnumerator textEffect(TextMeshPro text, int org_size, int large_size, int new_value)
    {
        if (text.text == new_value.ToString())
        {
            yield return null;
        }
        else
        {
            text.text = new_value.ToString();
            for (int i = org_size; i <= large_size; i++)
            {
                text.fontSize = i;
                yield return new WaitForSeconds(0.2f / (large_size - org_size));
            }
            yield return new WaitForSeconds(0.6f);
            for (int i = large_size; i >= org_size; i--)
            {
                text.fontSize = i;
                yield return new WaitForSeconds(0.2f / (large_size - org_size));
            }
        }
    }

    public void SetPlayerActive(bool active)
    {
        playerActiveBackground.SetActive(active);
        playerInactiveBackground.SetActive(!active);
        playerAvatarBorder.SetActive(active);
        playerAvatarGlow.SetActive(active);
    }

    public void SetOpponentActive(bool active)
    {
        opponentActiveBackground.SetActive(active);
        opponentInactiveBackground.SetActive(!active);
        opponentAvatarBorder.SetActive(active);
        opponentAvatarGlow.SetActive(active);
    }

    public void SetPlayerName(string text)
    {
        playerNameText.text = text;
    }

    public void SetOpponentName(string text)
    {
        opponentNameText.text = text;
    }

    public void SetPlayerCastle(int castle)
    {
        if (castle > Int32.Parse(playerCastleText.text))
        {
            playBuildAudio();
        } else if (castle < Int32.Parse(playerCastleText.text))
        {
            playAttackAudio();
        }
        StartCoroutine(textEffect(playerCastleText, 4, 7, castle));
    }

    public void SetOpponentCastle(int castle)
    {
        if (castle < Int32.Parse(opponentCastleText.text))
        {
            playAttackAudio();
        } else if (castle > Int32.Parse(opponentCastleText.text))
        {
            playBuildAudio();
        }
        StartCoroutine(textEffect(opponentCastleText, 4, 7, castle));
    }

    public void SetPlayerDeckCards(int cards)
    {
        playerDeckText.text = cards.ToString();
    }

    public void SetPlayerHandCards(int cards)
    {
        playerHandText.text = cards.ToString();
    }

    public void SetPlayerGraveyardCards(int cards)
    {
        playerGraveyardText.text = cards.ToString();
    }

    public void SetOpponentDeckCards(int cards)
    {
        opponentDeckText.text = cards.ToString();
    }

    public void SetOpponentHandCards(int cards)
    {
        opponentHandText.text = cards.ToString();
    }

    public void SetOpponentGraveyardCards(int cards)
    {
        opponentGraveyardText.text = cards.ToString();
    }

    public void SetPlayerMana(int mana)
    {
        playerManaBar.SetMana(mana);
    }

    public void SetOpponentMana(int mana)
    {
        opponentManaText.text = mana + "/10";
    }

    public void SetPlayerDefense(int defense)
    {
        if (defense > Int32.Parse(playerDefenseText.text))
        {
            playBuildAudio();
        } else if (defense < Int32.Parse(playerDefenseText.text))
        {
            playAttackAudio();
        }
        StartCoroutine(textEffect(playerDefenseText, 7, 11, defense));
    }

    public void SetOpponentDefense(int defense)
    {
        if (defense < Int32.Parse(opponentDefenseText.text))
        {
            playAttackAudio();
        } else if (defense > Int32.Parse(opponentDefenseText.text))
        {
            playBuildAudio();
        }
        StartCoroutine(textEffect(opponentDefenseText, 7, 11, defense));
    }
    /*
    public void SetPlayerGenhp(int genhp)
    {
        playerGenhpText.text = "GenHP: " + genhp;
    }

    public void SetOpponentGenhp(int genhp)
    {
        opponentGenhpText.text = "GenHP: " + genhp;
    }
    */
    public void SetPlayerWorkers(int workers)
    {
        StartCoroutine(textEffect(playerWorkersText, 5, 9, workers));
    }

    public void SetOpponentWorkers(int workers)
    {
        StartCoroutine(textEffect(opponentWorkersText, 5, 9, workers));
    }

    public void SetPlayerBricks(int bricks)
    {
        StartCoroutine(textEffect(playerBricksText, 5, 9, bricks));
    }

    public void SetOpponentBricks(int bricks)
    {
        StartCoroutine(textEffect(opponentBricksText, 5, 9, bricks));
    }

    public void SetPlayerSoldiers(int soldiers)
    {
        StartCoroutine(textEffect(playerSoldiersText, 5, 9, soldiers));
    }

    public void SetOpponentSoldiers(int soldiers)
    {
        StartCoroutine(textEffect(opponentSoldiersText, 5, 9, soldiers));
    }

    public void SetPlayerWeapon(int weapon)
    {
        StartCoroutine(textEffect(playerWeaponText, 5, 9, weapon));
    }

    public void SetOpponentWeapon(int weapon)
    {
        StartCoroutine(textEffect(opponentWeaponText, 5, 9, weapon));
    }

    public void SetPlayerMagic(int magic)
    {
        StartCoroutine(textEffect(playerMagicText, 5, 9, magic));
    }

    public void SetOpponentMagic(int magic)
    {
        StartCoroutine(textEffect(opponentMagicText, 5, 9, magic));
    }

    public void SetPlayerCrystals(int crystals)
    {
        StartCoroutine(textEffect(playerCrystalsText, 5, 9, crystals));
    }

    public void SetOpponentCrystals(int crystals)
    {
        StartCoroutine(textEffect(opponentCrystalsText, 5, 9, crystals));
    }

    public void SetEndTurnButtonEnabled(bool enabled)
    {
        endTurnButton.SetEnabled(enabled);
    }

    public void StartTurnCountdown(int time)
    {
        endTurnSprite.DOFade(1.0f, 0.3f);
        endTurnTitleText.DOFade(1.0f, 0.3f);
        endTurnTimeText.DOFade(1.0f, 0.3f);
        StartCoroutine(StartCountdown(time));
    }

    public void HideTurnCountdown()
    {
        endTurnSprite.DOFade(0.0f, 0.2f);
        endTurnTitleText.DOFade(0.0f, 0.2f);
        endTurnTimeText.DOFade(0.0f, 0.2f);
    }

    private IEnumerator StartCountdown(int time)
    {
        while (time >= 0)
        {
            endTurnTimeText.text = time.ToString();
            yield return new WaitForSeconds(1.0f);
            time -= 1;
        }
    }

    public void StopCountdown()
    {
        StopAllCoroutines();
    }
}
