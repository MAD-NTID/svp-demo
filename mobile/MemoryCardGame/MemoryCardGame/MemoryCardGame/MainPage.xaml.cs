using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Net.Http;
using System.Threading.Tasks;



namespace MemoryCardGame 
{
    public partial class MainPage : ContentPage
    {
        Image compareAgainst = null;
        const string LOGO_URL = "https://techcrunch.com/wp-content/uploads/2014/12/matrix.jpg?w=730&crop=1";
        ImageSource logo = ImageSource.FromUri(new Uri(LOGO_URL));

        public MainPage()
        {
            InitializeComponent();
            SetUpImages();
            

            
        }

        void SetUpImages()
        {
            //get the scrambled images urls from github
            List<string> scramblesImgs = GithubImagesUrls();

            

            for (int i = 0; i< 12; i++)
            {
                Random rand = new Random();
                int selectedScrambled = rand.Next(0,scramblesImgs.Count);

                Image image = new Image
                {
                    Source = ImageSource.FromUri(new Uri(LOGO_URL)),
                    WidthRequest = 125,
                    HeightRequest = 125,
                    Aspect = Aspect.AspectFit,
                    ClassId = scramblesImgs[selectedScrambled]
                };
                


                var tapGestureListener = new TapGestureRecognizer();
                tapGestureListener.Tapped += (s, e) =>
                {

                    ProcessMatch(s, e);
                };

                tapGestureListener.NumberOfTapsRequired = 1;
                image.GestureRecognizers.Add(tapGestureListener);
                flexlayout.Children.Add(image);

                scramblesImgs.RemoveAt(selectedScrambled);
            }
        }

        void ProcessMatch(object sender, EventArgs args)
        {

            Device.BeginInvokeOnMainThread(async () => {
                Image image = (Image)sender;
                //no image has been flipped
                image.Source = image.ClassId;
                await Task.Delay(800);

                //setup a tracking of the image we are now comparing
                if(compareAgainst == null)
                {
                    compareAgainst = image;
                } else
                {
                    //if the images are not matching, we simply flip it back
                    if (compareAgainst.ClassId != image.ClassId)
                    {
                        compareAgainst.Source = logo;
                        image.Source = logo;
                    } else if(compareAgainst.ClassId == image.ClassId)
                    {
                        image.GestureRecognizers.RemoveAt(0);
                        compareAgainst.GestureRecognizers.RemoveAt(0);

                    }

                    compareAgainst = null;
                }
                //if (matches.Count == 0)
                //{
                //    matches.Add(image);

                //}
                //else
                //{
                //    //if there is no match we simply flip it back over with the logo
                //    if (matches[0].ClassId != image.ClassId)
                //    {
                //        matches[0].Source = logo;
                //        image.Source = logo;
                //    }

                //    //if there is a match, we remove the ability to interact with the matching cards after they have been flipped over
                //    else if (matches[0].ClassId == image.ClassId)
                //    {
                //        image.GestureRecognizers.RemoveAt(0);
                //        matches[0].GestureRecognizers.RemoveAt(0);
                //    }

                //    //    //empty the matches tracker
                //    matches.RemoveAt(0);
                //}
            });




          


        }

       List<string> GithubImagesUrls()
       {
            List<string> urls = new List<string>()
            {
                "https://raw.githubusercontent.com/MAD-NTID/svp-demo/main/mobile/iot.jpg",
                "https://raw.githubusercontent.com/MAD-NTID/svp-demo/main/mobile/mobile.png",
                "https://raw.githubusercontent.com/MAD-NTID/svp-demo/main/mobile/network.webp",
                "https://raw.githubusercontent.com/MAD-NTID/svp-demo/main/mobile/pc.webp",
                "https://raw.githubusercontent.com/MAD-NTID/svp-demo/main/mobile/programming.jpg",
                "https://raw.githubusercontent.com/MAD-NTID/svp-demo/main/mobile/web.jpeg",
                "https://raw.githubusercontent.com/MAD-NTID/svp-demo/main/mobile/web.jpeg",
                "https://raw.githubusercontent.com/MAD-NTID/svp-demo/main/mobile/programming.jpg",
                "https://raw.githubusercontent.com/MAD-NTID/svp-demo/main/mobile/pc.webp",
                "https://raw.githubusercontent.com/MAD-NTID/svp-demo/main/mobile/network.webp",
                "https://raw.githubusercontent.com/MAD-NTID/svp-demo/main/mobile/mobile.png",
                "https://raw.githubusercontent.com/MAD-NTID/svp-demo/main/mobile/iot.jpg"
            };


            return urls;
        }
    }
}
