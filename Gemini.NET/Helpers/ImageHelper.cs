﻿using GeminiDotNET.API_Models.Enums;
using GeminiDotNET.Client_Models;

namespace GeminiDotNET.Helpers
{
    /// <summary>
    /// Helper class for image operations
    /// </summary>
    public static class ImageHelper
    {
        private static readonly List<MimeType> _imageMimeTypes =
        [
            MimeType.ImagePng,
                MimeType.ImageJpeg,
                MimeType.ImageHeic,
                MimeType.ImageHeif,
                MimeType.ImageWebp,
        ];

        public static ImageData AsImageData(string base64Image)
        {
            MimeType? mimeType;
            if (base64Image.StartsWith("data:image", StringComparison.OrdinalIgnoreCase))
            {
                var imageFormat = base64Image[..base64Image.IndexOf(';')].Split('/')[^1];
                mimeType = _imageMimeTypes.FirstOrDefault(t => t.ToString().EndsWith(imageFormat, StringComparison.OrdinalIgnoreCase));
                if (mimeType == null)
                {
                    mimeType = MimeType.ImageJpeg;
                }
                if (base64Image.Contains(','))
                {
                    base64Image = base64Image.Split(',')[1];
                }
            }
            else
            {
                mimeType = MimeType.ImageJpeg;
                if (base64Image.Contains(','))
                {
                    base64Image = base64Image.Split(',')[1];
                }
            }

            return new ImageData
            {
                Base64Data = base64Image,
                MimeType = mimeType.Value
            };
        }
    }
}
