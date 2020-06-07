using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Westwind.Utilities;

namespace eRecruitment.Security
{
    public class ErrorDisplay
    {
        private List<string> DisplayErrors = null;

        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }
        private string _message = null;


        /// <summary>
        /// Determines whether there is a message present.
        /// </summary>
        public bool HasMessage
        {
            get
            {
                if (DisplayErrors.Count > 0 && string.IsNullOrEmpty(Message))
                    Message = "Please correct the following errors:";

                return !string.IsNullOrEmpty(Message);
            }
        }

        /// <summary>
        /// Flag that determines whether the message is displayed
        /// as HTML or as text. By default message is encoded as text (true).
        /// </summary>
        public bool HtmlEncodeMessage
        {
            get { return _HtmlEncodeMessage; }
            set { _HtmlEncodeMessage = value; }
        }
        private bool _HtmlEncodeMessage = true;



        public void SetError(string strError = null, string fieldPrefix = null)
        {

            if (strError != null)
            {
                if (DisplayErrors == null)
                {
                    DisplayErrors = new List<string>();
                }

                DisplayErrors.Add(fieldPrefix + " " + strError);
            }
        }

        /// <summary>
        /// Timeout in milliseconds before the error display is hidden
        /// </summary>
        public int Timeout { get; set; }



        StringBuilder writer = new StringBuilder();
        bool visible = false;

        public ErrorDisplayTypes ErrorDisplayType = ErrorDisplayTypes.Error;

        protected void RenderTop(int width, bool center)
        {
            writer.Length = 0;

            writer.Append("<div class=\"errordisplay\" ");

            if (width != 0)
                writer.Append("style=\"width: " + width.ToString() + "px;");
            if (center)
                writer.Append("margin-left: auto; margin-right: auto");
            writer.Append("\"");

            writer.Append(" />\r\n");
        }

        protected void RenderBottom()
        {
            // close out the dialog
            writer.AppendLine("</div>");
        }

        protected void RenderDisplayErrors()
        {
            if (DisplayErrors.Count > 0)
            {
                writer.AppendLine("<hr/>");
                RenderTop(500, true);
                for (int i = 0; i < DisplayErrors.Count; i++)
                {
                    writer.AppendLine(DisplayErrors[i]);
                    writer.AppendLine("</br>");
                }
                RenderBottom();

            }
        }

        public HtmlString Show(int width = 400, bool center = true)
        {
            return Render(width, center);
        }

        /// <summary>
        /// Method 
        /// </summary>
        /// <param name="width"></param>
        /// <param name="center"></param>
        /// <returns></returns>
        public HtmlString Render(int width = 400, bool center = true)
        {
            if (!visible || !HasMessage)
                return new HtmlString(string.Empty);

            RenderTop(width, center);

            if (ErrorDisplayType == ErrorDisplayTypes.Error)
                writer.AppendLine(" <div class=\"errordisplay-warning-icon\"></div>");
            else
                writer.AppendLine(" <div class=\"errordisplay-info-icon\"></div>");

            writer.AppendLine("<div class=\"errordisplay-text\">");

            writer.AppendLine(HtmlEncodeMessage ? HttpUtility.HtmlEncode(Message) : Message);
            RenderDisplayErrors();

            writer.AppendLine("</div>");

            RenderBottom();

            return new HtmlString(writer.ToString());
        }


        public void ShowError(string errorMessage)
        {
            ErrorDisplayType = ErrorDisplayTypes.Error;
            Message = errorMessage;
            visible = true;
        }


        public void ShowMessage(string message)
        {
            ErrorDisplayType = ErrorDisplayTypes.Message;
            Message = message;
            visible = true;
        }

        /// <summary>
        /// Adds ModelState errors to the validationErrors
        /// </summary>
        /// <param name="modelErrors"></param>
        public void AddMessages(ModelStateDictionary modelErrors, string fieldPrefix = null)
        {
            fieldPrefix = fieldPrefix ?? string.Empty;

            foreach (var state in modelErrors)
            {
                if ((state.Value.Errors.Count > 0))
                {
                    SetError(state.Value.Errors[0].ErrorMessage, fieldPrefix + state.Key);
                }

            }
            visible = true;
        }

        ///// <summary>
        ///// Adds an existing set of Validation Errors to the DisplayErrors
        ///// </summary>
        ///// <param name="validationErrors"></param>
        public void AddMessages(ValidationErrorCollection validationErrors, string fieldPrefix = null)
        {
            fieldPrefix = fieldPrefix ?? string.Empty;

            foreach (ValidationError error in validationErrors)
            {
                SetError(error.Message, fieldPrefix + error.ControlID);
            }
            visible = true;
        }

        /// <summary>
        /// Adds an individual model error
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <param name="control"></param>
        public void AddMessage(string errorMessage, string control = null)
        {
            SetError(errorMessage, control);
            visible = true;
        }
    }

    public enum ErrorDisplayTypes
    {
        Error,
        Message,
    }
}
