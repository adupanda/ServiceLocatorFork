using ServiceLocator.Events;
using ServiceLocator.Map;
using ServiceLocator.Player;
using ServiceLocator.Sound;
using ServiceLocator.UI;
using ServiceLocator.Utilities;
using ServiceLocator.Wave;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameService : GenericMonoSingleton<GameService>
{
    public PlayerService playerService {  get; private set; }

    

    public WaveService waveService { get; private set; }
    public SoundService soundService { get; private set; }

    public EventService eventService { get; private set; }

    [SerializeField] private MapService mapService;
    public MapService MapService => mapService; 

    [SerializeField] private UIService uIService;
    public UIService UIService => uIService;

    [SerializeField] private PlayerScriptableObject playerScriptableObject;
    [SerializeField] private WaveScriptableObject waveScriptableObject;

    [SerializeField] private SoundScriptableObject soundScriptableObject;
    [SerializeField] private AudioSource audioEffects;
    [SerializeField] private AudioSource backgroundMusic;


    private void Awake()
    {
        base.Awake();
        eventService = new EventService();
    }
    private void Start()
    {
        
        playerService = new PlayerService(playerScriptableObject);
        soundService = new SoundService(soundScriptableObject,audioEffects,backgroundMusic);
        waveService = new WaveService(waveScriptableObject);
        

    }

    private void Update()
    {
        playerService.Update();
    }
}
