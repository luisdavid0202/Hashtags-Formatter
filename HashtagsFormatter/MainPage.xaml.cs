using System;
using System.Linq;
using System.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace HashtagsFormatter
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var unformattedHashtags = this.hashtagsInput.Text.Trim().Split(new[] { "\r\n", "\r", "\n", " " }, StringSplitOptions.None).ToList();

            if (unformattedHashtags.Count > 30)
            {
                this.consoleOutput.Text = $"- {unformattedHashtags.Count} hashtags found. {Environment.NewLine}";
                this.consoleOutput.Text = $"{this.consoleOutput.Text}- Only 30 hashtags will be shown in the output. {Environment.NewLine}";
            }

            var rnd = new Random();
            var randomizedList = unformattedHashtags.OrderBy(x => rnd.Next()).Distinct().ToList();

            var sb = new StringBuilder();
            int count = 0;
            foreach (string h in randomizedList)
            {
                count++;
                sb.Append($"#{h} ");

                if (count == 30)
                {
                    break;
                }
            }

            this.consoleOutput.Text = $"{this.consoleOutput.Text}- Done. {randomizedList.Count} hashtags found. {Environment.NewLine}";

            this.hashtagsOutput.Text = sb.ToString().Trim();            
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            this.hashtagsInput.Text = string.Empty;
            this.hashtagsOutput.Text = string.Empty;
        }
    }
}
