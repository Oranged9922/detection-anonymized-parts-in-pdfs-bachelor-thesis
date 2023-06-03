﻿using ImageMagick;
using OpenCvSharp;

namespace DAPPAnalyzer.Models
{
    /// <summary>
    /// Class representing a PDF file
    /// </summary>
    public class DappPDF
    {
        /// <summary>
        /// Gets or sets the pages of the PDF file
        /// </summary>
        public List<Mat> Pages { get; set; } = default!;

        /// <summary>
        /// Gets or sets a value indicating whether the PDF file has been analyzed
        /// </summary>
        public bool Analyzed { get; set; } = false;

        /// <summary>
        /// Creates a DappPDF object from a byte array
        /// </summary>
        /// <param name="data"> The byte array of the PDF file</param>
        /// <returns> A DappPDF object</returns>
        public static async Task<DappPDF> Create(byte[] data)
        {
            var pdf = new DappPDF();
            pdf.Pages = await Task.Run(() => pdf.ConvertToImages(data));
            return pdf;
        }

        /// <summary>
        /// Converts a PDF file to a list of images
        /// </summary>
        /// <param name="pdfPath"> The byte array of the PDF file</param>
        /// <returns> A list of images</returns>
        private List<Mat> ConvertToImages(byte[] pdfBytes)
        {
            var result = new List<Mat>();
            var tempFilePath = Path.GetTempFileName();

            try
            {
                // Save the PDF data to a temporary file
                File.WriteAllBytes(tempFilePath, pdfBytes);

                using (var images = new MagickImageCollection())
                {
                    // Read the temporary PDF file
                    images.Read(tempFilePath);

                    foreach (var image in images)
                    {
                        // Convert the MagickImage image to a byte array
                        byte[] bytes = image.ToByteArray(MagickFormat.Bmp);

                        // Create a Mat object using the byte array
                        Mat mat = Cv2.ImDecode(bytes, ImreadModes.Unchanged);
                        result.Add(mat);
                    }
                }
            }
            finally
            {
                // Clean up the temporary file
                File.Delete(tempFilePath);
            }

            return result;
        }
    }
}