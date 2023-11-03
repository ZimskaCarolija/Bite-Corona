using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NeprijateljHP : MonoBehaviour
{
    // Start is called before the first frame update
    public float MAxHp;//koliko max hp ima
    public float TenutniHP;//koliko trenutn hp ima
    public Image UIBar1;//slika 1 sa guscom bojom

    [Header("Vatra")]
    public bool Zapaljne = false;//dal ije zapaljen
    public float VatraBarMax;//do kle treba vatra bar da dodje da bi se zapalio nepriajtej
    public float TrenutniVatraBar;//koliki je trneutn bar za vatru
    public float VatraDMG;//koliko vatre prima dmg po sekundi
    public float VremeZapali;//koliko je durg zapaljen
    public float DoKarajZapali;//koliko je vremena ostalo dok ne prestane da gori


    [Header("Struja")]
    public bool PodStrujom= false;//dal ije pod strujom
    public float StrujaBarMax;//do koliko treba da se napuni bar d abi bi opod strujom nepriajtlej
    public float TrenuBarStruja;
    public float TrajanjeStruje;//koliko dugo traje efekat struje
    public float DoKrajaStruje;//koliko je vrmena ostalo dok s ene zaveis trajanje struje
    public float StrujaDMG;//koliko kad s enelektrise struja nanso i dmg

    [Header("Otrov")]
    public bool Otrova = false;//dal ije torovan
    public float OtrovBarMax;
    public float TrenutniBarOtrov;
    public float OtrovDMG;//koliko dmg nanosi otrov otrov traje beskonacno dugo nje kaovatra

    [Header("Efekti")]
    public List<GameObject> udovi = new List<GameObject>();
    public float minMagnitude = 1f; // Minimalna duzina vektora
    public float maxMagnitude = 5f;//ovo i iono pre ovoga je za ranodm generisanje vectora 
    public ParticleSystem KrvPart;
    public GameObject VatraEf;
    public GameObject OtrovEf;
    public GameObject StrujaEf;
    public float POmDoSekunde;//pomocna
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PrimeniEfekti();
    }
    public void PrimeniEfekti()// u ovoj funckije se desava sve vezano za primenu efekata
    {
        POmDoSekunde += Time.deltaTime;
        if (Zapaljne)
        {
            if (POmDoSekunde > 1)
            {
                UdariCistBroj(VatraDMG);
            }
            DoKarajZapali += Time.deltaTime;
            if (DoKarajZapali >= VremeZapali)
            {
                UgasiVatru();
            }
        }
        if (Otrova)
        {
            if (POmDoSekunde > 1)
            {
                UdariCistBroj(OtrovDMG);
            }
        }
        if (PodStrujom)
        {
            DoKrajaStruje += Time.deltaTime;
            if (DoKrajaStruje >= TrajanjeStruje)
            {
                krajStruje();
            }
        }
        if (POmDoSekunde > 1)
            POmDoSekunde = 0;
    }
    public void Udari(DMGPrenos prenos)
    {
        
        TenutniHP -= prenos.UzmiDMG();
        UpdajtujHPBar();
        KrvPart.Play();
        if (prenos.Vatra)
        {
            TrenutniVatraBar += prenos.UzmiDMG();
            if (TrenutniVatraBar >= VatraBarMax)
                Zapali();
        }
        if(prenos.Struja)
        {
            TrenuBarStruja += prenos.UzmiDMG();
            if (TrenuBarStruja >= StrujaBarMax)
                StrujaEfekat();
        }
        if(prenos.Otrov)
        {
            TrenutniBarOtrov += prenos.UzmiDMG();
            if (TrenutniBarOtrov >= OtrovBarMax)
                Otruj();
        }

        if (TenutniHP <= 0)
            Izgubi();
    }
    public void UdariCistBroj(float Broj)//ovde s e dondaj uefekti
    {
        TenutniHP -= Broj;
        UpdajtujHPBar();
        if (TenutniHP <= 0)
            Izgubi();
    }
    

 
    public void Zapali()//ova funkcija podesava oko vatre stvari
    {
        TrenutniVatraBar = 0;
        Zapaljne = true;
        DoKarajZapali = 0;
        VatraEf.SetActive(true);
    }
    public void UgasiVatru()
    {
        TrenutniVatraBar = 0;
        Zapaljne = false;
        DoKarajZapali = 0;
        VatraEf.SetActive(false) ;
    }
    public void krajStruje()
    {
        PodStrujom = false;
        DoKrajaStruje = 0;
        TrenuBarStruja = 0;
        StrujaEf.SetActive(false);
    }
    public void Otruj()//ova funkcija podesava oko otrova stvari
    {
        TrenutniBarOtrov = 0;
        Otrova = true;
        OtrovEf.SetActive(true);
    }
    public void StrujaEfekat()//ova funckija obavlja stavri oko davanja efekta struje
    {
        PodStrujom = true;
        DoKrajaStruje = 0;
        TrenuBarStruja = 0;
        StrujaEf.SetActive(true);
        UdariCistBroj(StrujaDMG);
    }
    public void Izgubi()//ova funkcija se desava kadatreutno hp dodje do 0
    {
        foreach(GameObject ud in udovi)
        {
            GameObject pom = Instantiate(ud);
            pom.transform.position = transform.position;
            float randomAngle = Random.Range(0f, 180f);
            Vector2 randomDirection = Quaternion.Euler(0, 0, randomAngle) * Vector2.right;

            // Generisite slucajnu duzinu vektora
            float randomMagnitude = Random.Range(minMagnitude, maxMagnitude);

            // Kreirajte vektor sa slucajnim smerom i duzinom
           Vector2 randomVector = new Vector2(randomDirection.x, randomDirection.y) * randomMagnitude;
            pom.GetComponent<Rigidbody2D>().velocity = randomVector;

        }
        Destroy(gameObject);
    }
    public void UpdajtujHPBar()
    {
        UIBar1.fillAmount = TenutniHP / MAxHp;
    }
}
