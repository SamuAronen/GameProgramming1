﻿using System;
using System.Collections;
using System.Collections.Generic;
using GameProgramming1.Data;
using GameProgramming1.Systems.SaveLoad;
using GameProgramming1.Utility;
using UnityEngine;

namespace GameProgramming1.Systems
{
    public class Global : MonoBehaviour
    {
        private static Global _instance;
        private static bool _isAppClosing = false;

        public static Global Instance
        {
            get
            {
                if (_instance == null && !_isAppClosing)
                {
                    GameObject globalObj = new GameObject(typeof(Global).Name);
                    _instance = globalObj.AddComponent<Global>();
                }

                return _instance;
            }
        }

        [SerializeField] private Prefabs _prefabs;
        [SerializeField] private Pools _pools;

        public Prefabs Prefabs
        {
            get { return _prefabs; }
        }

        public Pools Pools
        {
            get { return _pools; }
        }

        public GameData CurrentGameData { get; set; }
        public SaveManager SaveManager { get; private set; }
        public GameManager GameManager { get; private set; }

        protected void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
            }

            if (_instance == this)
            {
                Init();
            }
            else
            {
                Destroy(this);
            }
        }

        private void Init()
        {
            Debug.Log("Global Init");
            DontDestroyOnLoad(gameObject);

            Localization.LoadLanguage(SaveManager.Language);

            if (_prefabs == null)
            {
                _prefabs = GetComponentInChildren<Prefabs>();
            }

            if (_pools == null)
            {
                _pools = GetComponentInChildren<Pools>();
            }

            _pools.Init();
            SaveManager = new SaveManager(new JSONSaveLoad<GameData>());
            GameManager = gameObject.GetOrAddComponent<GameManager>();
            GameManager.Init();
        }

        private void OnApplicationQuit()
        {
            _isAppClosing = true;
        }
    }
}