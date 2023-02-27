using UnityEngine;
using UnityEngine.UI;
using System.Net;
using Newtonsoft.Json;

using TMPro;

public class recup : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI input;
    [SerializeField] TextMeshProUGUI ville;
    string _url;



    void Start()
    {

        using (WebClient webClient = new WebClient())
        {
            string publicIp = webClient.DownloadString("https://api.ipify.org");
            Debug.Log(publicIp);

            string publicGeo = webClient.DownloadString("http://www.geoplugin.net/json.gp?ip=" + publicIp);
            Debug.Log(publicGeo);

            input.text = publicIp;
            Rootobject response = JsonConvert.DeserializeObject<Rootobject>(publicGeo);
            ville.text = response.geoplugin_city;
        }
    }









    public class Rootobject
    {
        public string geoplugin_request { get; set; }
        public int geoplugin_status { get; set; }
        public string geoplugin_delay { get; set; }
        public string geoplugin_credit { get; set; }
        public string geoplugin_city { get; set; }
        public string geoplugin_region { get; set; }
        public string geoplugin_regionCode { get; set; }
        public string geoplugin_regionName { get; set; }
        public string geoplugin_areaCode { get; set; }
        public string geoplugin_dmaCode { get; set; }
        public string geoplugin_countryCode { get; set; }
        public string geoplugin_countryName { get; set; }
        public int geoplugin_inEU { get; set; }
        public int geoplugin_euVATrate { get; set; }
        public string geoplugin_continentCode { get; set; }
        public string geoplugin_continentName { get; set; }
        public string geoplugin_latitude { get; set; }
        public string geoplugin_longitude { get; set; }
        public string geoplugin_locationAccuracyRadius { get; set; }
        public string geoplugin_timezone { get; set; }
        public string geoplugin_currencyCode { get; set; }
        public string geoplugin_currencySymbol { get; set; }
        public string geoplugin_currencySymbol_UTF8 { get; set; }
        public float geoplugin_currencyConverter { get; set; }
    }

}
