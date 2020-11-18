﻿using System.Windows.Media.Imaging;
using System.Collections.ObjectModel;
using System.Windows.Media;
using System.IO;

namespace MemeMaker
{
    public enum ImageFormat
    {
        JPG, BMP, PNG, GIF, TIF
    }
    public class Model
    {
        private ObservableCollection<BitmapSource> imagecollection;
        public ObservableCollection<BitmapSource> ImageCollection
        {
            get
            {
                this.imagecollection = this.imagecollection ?? new ObservableCollection<BitmapSource>();
                return this.imagecollection;
            }
        }

        public RenderTargetBitmap RenderVisaulToBitmap(Visual vsual, int width, int height)
        {
            RenderTargetBitmap rtb = new RenderTargetBitmap(width, height, 96, 96, PixelFormats.Default);
            rtb.Render(vsual);
            BitmapSource bsource = rtb;
            this.ImageCollection.Add(bsource);
            return rtb;
        }

        public MemoryStream GenerateImage(Visual vsual, int widhth, int height, ImageFormat format)
        {
            BitmapEncoder encoder = null;
            switch (format)
            {
                case ImageFormat.JPG:
                    encoder = new JpegBitmapEncoder();
                    break;
                case ImageFormat.PNG:
                    encoder = new PngBitmapEncoder();
                    break;
                case ImageFormat.BMP:
                    encoder = new BmpBitmapEncoder();
                    break;
                case ImageFormat.GIF:
                    encoder = new GifBitmapEncoder();
                    break;
                case ImageFormat.TIF:
                    encoder = new TiffBitmapEncoder();
                    break;
            }
            if (encoder == null) return null;

            RenderTargetBitmap rtb = this.RenderVisaulToBitmap(vsual, widhth, height);
            MemoryStream file = new MemoryStream();
            encoder.Frames.Add(BitmapFrame.Create(rtb));
            encoder.Save(file);

            return file;
        }
    }
}
