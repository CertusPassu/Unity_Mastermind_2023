using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class MastermindManager : MonoBehaviour
{
    #region Serialized attributes
    [SerializeField]
    private GameObject[] _playablePawns;
   
    [SerializeField]
    private Material _goodAnswerMaterials;
    [SerializeField]
    private Material _badAnswerMaterials;
    [SerializeField]
    private int _numberTry;
    [SerializeField]
    public GameObject PawnPrefab;

    [SerializeField]
    private Material _mActivePawnColor;
    #endregion

    #region Getters And Setters
    [SerializeField]
    private int _codeLength;

    public int CodeLength 
    {
        get { return _codeLength; }
         
    }
    
    public Material ActivePawnColor
    {
        get { return _mActivePawnColor; }
    }
    public Material GoodColor { get { return _goodAnswerMaterials; } }
    public Material BadColor { get { return _badAnswerMaterials; } }
 
    public int Try { get { return _numberTry; } }

    public Material [] Colors
    {
        get
        {
            return _pawnMaterials;
        }
    }
    public Material[] GetColors()
    {
        return _pawnMaterials;
    }
    public GameObject[] PlayablePawns
    {
        get { return _playablePawns; }
    }
    #endregion
    #region Events
    public delegate void  StartEvent();
    public static event StartEvent OnStart;

    public delegate void GameOverEvent();
    public static event GameOverEvent OnGameOver;

    public delegate void GameWinEvent();
    public static event GameWinEvent OnGameWin;

    public bool IsGameEnd { get; private set; } = false;

    #endregion

    private Material[] _pawnMaterials;
    // Start is called before the first frame update
    void Start()
    {
        _pawnMaterials = new Material[_playablePawns.Length];
        for (int i=0; i<_playablePawns.Length; i++)
        {
            _pawnMaterials[i] = _playablePawns[i].GetComponent<Renderer>().material;
        }

    }



    public static void StartMasterMind()
    {
        OnStart?.Invoke();
    }
    public void Win()
    {
        IsGameEnd = true;
        OnGameWin?.Invoke();
    }

    public void Loose()
    {
        IsGameEnd= true;
        OnGameOver?.Invoke();
    }
  
}
