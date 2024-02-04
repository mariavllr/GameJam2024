using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.PlayerSettings;
using UnityEngine.UI;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine.XR;
using TMPro;

public class TorrentManager : MonoBehaviour
{
    [SerializeField] float velocidadInternet = 0.001f;
    [SerializeField] GameObject barraProgreso;
    [SerializeField] GameObject fill;
    [SerializeField] TextMeshProUGUI nombreArchivo;
    [SerializeField] TextMeshProUGUI pesoArchivo;
    Slider barra;

    DescargasManager descargasManager;

    public bool descargando = false;
    int nivelTorrent = 1;
    int minimoPeso = 1;
    int maximoPeso = 10;
    string nombrePorDefecto = "CharlieYLaFabricaDeChocolate.mp4";


    int pesoActual = 0;
    string nombreActual = "";
    public enum Tipo
    {
        mp4, exe, pdf, mp3
    }

    string[] mp4List = {"Whiplash", "ElRetornoDelRey", "Supersalidos", "Torrente3:AunMasTorrente",
        "LaVenganzDeLosSith","Oldboy", "Lalalalalaland",
        "MrTartariaVsMickeyMouseEmpirico","InteresTelar", "RRR", "BobEsponjaVisitaElFondoMarino"};

    string[] exeList = { "FinalFantasyVII", "RDR2","Minecraft","System33","Sekiro","Skyrim","StardewValley","BaldursGate3",
       "HollowKnight","BlasphemousII","SongOfNunu","SilentHill2","SlyCooper","MarioBros","AnimalCrossing","EldelPing"};

    string[] pdfList = {"AlgoritmosYEstructurasDeDatos", "ElArchivoDeLasTormentas", "Berserk", "Jojos", "MortadeloYFilemon", "TeoSeHaceDueñoDeUnKebab", "TheGame"};

    string[] mp3List = { "Quevedo", "ConejoMalo", "MyWay_FrankSinatra", "N**inParis", "Aguaneloyo", "ENMP3", "NeverGonnaGiveYouUp", "HannaMontana" };

    //Lista de imagenes y de nombres

    private void Update()
    {
        if (descargando && gameObject.activeSelf)
        {
            

            barra.value += velocidadInternet;

            

            if (barra.value >= 1)
            {
                descargando = false;
                descargasManager.AddArchivo(pesoActual,nombreActual);
                fill.GetComponent<Image>().color = Color.green;
            }
        }
    }

    private void Awake()
    {
        descargasManager = FindObjectOfType<DescargasManager>();
        fill.GetComponent<Image>().color = Color.blue;
        barra = barraProgreso.GetComponent<Slider>();
    }

    public void BotonDescargandoPulsado()
    {
        descargando = true;
        print("Empieza la descarga");
        GenerarArchivoNuevo();
        
    }

    private void GenerarArchivoNuevo()
    {
        fill.GetComponent<Image>().color = Color.blue;
        barra.value = 0;

        Tipo nuevoTipo;
        switch (UnityEngine.Random.Range(0, 4))
        {
            case 0: nuevoTipo = Tipo.mp4; break;
            case 1: nuevoTipo = Tipo.exe; break;
            case 2: nuevoTipo = Tipo.pdf; break;
            default: nuevoTipo = Tipo.mp3; break;
        }

        string nuevoNombre;
        
        if(nuevoTipo == Tipo.mp4)
        {
            nuevoNombre = mp4List[UnityEngine.Random.Range(0, mp4List.Length)] + ".mp4";

        }
        else if(nuevoTipo == Tipo.exe)
        {
            nuevoNombre = exeList[UnityEngine.Random.Range(0, exeList.Length)] + ".exe";
        }
        else if(nuevoTipo == Tipo.pdf)
        {
            nuevoNombre = pdfList[UnityEngine.Random.Range(0, pdfList.Length)] + ".pdf";

        }
        else
        {
            nuevoNombre = mp3List[UnityEngine.Random.Range(0, mp3List.Length)] + ".mp3";
        }

        nombreActual = nuevoNombre;
        pesoActual = UnityEngine.Random.Range(minimoPeso, maximoPeso);

        nombreArchivo.text = nombreActual;
        pesoArchivo.text = pesoActual.ToString() + " GB";
        
    }
}
