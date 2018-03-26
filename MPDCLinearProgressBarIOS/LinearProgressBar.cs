using System;
using UIKit;
using CoreGraphics;
using Foundation;

namespace MPDCLinearProgressBarIOS
{
    public class LinearProgressBar : UIView
    {
        private UIColor _backgroundProgressBarColor = UIColor.Green;
        private UIColor _progressBarColor =  UIColor.Green;
        private nfloat _heightforLienarBar = 5;
        private nfloat _widthForLinearBar = 0;


        
        // for data
        private static CGRect _screenSize = UIScreen.MainScreen.Bounds;

        private bool _isAnimationRunning = false;


        private UIView _progressBarIndicator;

        public UIColor BackGroundProgressBarColor
        {
            get => _backgroundProgressBarColor;
            set => _backgroundProgressBarColor = value;
        }

        public UIColor ProgressBarColor
        {
            get => _progressBarColor;
            set => _progressBarColor = value;
        }

        public nfloat HeightForLinearBar 
        {
            get => _heightforLienarBar;
            set => _heightforLienarBar = value;
        }

        public nfloat WidthForLinearBar
        {
            get => _widthForLinearBar;
            set => _widthForLinearBar = value;
        }

        public LinearProgressBar() : base(new CGRect(0, 20, _screenSize.Width, 0))
        {
            this._progressBarIndicator = new UIView(new CGRect(0, 0, 0, HeightForLinearBar));

        }

        public LinearProgressBar(CGRect frame) : base(frame)
        {
            this._progressBarIndicator = new UIView(new CGRect(0, 0, 0, HeightForLinearBar));
        }

        public LinearProgressBar(NSCoder nScoder)
        {
            throw new Exception("constructor(coder) has not implemented");
        }


		// Creating View

		public override void LayoutSubviews()
		{
            base.LayoutSubviews();

            _screenSize = UIScreen.MainScreen.Bounds;

            if(WidthForLinearBar == 0 || WidthForLinearBar == _screenSize.Height) {
                WidthForLinearBar = _screenSize.Width;
            }

            if(UIDeviceOrientationExtensions.IsLandscape(UIDevice.CurrentDevice.Orientation)){
                this.Frame = new CGRect(this.Frame.X, this.Frame.Y, WidthForLinearBar, this.Frame.Height);
            }

            if(UIDeviceOrientationExtensions.IsPortrait(UIDevice.CurrentDevice.Orientation)){
                this.Frame = new CGRect(this.Frame.X, this.Frame.Y, WidthForLinearBar, this.Frame.Height);
            }
		}

        public void StartAnimation()
        {
            this.ConfigureColors();

            if(!_isAnimationRunning){
                this._isAnimationRunning = true;
                UIView.Animate(0.5, 0, UIViewAnimationOptions.TransitionFlipFromLeft, () =>
                {
                    this.Frame = new CGRect(0, this.Frame.Y, WidthForLinearBar, HeightForLinearBar);
                }, () =>
                {
                    this.AddSubview(_progressBarIndicator);
                    this.ConfigureAnimation();
                });
            }    
        }

        public void StopAnimation()
        {
            this._isAnimationRunning = false;

            UIView.Animate(0.5,() => {
                this._progressBarIndicator.Frame = new CGRect(0, 0, WidthForLinearBar, 0);
                this.Frame = new CGRect(0, this.Frame.Y, WidthForLinearBar, 0);
            });
        }

        private void ConfigureColors()
        {
            this.BackgroundColor = this.BackgroundColor;
            this._progressBarIndicator.BackgroundColor = this._progressBarColor;
        }

        private void ConfigureAnimation()
        {
            this._progressBarIndicator.Frame = new CGRect(0, 0, 0, HeightForLinearBar);


            UIView.Animate(0.5, 0, UIViewAnimationOptions.TransitionFlipFromLeft, () =>
            {
                this._progressBarIndicator.Frame = new CGRect(0, 0, this.WidthForLinearBar * 0.7, HeightForLinearBar);
            },null);

            UIView.Animate(0.4, 0.4, UIViewAnimationOptions.TransitionFlipFromLeft, () =>
            {
                this._progressBarIndicator.Frame = new CGRect(this.Frame.Width, 0, 0, HeightForLinearBar);
            }, () =>
            {
                if (_isAnimationRunning)
                    ConfigureAnimation();
            });
        }
	}
}
