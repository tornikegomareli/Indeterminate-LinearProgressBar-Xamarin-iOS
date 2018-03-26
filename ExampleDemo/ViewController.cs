using System;
using MPDCLinearProgressBarIOS;
using UIKit;

namespace ExampleDemo
{
    public partial class ViewController : UIViewController
    {



        LinearProgressBar linearBar;
        
        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();




            linearBar = new LinearProgressBar(new CoreGraphics.CGRect(50,50,100,100));

            this.ConfigureLinearProgressBar();

            startButton.TouchUpInside += (sender, e) =>
            {
                StartAnimation();
            };

            stopButton.TouchUpInside += (sender, e) =>
            {
                StopAnimation();
            };
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        private void StartAnimation()
        {
            this.linearBar.StartAnimation();
        }

        private void StopAnimation()
        {
            this.linearBar.StopAnimation();
        }

        public void ConfigureLinearProgressBar()
        {
            linearBar.BackgroundColor = UIColor.Black;
            linearBar.BackGroundProgressBarColor = UIColor.Gray;
            linearBar.ProgressBarColor = UIColor.Green;
            linearBar.HeightForLinearBar = 5;
            this.View.AddSubview(linearBar);
        }
    }
}
