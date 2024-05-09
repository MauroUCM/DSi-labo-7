using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class MapScript : MonoBehaviour
{
    int equip = 0;

    VisualElement TreeButton;
    VisualElement ChurchButton;
    VisualElement RuinButton;

    VisualElement MapHolder;

    Label mainText;
    Label regionText;
    Label NameText;

    Label Loot1;
    Label Loot2;
    Label Loot3;
    Label Loot4;
    Label Loot5;
    Label Loot6;
    Label Loot7;

    Label VigorNum;
    Label MindNum;
    Label EnduranceNum;
    Label StrenghtNum;
    Label DexerityNum;
    Label IntelligenceNum;
    Label FaithNum;
    Label ArcaneNum;
    Label MainLevel;
    Label CurrentRunes;
    Label NecRunes;


    VisualElement VigorButton;
    VisualElement MindButton;
    VisualElement EnduranceButton;
    VisualElement StrengthButton;
    VisualElement DexerityButton;
    VisualElement IntelligenceButton;
    VisualElement FaithButton;
    VisualElement ArcaneButton;

    VisualElement HelmHolder;
    VisualElement ArmorHolder;
    VisualElement GauntletHolder;
    VisualElement GreaveHolder;
    VisualElement HelmButton;
    VisualElement ArmorButton;
    VisualElement GauntletButton;
    VisualElement GreaveButton;

    private void reseteoPins() 
    {
        TreeButton.style.unityBackgroundImageTintColor = Color.white;
        ChurchButton.style.unityBackgroundImageTintColor = Color.white;
        RuinButton.style.unityBackgroundImageTintColor = Color.white;
        Loot1.style.display = DisplayStyle.None;
        Loot2.style.display = DisplayStyle.None;
        Loot3.style.display = DisplayStyle.None;
        Loot4.style.display = DisplayStyle.None;
        Loot5.style.display = DisplayStyle.None;
        Loot6.style.display = DisplayStyle.None;
        Loot7.style.display = DisplayStyle.None;
    }

    private bool spendRunes() 
    {
        int auxCurrent = System.Convert.ToInt32(CurrentRunes.text);
        int auxNec = System.Convert.ToInt32(NecRunes.text);

        if (auxCurrent >= auxNec)
        {
            CurrentRunes.text = System.Convert.ToString(auxCurrent - auxNec);

            //aux = System.Convert.ToString(System.Math.Round(auxNec * 1.25));

            NecRunes.text = System.Convert.ToString(System.Math.Round(auxNec * 1.2));

            return true;
        }
        else return false;
    }

    private void reseteoMapYEquip() 
    {
        HelmHolder.style.display = DisplayStyle.None;
        ArmorHolder.style.display = DisplayStyle.None;
        GauntletHolder.style.display = DisplayStyle.None;
        GreaveHolder.style.display = DisplayStyle.None;
        MapHolder.style.display = DisplayStyle.Flex;
    }

    private void OnEnable()
    {   
        UIDocument uidoc = GetComponent<UIDocument>();
        VisualElement rootve = uidoc.rootVisualElement;

        // cosas del mapa
        VisualElement MapPins = rootve.Q("MapImg");
        VisualElement Maptext = rootve.Q("MapInfo");
        VisualElement Loots = rootve.Q("PossibleLoot");
        VisualElement Levels = rootve.Q("Level");
        VisualElement Equipment = rootve.Q("Equipamiento");
        VisualElement MiddleEqupHolder = rootve.Q("MiddleHolder");

        HelmHolder = MiddleEqupHolder.Q("HelmHolder");
        ArmorHolder = MiddleEqupHolder.Q("ArmorHolder");
        GauntletHolder = MiddleEqupHolder.Q("GauntletHolder");
        GreaveHolder = MiddleEqupHolder.Q("GreaveHolder");

        HelmButton = Equipment.Q("HelmetEqup");
        ArmorButton = Equipment.Q("TorsoEqup");
        GauntletButton = Equipment.Q("HandsEqup");
        GreaveButton = Equipment.Q("LegsEqup");

        TreeButton = MapPins.Q("ErdtreeButton");
        ChurchButton = MapPins.Q("EldenChurchButton");
        RuinButton = MapPins.Q("EldenRuinButton");

        mainText = Maptext.Q<Label>("WallOfTextTex");
        regionText = Maptext.Q<Label>("RegionNameText");
        NameText = Maptext.Q<Label>("ZoneNameText");

        Loot1 = Loots.Q<Label>("Loot1");
        Loot2 = Loots.Q<Label>("Loot2");
        Loot3 = Loots.Q<Label>("Loot3");
        Loot4 = Loots.Q<Label>("Loot4");
        Loot5 = Loots.Q<Label>("Loot5");
        Loot6 = Loots.Q<Label>("Loot6");
        Loot7 = Loots.Q<Label>("Loot7");

        VigorNum = Levels.Q<Label>("VigorNumber");
        MindNum = Levels.Q<Label>("MindNumber");
        EnduranceNum = Levels.Q<Label>("EnduranceNumber");
        StrenghtNum = Levels.Q<Label>("StrenghtNumber");
        DexerityNum = Levels.Q<Label>("DexerityNumber");
        IntelligenceNum = Levels.Q<Label>("IntelligenceNumber");
        FaithNum = Levels.Q<Label>("FaithNumber");
        ArcaneNum = Levels.Q<Label>("ArcaneNumber");
        CurrentRunes = Levels.Q<Label>("RunesNum");
        NecRunes = Levels.Q<Label>("RunesNNum");

        MainLevel = rootve.Q<Label>("LevelNum");

        VigorButton = Levels.Q("VigorButton");
        MindButton = Levels.Q("MindButton");
        EnduranceButton = Levels.Q("EnduranceButton");
        StrengthButton = Levels.Q("StrenghtButton");
        DexerityButton = Levels.Q("DexerityButton");
        IntelligenceButton = Levels.Q("IntelligenceButton");
        FaithButton = Levels.Q("FaithButton");
        ArcaneButton = Levels.Q("ArcaneButton");

        // cosas inventario
        VisualElement Holders = rootve.Q("MainHolder");
        MapHolder = Holders.Q("MapStuffHolder");

        HelmButton.RegisterCallback<MouseDownEvent>(evt => {
            
            reseteoMapYEquip();
            if (equip != 1)
            {
                equip = 1;
                HelmHolder.style.display = DisplayStyle.Flex;
                MapHolder.style.display = DisplayStyle.None;
            }
            else equip = 0;
        });

        ArmorButton.RegisterCallback<MouseDownEvent>(evt => {

            reseteoMapYEquip();
            if (equip != 2)
            {
                equip = 2;
                ArmorHolder.style.display = DisplayStyle.Flex;
                MapHolder.style.display = DisplayStyle.None;
            }
            else equip = 0;
        }); 

        GauntletButton.RegisterCallback<MouseDownEvent>(evt => {

            reseteoMapYEquip();
            if (equip != 3)
            {
                equip = 3;
                GauntletHolder.style.display = DisplayStyle.Flex;
                MapHolder.style.display = DisplayStyle.None;
            }
            else equip = 0;
        }); 
        
        GreaveButton.RegisterCallback<MouseDownEvent>(evt => {

            reseteoMapYEquip();
            if (equip != 4)
            {
                equip = 4;
                GreaveHolder.style.display = DisplayStyle.Flex;
                MapHolder.style.display = DisplayStyle.None;
            }
            else equip = 0;
        });

        TreeButton.RegisterCallback<MouseDownEvent>(evt => {
            reseteoPins();
            TreeButton.style.unityBackgroundImageTintColor = Color.gray;
            mainText.text = "The Minor Erdtree, a mystical marvel rooted in ancient lore, captivated civilizations across time with its towering presence and spiritual significance. Believed to be a conduit of cosmic energies and a source of divine wisdom, it was revered as a sacred site of pilgrimage and worship. Despite the passage of ages, the mysteries surrounding the Minor Erdtree endure, its legacy woven into the fabric of myth and legend, a testament to humanity's eternal quest for understanding in the face of the unknown.";
            regionText.text = "Limgrave - Weeping peninsula";
            NameText.text = "Minor Erdtree";
            Loot1.style.display = DisplayStyle.Flex;
            Loot2.style.display = DisplayStyle.Flex;
            Loot3.style.display = DisplayStyle.Flex;
            //MapHolder.style.display = DisplayStyle.None;
        });

        ChurchButton.RegisterCallback<MouseDownEvent>(evt => {
            reseteoPins();
            ChurchButton.style.unityBackgroundImageTintColor = Color.gray;
            mainText.text = "Elden Church, veiled in secrecy and steeped in intrigue, occupies a pivotal role within the tapestry of Elden Ring. Its obscured location and whispered legends draw both the curious and the devout, hinting at the tantalizing mysteries concealed within its ancient walls. As a sanctuary of clandestine gatherings and whispered rites, Elden Church symbolizes humanity's eternal fascination with the forbidden and the enigmatic, leaving an indelible mark on the collective imagination of those who dare to seek the truth.";
            regionText.text = "Limgrave - Weeping peninsula";
            NameText.text = "Elden Church";
            Loot4.style.display = DisplayStyle.Flex;
            Loot5.style.display = DisplayStyle.Flex;
        });
        RuinButton.RegisterCallback<MouseDownEvent>(evt => {
            reseteoPins();
            RuinButton.style.unityBackgroundImageTintColor = Color.gray;
            mainText.text = "Elden Ruins, a testament to the passage of time and the grandeur of civilizations long past, hold a poignant allure within the world of Elden Ring. Concealed amidst the landscape, these crumbling remnants of a bygone era evoke a sense of nostalgia and wonder, drawing adventurers and scholars alike into their midst in search of forgotten treasures and ancient wisdom. As silent witnesses to the rise and fall of empires, Elden Ruins stand as a somber reminder of the impermanence of greatness and the enduring legacy of those who came before.";
            regionText.text = "Limgrave - Weeping peninsula";
            NameText.text = "Elden Ruins";
            Loot4.style.display = DisplayStyle.Flex;
            Loot5.style.display = DisplayStyle.Flex;
            Loot6.style.display = DisplayStyle.Flex;
            Loot7.style.display = DisplayStyle.Flex;
        });
        RuinButton.RegisterCallback<MouseDownEvent>(evt => {
            reseteoPins();
            RuinButton.style.unityBackgroundImageTintColor = Color.gray;
            mainText.text = "Elden Ruins, a testament to the passage of time and the grandeur of civilizations long past, hold a poignant allure within the world of Elden Ring. Concealed amidst the landscape, these crumbling remnants of a bygone era evoke a sense of nostalgia and wonder, drawing adventurers and scholars alike into their midst in search of forgotten treasures and ancient wisdom. As silent witnesses to the rise and fall of empires, Elden Ruins stand as a somber reminder of the impermanence of greatness and the enduring legacy of those who came before.";
            regionText.text = "Limgrave - Weeping peninsula";
            NameText.text = "Elden Ruins";
            Loot4.style.display = DisplayStyle.Flex;
            Loot5.style.display = DisplayStyle.Flex;
            Loot6.style.display = DisplayStyle.Flex;
            Loot7.style.display = DisplayStyle.Flex;
        });

        VigorButton.RegisterCallback<MouseDownEvent>(evt =>
        {
            if (spendRunes()) 
            {
                VigorNum.text = System.Convert.ToString(System.Convert.ToInt32(VigorNum.text) + 1);
                MainLevel.text = System.Convert.ToString(System.Convert.ToInt32(MainLevel.text) + 1);
            }
        });
        MindButton.RegisterCallback<MouseDownEvent>(evt =>
        {
            if (spendRunes())
            {
                MindNum.text = System.Convert.ToString(System.Convert.ToInt32(MindNum.text) + 1);
                MainLevel.text = System.Convert.ToString(System.Convert.ToInt32(MainLevel.text) + 1);
            }
        });
        EnduranceButton.RegisterCallback<MouseDownEvent>(evt =>
        {
            if (spendRunes())
            {
                EnduranceNum.text = System.Convert.ToString(System.Convert.ToInt32(EnduranceNum.text) + 1);
                MainLevel.text = System.Convert.ToString(System.Convert.ToInt32(MainLevel.text) + 1);
            }
        });
        StrengthButton.RegisterCallback<MouseDownEvent>(evt =>
        {
            if (spendRunes())
            {
                StrenghtNum.text = System.Convert.ToString(System.Convert.ToInt32(StrenghtNum.text) + 1);
                MainLevel.text = System.Convert.ToString(System.Convert.ToInt32(MainLevel.text) + 1);
            }
        });
        DexerityButton.RegisterCallback<MouseDownEvent>(evt =>
        {
            if (spendRunes())
            {
                DexerityNum.text = System.Convert.ToString(System.Convert.ToInt32(DexerityNum.text) + 1);
                MainLevel.text = System.Convert.ToString(System.Convert.ToInt32(MainLevel.text) + 1);
            }
        });
        IntelligenceButton.RegisterCallback<MouseDownEvent>(evt =>
        {
            if (spendRunes())
            {
                IntelligenceNum.text = System.Convert.ToString(System.Convert.ToInt32(IntelligenceNum.text) + 1);
                MainLevel.text = System.Convert.ToString(System.Convert.ToInt32(MainLevel.text) + 1);
            }
        });
        FaithButton.RegisterCallback<MouseDownEvent>(evt =>
        {
            if (spendRunes())
            {
                FaithNum.text = System.Convert.ToString(System.Convert.ToInt32(FaithNum.text) + 1);
                MainLevel.text = System.Convert.ToString(System.Convert.ToInt32(MainLevel.text) + 1);
            }
        });
        ArcaneButton.RegisterCallback<MouseDownEvent>(evt =>
        {
            if (spendRunes())
            {
                ArcaneNum.text = System.Convert.ToString(System.Convert.ToInt32(ArcaneNum.text) + 1);
                MainLevel.text = System.Convert.ToString(System.Convert.ToInt32(MainLevel.text) + 1);
            }
        });
    }
}
