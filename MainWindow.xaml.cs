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

            var bit = JsonConvert.DeserializeObject<BitcoinPrice>(content);

            ResultTBlock.Text = GetFieldsInfo(bit);
            
        }

        private List<Type> GetInnerClasses()
        {
            Type myClassType = typeof(BitcoinPrice);

            return myClassType
                .GetNestedTypes(BindingFlags.Public | BindingFlags.NonPublic)
                .Where(t => t.IsClass)
                .ToList();
        }

        public string GetFieldsInfo(BitcoinPrice obj)
        {
            var innerClasses = GetInnerClasses();

            obj.

            string result = $"Class: {obj.GetType().Name}\n";
                
            foreach (var innerClass in innerClasses)
            {
                result += $"{innerClass.Name}: {GetValue(obj)}\n";
            }
            return result;
        }
    }
}
