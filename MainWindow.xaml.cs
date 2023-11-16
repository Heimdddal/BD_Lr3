using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Reflection;
using static BD_Lr3.Rootobject;
using System.Security.Policy;
using System.Xml.XPath;

namespace BD_Lr3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static readonly HttpClient client = new HttpClient();
        public MainWindow()
        {
            InitializeComponent();

            SetContent();
        }

        public async void SetContent()
        {
            var response = await client.GetAsync(@"https://api.coindesk.com/v1/bpi/currentprice.json");

            string content = await response.Content.ReadAsStringAsync();

            var bit = JsonConvert.DeserializeObject<Rootobject>(content);

            ResultTBlock.Text = GetFieldsInfo(bit);
            
        }

        public string GetFieldsInfo(Rootobject obj)
        {
            string result = $"Bitcoin Price\n";

            result += obj.CombineInfo();

            return result;
        }
    }

    public class Time
    {
        public string updated { get; set; }
        public DateTime updatedISO { get; set; }
        public string updateduk { get; set; }

        public string GetInfo()
        {
            string result = $"{this.GetType().Name}\n";
            result += $"updated: {this.updated}\nupdated ISO: {this.updatedISO}\nupdated uk: {this.updateduk}\n";
            return result;
        }
    }

    public class Bpi
    {
        public USD USD { get; set; }
        public GBP GBP { get; set; }
        public EUR EUR { get; set; }
    }

    public class USD
    {
        public string code { get; set; }
        public string symbol { get; set; }
        public string rate { get; set; }
        public string description { get; set; }
        public float rate_float { get; set; }

        public string GetInfo()
        {
            string result = $"{this.GetType().Name}\n";
            result += $"code: {this.code}\nsymbol: {this.symbol}\nrate: {this.rate}\ndescription: {this.description}\n rate float: {this.rate_float}\n";
            return result;
        }
    }

    public class GBP
    {
        public string code { get; set; }
        public string symbol { get; set; }
        public string rate { get; set; }
        public string description { get; set; }
        public float rate_float { get; set; }

        public string GetInfo()
        {
            string result = $"{this.GetType().Name}\n";
            result += $"code: {this.code}\nsymbol: {this.symbol}\nrate: {this.rate}\ndescription: {this.description}\n rate float: {this.rate_float}\n";
            return result;
        }
    }

    public class EUR
    {
        public string code { get; set; }
        public string symbol { get; set; }
        public string rate { get; set; }
        public string description { get; set; }
        public float rate_float { get; set; }

        public string GetInfo()
        {
            string result = $"{this.GetType().Name}\n";
            result += $"code: {this.code}\nsymbol: {this.symbol}\nrate: {this.rate}\ndescription: {this.description}\n rate float: {this.rate_float}\n";
            return result;
        }
    }

    public class Rootobject
    {
        public Time time { get; set; }
        public string disclaimer { get; set; }
        public string chartName { get; set; }
        public Bpi bpi { get; set; }

        public string CombineInfo()
        {
            string result = this.time.GetInfo() + disclaimer + '\n' + chartName + '\n' + this.bpi.USD.GetInfo() + this.bpi.EUR.GetInfo() + this.bpi.GBP.GetInfo();
            return result;
        }
    }
}
