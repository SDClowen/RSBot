﻿using RSBot.Core.Client;
using System;
using System.Drawing;

namespace RSBot.Core.Extensions
{
    public static class Pk2Extensions
    {
        /// <summary>
        /// Gets the stream from a DDJ file in the Pk2 archive and converts the DDS Format to System.Image.
        /// </summary>
        /// <param name="file">The archive.</param>
        /// <returns></returns>
        public static Image ToImage(this Components.Pk2.ArchiveFile file)
        {
            var ddjBuffer = file.GetData();

            try
            {
                var ddsBuffer = new byte[ddjBuffer.Length - 20];
                Array.ConstrainedCopy(ddjBuffer, 20, ddsBuffer, 0, ddjBuffer.Length - 20); //Cuts the first 20 bytes.
                return DDSImage.ToBitmap(ddsBuffer);
            }
            catch
            {
                return new Bitmap(16, 16);
            }
        }
    }
}