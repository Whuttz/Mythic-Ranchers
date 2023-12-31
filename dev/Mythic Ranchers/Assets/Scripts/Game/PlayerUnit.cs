﻿using UnityEngine;

/*******************************************************************************

   Nom du fichier: PlayerUnit.cs
   
   Contexte: Cette classe représente la classe d'un playable character
   
   Auteur: Christophe Auclair
   
   Collaborateurs: Matei Pelletier

*******************************************************************************/

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
        this.InitialMoveSpeed = characterData.Stats["haste"] + 2.0f;
        this.MaxHp = characterData.Stats["stamina"] * 10 + 100;
        this.CurrentHp = MaxHp;
        this.BasicAtkDmg = characterData.Stats["strength"] * 1.5f + 5f;
        this.BasicAtkSpeed = characterData.Stats["haste"] + 5f;
        this.Level = characterData.Level;
        this.Talents = characterData.Talents;
        this.Xp = characterData.Experience_points;
        this.Equipment = characterData.EquipmentList;
        this.Inventory = null; //todo 
        this.Abilities = null; //todo
        this.Stats = characterData.Stats;
        this.InitialStats = characterData.Stats;
        this.KeyLevel = characterData.Current_key;

        if (ClassName == "Berzerker")
        {
            this.MaxRessource = characterData.Stats["intellect"] * 2 + 40f;
            this.CurrentRessource = MaxRessource;
            this.RessourceType = "energy";
            this.ArmorType = ArmorType.Mail;
        }
        else if (ClassName == "Necromancer")
        {
            this.MaxRessource = characterData.Stats["intellect"] * 10 + 100f;
            this.CurrentRessource = MaxRessource;
            this.RessourceType = "mana";
            this.ArmorType = ArmorType.Cloth;
        }
        else if (ClassName == "Mage")
        {
            this.MaxRessource = characterData.Stats["intellect"] * 10 + 100f;
            this.CurrentRessource = MaxRessource;
            this.RessourceType = "mana";
            this.ArmorType = ArmorType.Leather;
        }
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
            AbilityManager.instance.SetPlayerUnit(this);
        }

        this.transform.position = MythicGameManager.Instance.mapData.Item1[0].center;
        Rigidbody2D rig = GetComponent<Rigidbody2D>();
        rig.bodyType = RigidbodyType2D.Dynamic;
        rig.interpolation = RigidbodyInterpolation2D.Interpolate;
        
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
