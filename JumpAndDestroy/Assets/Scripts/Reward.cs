using GoogleMobileAds.Api;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reward : MonoBehaviour
{
    private RewardedAd odulluReklam;
    Hero hero;

    private void Start()
    {
        hero = gameObject.GetComponent<Hero>();
        string adUnitId;
        adUnitId = "ca-app-pub-9067077428657675/1648311322";
        this.odulluReklam = new RewardedAd(adUnitId);
        
        this.odulluReklam.OnUserEarnedReward += OyuncuyaOdulVer;
        
    }
    public void ReklamIzlet()
    {
        AdRequest request = new AdRequest.Builder().Build();
        this.odulluReklam.LoadAd(request);
        if (this.odulluReklam.IsLoaded())
        {
            this.odulluReklam.Show();
        }
    }

    private void OyuncuyaOdulVer(object sender, GoogleMobileAds.Api.Reward e)
    {
        hero.LoadNumber();
    }
}
