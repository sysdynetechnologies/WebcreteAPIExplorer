using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WebcreteAPIExplorer.com.concretego.api;
using System.Security.Cryptography;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace WebcreteAPIExplorer
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void buttonProcess_Click(object sender, EventArgs e)
        {
            try
            {
                textBoxResponse.Text = "";
                WebcreteAPI api = new WebcreteAPI();
                if (textBoxURL.Text.Length > 0)
                    api.Url = textBoxURL.Text;  // each concretego customer uses its own api endpoint in the format of {account}.api.concretego.com/webcreteapi.asmx

                api.Timeout = -1;

                string publicKey = api.GetPublicKey("Test", "F52D2965BF8318F"); // please contact us to get the appId and apiKey for your application
               
                if (publicKey == null)
                {
                    MessageBox.Show("Can not get public key.");
                    return;
                }
                RSACryptoServiceProvider key = new RSACryptoServiceProvider();
                key.FromXmlString(publicKey);
                UnicodeEncoding enc = new UnicodeEncoding();

                byte[] encryptedPassword;

                encryptedPassword = key.Encrypt(enc.GetBytes(textBoxPassword.Text), false);

                if (api.Login(textBoxUserName.Text, encryptedPassword) == false)
                {
                    MessageBox.Show("Login failed.");
                    return;
                }
                string response = api.ProcessRequest(textBoxRequest.Text);
                if (response != null)
                {
                    textBoxResponse.Text = IndentXMLString(response);
                }
                else
                {
                    MessageBox.Show("Request failed.");
                    return;
                }
                api.Logout();
            }
            catch (SystemException ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
     
        public string GetVersionQueryRequest()
        {
            XDocument x = new System.Xml.Linq.XDocument(
               new XDeclaration("1.0", "utf-8", "yes"),
               new XProcessingInstruction("webcretexml", "version=\"1.0\""),
               new XElement("WebcreteXML",
                   new XElement("WebcreteXMLMsgsRq", 
                       new XElement("VersionQueryRq", ""))));

            return x.ToString();
        }

        public string GetCompanyQueryRequest()
        { 
            XDocument x = new System.Xml.Linq.XDocument(
               new XDeclaration("1.0", "utf-8", "yes"),
               new XProcessingInstruction("webcretexml", "version=\"1.0\""),
               new XElement("WebcreteXML",
                   new XElement("WebcreteXMLMsgsRq", 
                       new XElement("CompanyQueryRq", ""))));

            return x.ToString();
        }

        public string GetCustomerQueryRequest()
        {
            XDocument x = new System.Xml.Linq.XDocument(
               new XDeclaration("1.0", "utf-8", "yes"),
               new XProcessingInstruction("webcretexml", "version=\"1.0\""),
               new XElement("WebcreteXML",
                   new XElement("WebcreteXMLMsgsRq", 
                       new XElement("CustomerQueryRq", ""))));

            return x.ToString();
        }

        public string GetProjectQueryRequest()
        {
            XDocument x = new System.Xml.Linq.XDocument(
               new XDeclaration("1.0", "utf-8", "yes"),
               new XProcessingInstruction("webcretexml", "version=\"1.0\""),
               new XElement("WebcreteXML",
                   new XElement("WebcreteXMLMsgsRq", 
                       new XElement("ProjectQueryRq", ""))));

            return x.ToString();
        }

        public string GetItemQueryRequest()
        {
            XDocument x = new System.Xml.Linq.XDocument(
              new XDeclaration("1.0", "utf-8", "yes"),
              new XProcessingInstruction("webcretexml", "version=\"1.0\""),
              new XElement("WebcreteXML",
                  new XElement("WebcreteXMLMsgsRq", 
                      new XElement("ItemQueryRq", ""))));

            return x.ToString();
        }

        public string GetTicketQueryRequest(DateTime dtOrderFrom, DateTime dtOrderTo)
        {
           XDocument x = new System.Xml.Linq.XDocument(
             new XDeclaration("1.0", "utf-8", "yes"),
             new XProcessingInstruction("webcretexml", "version=\"1.0\""),
             new XElement("WebcreteXML",
                 new XElement("WebcreteXMLMsgsRq",
                     new XElement("TicketQueryRq", 
                         new XElement("FromOrderDate",dtOrderFrom.ToShortDateString()),
                         new XElement("ToOrderDate",dtOrderTo.ToShortDateString())))));

           return x.ToString();
        }

        public string GetCustomerUpdateRequest(string code, string name, string sort)
        {          
            XDocument x = new System.Xml.Linq.XDocument(
             new XDeclaration("1.0", "utf-8", "yes"),
             new XProcessingInstruction("webcretexml", "version=\"1.0\""),
             new XElement("WebcreteXML",
                 new XElement("WebcreteXMLMsgsRq",
                     new XElement("CustomerUpdateRq", 
                         new XElement("CustomerUpdate",
                            new XElement("Name",name),
                            new XElement("Code",code),
                            new XElement("Sort",sort))))));

           return x.ToString();
        }

        public string GetProjectUpdateRequest(string customerCode, string code, string name)
        {
            XDocument x = new System.Xml.Linq.XDocument(
             new XDeclaration("1.0", "utf-8", "yes"),
             new XProcessingInstruction("webcretexml", "version=\"1.0\""),
             new XElement("WebcreteXML",
                 new XElement("WebcreteXMLMsgsRq",
                     new XElement("ProjectUpdateRq",
                         new XElement("ProjectUpdate",
                            new XElement("CustomerCode", customerCode),
                            new XElement("Name", name),
                            new XElement("Code", code))))));

            return x.ToString();
        }

        public string GetItemUpdateRequest(string code, string description, string shortDescription, string categoryCode)
        {
            XDocument x = new System.Xml.Linq.XDocument(
             new XDeclaration("1.0", "utf-8", "yes"),
             new XProcessingInstruction("webcretexml", "version=\"1.0\""),
             new XElement("WebcreteXML",
                 new XElement("WebcreteXMLMsgsRq",
                     new XElement("ItemUpdateRq",
                         new XElement("ItemUpdate",
                            new XElement("Code", code),
                            new XElement("Description", description),
                            new XElement("ShortDescription", shortDescription),
                            new XElement("CategoryCode", categoryCode))))));

            return x.ToString();
        }

        public string GetTruckStatusUpdateRequest(string code, string truckCode, string statusCode, DateTime statusTimeStamp)
        {
            XDocument x = new System.Xml.Linq.XDocument(
             new XDeclaration("1.0", "utf-8", "yes"),
             new XProcessingInstruction("webcretexml", "version=\"1.0\""),
             new XElement("WebcreteXML",
                 new XElement("WebcreteXMLMsgsRq",
                     new XElement("TruckStatusUpdateRq",
                         new XElement("TruckStatusUpdate",
                            new XElement("SignalingUnitCode", code),
                            new XElement("TruckCode", truckCode),
                            new XElement("StatusCode", statusCode),
                            new XElement("StatusTimeStamp", statusTimeStamp.ToString("s")))))));

            return x.ToString();
        }

        public string GetTruckGpsUpdateRequest(string code, string truckCode, string latitue, string longitue, DateTime gpsTimeStamp)
        {
            XDocument x = new System.Xml.Linq.XDocument(
             new XDeclaration("1.0", "utf-8", "yes"),
             new XProcessingInstruction("webcretexml", "version=\"1.0\""),
             new XElement("WebcreteXML",
                 new XElement("WebcreteXMLMsgsRq",
                     new XElement("TruckGpsUpdateRq",
                         new XElement("TruckGpsUpdate",
                            new XElement("SignalingUnitCode", code),
                            new XElement("TruckCode", truckCode),
                            new XElement("Latitude", latitue),
                            new XElement("Longitude", longitue),
                            new XElement("GpsTimeStamp", gpsTimeStamp.ToString("s")))))));

            return x.ToString();
        }

        public string GetTicketMessageQueryRequest(string code, string messageQueueID, string LastTicketMessageID)
        {
            XDocument x = new System.Xml.Linq.XDocument(
             new XDeclaration("1.0", "utf-8", "yes"),
             new XProcessingInstruction("webcretexml", "version=\"1.0\""),
             new XElement("WebcreteXML",
                 new XElement("WebcreteXMLMsgsRq",
                     new XElement("TicketMessageQueryRq",                         
                            new XElement("SignalingUnitCode", code),
                            new XElement("MessageQueueID", messageQueueID),
                            new XElement("LastTicketMessageID", LastTicketMessageID)))));

            return x.ToString();
        }

        private void comboBoxRequest_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxRequest.SelectedItem.ToString())
            {
                case "VersionQuery":
                    textBoxRequest.Text = IndentXMLString(GetVersionQueryRequest());
                    break;
                case "CompanyQuery":
                    textBoxRequest.Text = IndentXMLString(GetCompanyQueryRequest());
                    break;
                case "CustomerQuery":
                    textBoxRequest.Text = IndentXMLString(GetCustomerQueryRequest());
                    break;
                case "TicketQuery":
                    textBoxRequest.Text = IndentXMLString(GetTicketQueryRequest(DateTime.Now,DateTime.Now));
                    break;           
                case "ItemQuery":
                    textBoxRequest.Text = IndentXMLString(GetItemQueryRequest());
                    break;
                case "ProjectQuery":
                    textBoxRequest.Text = IndentXMLString(GetProjectQueryRequest());
                    break;
                case "CustomerUpdate":
                    textBoxRequest.Text = IndentXMLString(GetCustomerUpdateRequest("ABCConcrete","ABCConcrete Inc.","ABCConcrete"));
                    break;
                case "ProjectUpdate":
                    textBoxRequest.Text = IndentXMLString(GetProjectUpdateRequest("ABCConcrete", "11229", "Walmart"));
                    break;
                case "ItemUpdate":
                    textBoxRequest.Text = IndentXMLString(GetItemUpdateRequest("4011", "4000 psi pump", "4000 psi", "MIX"));
                    break;
                case "TruckStatusUpdate":
                    textBoxRequest.Text = IndentXMLString(GetTruckStatusUpdateRequest("1", "32", "TOJOB", DateTime.Now));
                    break;
                case "TruckGpsUpdate":
                    textBoxRequest.Text = IndentXMLString(GetTruckGpsUpdateRequest("1", "32", "41.303603", "-73.933310", DateTime.Now));
                    break;
                case "TicketMessageQuery":
                    textBoxRequest.Text = IndentXMLString(GetTicketMessageQueryRequest("1", "1", "0"));
                    break;
            }
        }

      private string IndentXMLString(string xml)
      {
         string outXml = string.Empty;
         MemoryStream ms = new MemoryStream();
         // Create a XMLTextWriter that will send its output to a memory stream (file)
         XmlTextWriter xtw = new XmlTextWriter(ms, Encoding.Unicode);
         XmlDocument doc = new XmlDocument();

         try
         {
            // Load the unformatted XML text string into an instance 
            // of the XML Document Object Model (DOM)
            doc.LoadXml(xml);

            // Set the formatting property of the XML Text Writer to indented
            // the text writer is where the indenting will be performed
            xtw.Formatting = Formatting.Indented;

            // write dom xml to the xmltextwriter
            doc.WriteContentTo(xtw);
            // Flush the contents of the text writer
            // to the memory stream, which is simply a memory file
            xtw.Flush();

            // set to start of the memory stream (file)
            ms.Seek(0, SeekOrigin.Begin);
            // create a reader to read the contents of 
            // the memory stream (file)
            StreamReader sr = new StreamReader(ms);
            // return the formatted string to caller
            return sr.ReadToEnd();
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.ToString());
            return string.Empty;
         }
      }
   }        
}
