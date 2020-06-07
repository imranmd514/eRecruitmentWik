using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace Utils
{
    public class CommonUtils
    {
        public static string SendEmail(string strFromEmailId, string strToEmailId, string strSubject, string strBody)
        {
            string strResult = "";
            try
            {
                MailMessage message = new MailMessage();
                message.From = new MailAddress(strFromEmailId);
                message.To.Add(new MailAddress(strToEmailId));
                message.IsBodyHtml = true; //to make message body as html  
                message.Subject = strSubject;
                message.Body = strBody;
                SmtpClient smtp = new SmtpClient();
                smtp.Send(message);
                strResult = "SUCCESS";
            }
            catch (Exception ex)
            {
                strResult = "Failed";
            }

            return strResult;

        }

        public static string SendEmail(string strFromEmailId, List<string> strToEmailId, string strSubject, string strBody)
        {
            string strResult = "";
            try
            {
                MailMessage message = new MailMessage();
                message.From = new MailAddress(strFromEmailId);
                for (int i = 0; i < strToEmailId.Count; i++)
                {
                    message.To.Add(new MailAddress(strToEmailId[i]));
                }

                message.IsBodyHtml = true; //to make message body as html  
                message.Subject = strSubject;
                message.Body = strBody;
                SmtpClient smtp = new SmtpClient();
                smtp.Send(message);
                strResult = "SUCCESS";
            }
            catch (Exception ex)
            {
                strResult = "Failed";
            }

            return strResult;

        }

        private enum ImageFileExtension
        {
            none = 0,
            jpg = 1,
            jpeg = 2,
            bmp = 3,
            gif = 4,
            png = 5
        }

        public enum UsingFileExtension
        {
            none = 0,
            DOC = 1,
            DOCX = 2,
            PPT = 3,
            PPTX = 4,
            XLS = 5,
            XLSX = 6,
            PDF = 7
        }

        public enum FileType
        {
            Image = 1,
            Video = 2,
            PDF = 3,
            Text = 4,
            DOC = 5,
            DOCX = 6,
            PPT = 7,
            PPTX = 8,
            XLS = 9,
            XLSX = 10
        }
        public static bool isValidFile(byte[] bytFile, FileType flType, String FileContentType)
        {
            bool isvalid = false;
            if (flType == FileType.Image)
            {
                isvalid = isValidImageFile(bytFile, FileContentType);//we are going call this method
            }
            else if (flType == FileType.XLS)
            {
                isvalid = isValidXLSFile(bytFile, FileContentType);
            }
            else if (flType == FileType.XLSX)
            {
                isvalid = isValidXLSXFile(bytFile, FileContentType);
            }
            else if (flType == FileType.DOC)
            {
                isvalid = isValidDOCFile(bytFile, FileContentType);
            }
            else if (flType == FileType.DOCX)
            {
                isvalid = isValidDOCXFile(bytFile, FileContentType);
            }
            else if (flType == FileType.PDF)
            {
                isvalid = isValidPDFFile(bytFile, FileContentType);
            }
            else if (flType == FileType.PPT)
            {
                isvalid = isValidPPTFile(bytFile, FileContentType);
            }
            else if (flType == FileType.PPTX)
            {
                isvalid = isValidPPTXFile(bytFile, FileContentType);
            }
            return isvalid;
        }
        public static bool isValidDOCFile(byte[] bytFile, String FileContentType)
        {
            bool isvalid = false;
            UsingFileExtension imgfileExtn = UsingFileExtension.none;

            byte[] chkByteDOC = { 208, 207, 17, 224, 161, 177, 26, 225 };

            if (FileContentType.Contains("application/msword"))
            {
                imgfileExtn = UsingFileExtension.DOC;
            }

            if (imgfileExtn == UsingFileExtension.DOC)
            {
                if (bytFile.Length >= 4)
                {
                    int j = 0;
                    for (Int32 i = 0; i <= 3; i++)
                    {
                        if (bytFile[i] == chkByteDOC[i])
                        {
                            j = j + 1;
                            if (j == 3)
                            {
                                isvalid = true;
                            }
                        }
                    }
                }
            }
            return isvalid;
        }
        public static bool isValidDOCXFile(byte[] bytFile, String FileContentType)
        {
            bool isvalid = false;
            UsingFileExtension imgfileExtn = UsingFileExtension.none;

            byte[] chkByteDOCX = { 80, 75, 3, 4 };

            if (FileContentType.Contains("application/vnd.openxmlformats-officedocument.wordprocessingml.document"))
            {
                imgfileExtn = UsingFileExtension.DOCX;
            }

            if (imgfileExtn == UsingFileExtension.DOCX)
            {
                if (bytFile.Length >= 4)
                {
                    int j = 0;
                    for (Int32 i = 0; i <= 3; i++)
                    {
                        if (bytFile[i] == chkByteDOCX[i])
                        {
                            j = j + 1;
                            if (j == 3)
                            {
                                isvalid = true;
                            }
                        }
                    }
                }
            }
            return isvalid;
        }
        public static bool isValidXLSFile(byte[] bytFile, String FileContentType)
        {
            bool isvalid = false;
            UsingFileExtension imgfileExtn = UsingFileExtension.none;

            byte[] chkByteXLS = { 208, 207, 17, 224, 161, 177, 26, 225 };

            if (FileContentType.Contains("application/vnd.ms-excel"))
            {
                imgfileExtn = UsingFileExtension.XLS;
            }

            if (imgfileExtn == UsingFileExtension.XLS)
            {
                if (bytFile.Length >= 4)
                {
                    int j = 0;
                    for (Int32 i = 0; i <= 3; i++)
                    {
                        if (bytFile[i] == chkByteXLS[i])
                        {
                            j = j + 1;
                            if (j == 3)
                            {
                                isvalid = true;
                            }
                        }
                    }
                }
            }
            return isvalid;
        }
        public static bool isValidXLSXFile(byte[] bytFile, String FileContentType)
        {
            bool isvalid = false;
            UsingFileExtension imgfileExtn = UsingFileExtension.none;

            byte[] chkByteXLSX = { 80, 75, 3, 4 };

            if (FileContentType.Contains("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"))
            {
                imgfileExtn = UsingFileExtension.XLSX;
            }

            if (imgfileExtn == UsingFileExtension.XLSX)
            {
                if (bytFile.Length >= 4)
                {
                    int j = 0;
                    for (Int32 i = 0; i <= 3; i++)
                    {
                        if (bytFile[i] == chkByteXLSX[i])
                        {
                            j = j + 1;
                            if (j == 3)
                            {
                                isvalid = true;
                            }
                        }
                    }
                }
            }
            return isvalid;
        }
        public static bool isValidPDFFile(byte[] bytFile, String FileContentType)
        {
            bool isvalid = false;
            UsingFileExtension imgfileExtn = UsingFileExtension.none;

            byte[] chkBytePDF = { 37, 80, 68, 70, 45, 49, 46 };

            if (FileContentType.Contains("application/pdf"))
            {
                imgfileExtn = UsingFileExtension.PDF;
            }

            if (imgfileExtn == UsingFileExtension.PDF)
            {
                if (bytFile.Length >= 4)
                {
                    int j = 0;
                    for (Int32 i = 0; i <= 3; i++)
                    {
                        if (bytFile[i] == chkBytePDF[i])
                        {
                            j = j + 1;
                            if (j == 3)
                            {
                                isvalid = true;
                            }
                        }
                    }
                }
            }
            return isvalid;
        }
        public static bool isValidPPTFile(byte[] bytFile, String FileContentType)
        {
            bool isvalid = false;
            UsingFileExtension imgfileExtn = UsingFileExtension.none;

            byte[] chkBytePPT = { 208, 207, 17, 224, 161, 177, 26, 225 };

            if (FileContentType.Contains("application/vnd.ms-powerpoint"))
            {
                imgfileExtn = UsingFileExtension.PPT;
            }

            if (imgfileExtn == UsingFileExtension.PPT)
            {
                if (bytFile.Length >= 4)
                {
                    int j = 0;
                    for (Int32 i = 0; i <= 3; i++)
                    {
                        if (bytFile[i] == chkBytePPT[i])
                        {
                            j = j + 1;
                            if (j == 3)
                            {
                                isvalid = true;
                            }
                        }
                    }
                }
            }
            return isvalid;
        }
        public static bool isValidPPTXFile(byte[] bytFile, String FileContentType)
        {
            bool isvalid = false;
            UsingFileExtension imgfileExtn = UsingFileExtension.none;

            byte[] chkBytePPTX = { 80, 75, 3, 4 };

            if (FileContentType.Contains("application/vnd.openxmlformats-officedocument.presentationml.presentation"))
            {
                imgfileExtn = UsingFileExtension.PPTX;
            }

            if (imgfileExtn == UsingFileExtension.PPTX)
            {
                if (bytFile.Length >= 4)
                {
                    int j = 0;
                    for (Int32 i = 0; i <= 3; i++)
                    {
                        if (bytFile[i] == chkBytePPTX[i])
                        {
                            j = j + 1;
                            if (j == 3)
                            {
                                isvalid = true;
                            }
                        }
                    }
                }
            }
            return isvalid;
        }
        public static bool isValidImageFile(byte[] bytFile, String FileContentType)
        {
            bool isvalid = false;

            byte[] chkBytejpg = { 255, 216, 255, 224 };
            byte[] chkBytebmp = { 66, 77 };
            byte[] chkBytegif = { 71, 73, 70, 56 };
            byte[] chkBytepng = { 137, 80, 78, 71 };


            ImageFileExtension imgfileExtn = ImageFileExtension.none;

            if (FileContentType.Contains("jpg") | FileContentType.Contains("jpeg"))
            {
                imgfileExtn = ImageFileExtension.jpg;
            }
            else if (FileContentType.Contains("png"))
            {
                imgfileExtn = ImageFileExtension.png;
            }
            else if (FileContentType.Contains("bmp"))
            {
                imgfileExtn = ImageFileExtension.bmp;
            }
            else if (FileContentType.Contains("gif"))
            {
                imgfileExtn = ImageFileExtension.gif;
            }

            if (imgfileExtn == ImageFileExtension.jpg || imgfileExtn == ImageFileExtension.jpeg)
            {
                if (bytFile.Length >= 4)
                {
                    int j = 0;
                    for (Int32 i = 0; i <= 3; i++)
                    {
                        if (bytFile[i] == chkBytejpg[i])
                        {
                            j = j + 1;
                            if (j == 3)
                            {
                                isvalid = true;
                            }
                        }
                    }
                }
            }


            if (imgfileExtn == ImageFileExtension.png)
            {
                if (bytFile.Length >= 4)
                {
                    int j = 0;
                    for (Int32 i = 0; i <= 3; i++)
                    {
                        if (bytFile[i] == chkBytepng[i])
                        {
                            j = j + 1;
                            if (j == 3)
                            {
                                isvalid = true;
                            }
                        }
                    }
                }
            }


            if (imgfileExtn == ImageFileExtension.bmp)
            {
                if (bytFile.Length >= 4)
                {
                    int j = 0;
                    for (Int32 i = 0; i <= 1; i++)
                    {
                        if (bytFile[i] == chkBytebmp[i])
                        {
                            j = j + 1;
                            if (j == 2)
                            {
                                isvalid = true;
                            }
                        }
                    }
                }
            }

            if (imgfileExtn == ImageFileExtension.gif)
            {
                if (bytFile.Length >= 4)
                {
                    int j = 0;
                    for (Int32 i = 0; i <= 1; i++)
                    {
                        if (bytFile[i] == chkBytegif[i])
                        {
                            j = j + 1;
                            if (j == 3)
                            {
                                isvalid = true;
                            }
                        }
                    }
                }
            }

            return isvalid;
        }
    }
}
