﻿using System;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.Foundation;

namespace AppStudio.Uwp.Controls
{
    public partial class ImageEx : ContentControl
    {
        public ImageEx()
        {
            this.DefaultStyleKey = typeof(ImageEx);
            this.HorizontalContentAlignment = HorizontalAlignment.Center;
            this.VerticalContentAlignment = VerticalAlignment.Center;
        }

        private Size _currentSize = new Size(BitmapCache.MIDRESOLUTION, BitmapCache.MIDRESOLUTION);

        protected override Size MeasureOverride(Size availableSize)
        {
            var progress = this.Progress;
            if (progress != null)
            {
                if (!Double.IsInfinity(availableSize.Width))
                {
                    progress.Width = Math.Max(8, availableSize.Width * 0.5);
                }
                if (!Double.IsInfinity(availableSize.Height))
                {
                    progress.Height = Math.Max(8, availableSize.Height * 0.5);
                }
            }

            var newSize = new Size(Math.Min(Int16.MaxValue, availableSize.Width), Math.Min(Int16.MaxValue, availableSize.Height));
            if (_isHttpSource && BitmapCache.GetSizeLevel(_currentSize) != BitmapCache.GetSizeLevel(newSize))
            {
                _currentSize = newSize;
                RefreshSourceUri(_currentUri);
            }
            return base.MeasureOverride(availableSize);
        }
    }
}
