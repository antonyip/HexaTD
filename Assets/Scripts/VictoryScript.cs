﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using DG.Tweening;
using System.Collections.Generic;

public class VictoryScript : MonoBehaviour
{
    public GameObject VictoryImage;
    public GameObject DefeatImage;
    public GameObject ExperienceBar;
    public GameObject LootsContainer;

    public int StateMachine = 0;

    public Text DebugText;

    Vector3 DefaultOffscreenPosition = new Vector3(0,3000,0);

    int ExpEarned;
    List<Item> ListOfItemsToDisplay;

    // Use this for initialization
    void Start()
    {
        StateMachine = 0;
        VictoryImage.SetActive(false);
        DefeatImage.SetActive(false);
        ExperienceBar.SetActive(false);
        LootsContainer.SetActive(false);
        VictoryImage.transform.localPosition = DefaultOffscreenPosition;
        DefeatImage.transform.localPosition = DefaultOffscreenPosition;
        ExperienceBar.transform.localPosition = DefaultOffscreenPosition;
        LootsContainer.transform.localPosition = DefaultOffscreenPosition;
    }
	
    public void HandleVictory()
    {
        DebugText.text = "You won this level!";
        VictoryImage.SetActive(true);
        Sequence seq = DOTween.Sequence();
        seq.Append(VictoryImage.transform.DOLocalMove(Vector3.zero, DataManager.NORMALANIMATION));
        seq.AppendInterval(DataManager.LONGANIMATION); // do nothing
        seq.Append(ExperienceBar.transform.DOLocalMove(Vector3.zero, DataManager.NORMALANIMATION));
        seq.AppendInterval(DataManager.LONGANIMATION); // show experience bar going up
        seq.Append(LootsContainer.transform.DOLocalMove(Vector3.zero, DataManager.NORMALANIMATION));
        seq.AppendInterval(DataManager.LONGANIMATION); // show items 1 by 1
        seq.Play();
    }

    public void HandleLost()
    {
        DebugText.text = "You lost!";
        DefeatImage.SetActive(true);
        DefeatImage.transform.DOLocalMove(Vector3.zero, DataManager.NORMALANIMATION);
    }

    public void SpreadExpPoints(int TotalExperiencePoints)
    {
        ExpEarned = TotalExperiencePoints;
        DebugText.text = TotalExperiencePoints.ToString() + " Earned!";
        ExperienceBar.SetActive(true);
    }

    public void DisplayLoots(List<Item> ListOfItems)
    {
        ListOfItemsToDisplay = ListOfItems;
        DebugText.text = "Showing items!";
        LootsContainer.SetActive(true);
    }


}

