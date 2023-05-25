﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class PlayerUnit : PlayerClass
{

    public static PlayerUnit instance;
    private CharacterData CharacterData;

    private bool isSetCharacterData = false;

    private void Awake()
    {
        instance = this;
    }

    public void SetCharacterData(CharacterData characterData)
    {
        this.CharacterData = characterData;

        this.PlayerName = characterData.Name;
        this.ClassName = characterData.ClassName;
        this.Position = new Vector3(0, 0, 0);
        this.MoveSpeed = characterData.Stats["haste"] + 2.0f;
        this.MaxHp = characterData.Stats["stamina"] * 10 + 100;
        this.BasicAtkDmg = characterData.Stats["strength"] * 1.5f + 5f;
        this.BasicAtkSpeed = characterData.Stats["haste"] + 5f;
        this.MaxRessource = characterData.Stats["intellect"] * 10 + 100f;
        this.Level = characterData.Level;
        this.Talents = characterData.Talents;
        this.Xp = characterData.Experience_points;
        this.Equipment = characterData.EquipmentList;
        this.Inventory = null; //todo 
        this.Abilities = null; //todo
        this.Stats = characterData.Stats;
        this.InitialStats = characterData.Stats;
        this.ArmorType = ArmorType.Mail; // todo
        this.KeyLevel = characterData.Current_key;
    }


    void Start()
    {
        if (!isSetCharacterData)
        {
            SetCharacterData(AccountManager.Instance.CharacterDatas[AccountManager.Instance.SelectedCharacter]);
            isSetCharacterData = true;
        }

        if (IsOwner)
        {
            GearManager.instance.SetPlayerUnit(this);
            InventoryManager.instance.SetPlayerUnit(this);
            CameraFollowPlayer.instance.SetPlayerUnit(this);
        }

        //transform.position = new Vector3(0, 0, 0);
        this.transform.position = MythicGameManager.Instance.mapData.Item1[0].center;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.interpolation = RigidbodyInterpolation2D.Interpolate;


        // temporaire pour tester
        MaxHp = 5;
        CurrentHp = MaxHp;
        MaxRessource = 20;
        CurrentRessource = MaxRessource;
        RessourceType = "mana";
        ClassName = "necromancer";
        //
        
        base.Start();
    }

    private void Update()
    {
        base.Update();
    }

    private void FixedUpdate()
    {
        base.FixedUpdate();
    }
}
