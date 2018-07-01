    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using UnityEngine;
    using UnityEngine.Tilemaps;
    using Debug = UnityEngine.Debug;

    public class Ship : IShip
    {
        
        private static IShip _ship;

        public IGameSettings Config { get; private set; }

        public static IShip Instance
        {
            get { return _ship ?? (_ship = new Ship()); }
        }

        private Ship()
        {
            Health = 100f;
            Fuel = 80f;
            Shield = 20f;
            Steam = 80f;
        }
        
        public float Fuel { get; private set; }
        public float Shield { get; private set; }
        public float Health { get; private set; }
        public float Steam { get; private set; }

        public void GenerateShield()
        {
            Fuel = Math.Max(Fuel - Config.FuelTick, 0f);
            Shield = Math.Min(Config.MaxValueShield, Shield + Config.ShieldTick);
        }

        public void ReleaseSteam()
        {
            Steam = Math.Max(Steam - Config.SteamReleaseTick, 0);
        }

        public void InsertFuel(float value)
        {
            Fuel = Math.Min(Config.MaxValueFuelForSteam, Fuel + value);
        }

        public void Update()
        {
            FuelSteamEngine();
            HandleSteamOverload();
            DeleteRepairedTiles();
        }

        private void DeleteRepairedTiles()
        {
            var wallDamageController = GetDamageController();
            wallDamageController.RemoveRepairedTiles();
        }


        public void SetConfig(IGameSettings gameSettings)
        {
            Config = gameSettings;
        }

        public void Damage(float i)
        {
            Health = Math.Max(Health - i, 0);
            var wallDamageController = GetDamageController();
            wallDamageController.ApplyDamage(i * Config.DamageTileMultiplier);
        }

        public void ApplyRapairTick(float repairTick)
        {
            Health = Math.Min(Health + repairTick / Config.DamageTileMultiplier, 100);
        }

        private static WallDamageController GetDamageController()
        {
            var ship = GameObject.FindWithTag("Ship");
            var wallDamageController = ship.GetComponent<WallDamageController>();
            return wallDamageController;
        }

        private void HandleSteamOverload()
        {
            if (Steam > Config.SteamOverloadThreshold)
            {
                var excessSteam = Steam - Config.SteamOverloadThreshold;
                var maxExcessSteam = Config.MaxValueSteam - Config.SteamOverloadThreshold;
                var damageMultiplier = excessSteam / maxExcessSteam;
                Damage(damageMultiplier * Config.MaxSteamDamageTick);
            }
        }

        private void FuelSteamEngine()
        {
            if(Fuel > Config.FuelTick)
            { 
                Steam = Math.Min(Steam + Config.SteamTick, Config.MaxValueSteam);
                Fuel = Math.Max(Fuel - Config.FuelTick, 0f);
            }
            else
            {
                Steam = Math.Max(Steam - Config.SteamTickCooling, 0f);
            }
        }
    }

    public class NullGameSetting : IGameSettings
    {
        public float FuelTick { get; private set; }
        public float SteamTick { get; private set; }
        public float SteamTickCooling { get; private set; }
        public float ShieldTick { get; private set; }
        public float MaxSteamDamageTick { get; private set; }
        public float SteamReleaseTick { get; private set; }
        public float SteamOverloadThreshold { get; private set; }
        public float MaxValueFuelForSteam { get; private set; }
        public float MaxValueShield { get; private set; }
        public float MaxValueSteam { get; private set; }
        public float DamageTileMultiplier { get; private set; }
        public float RepairTick { get; private set; }
    }
