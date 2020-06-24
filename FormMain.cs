using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using WebcreteAPIExplorer.WebcreteAPI;


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

                var api = new WebcreteAPISoapClient();
                
                if (textBoxURL.Text.Length > 0)
                {
                    // each concretego customer uses its own api endpoint in the format of {account}.api.concretego.com/webcreteapi.asmx
                    api.Endpoint.Address = new System.ServiceModel.EndpointAddress(textBoxURL.Text);
                }

                // please contact us to get the appId and apiKey for your application                
                var ticketHeader = api.GetPublicKey("Test", "F52D2965BF8318F", out string publicKey); 
               
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

                try
                {
                    if (api.Login(ticketHeader, textBoxUserName.Text, encryptedPassword) == false)
                    {
                        MessageBox.Show("Login failed.");
                        return;
                    }
                    string response = api.ProcessRequest(ticketHeader, textBoxRequest.Text);
                    if (response != null)
                    {
                        textBoxResponse.Text = IndentXMLString(response);
                    }
                    else
                    {
                        MessageBox.Show("Request failed.");
                        return;
                    }
                }
                finally
                {
                    api.Logout(ticketHeader);
                }
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

        public string GetUOMQueryRequest()
        {
            XDocument x = new System.Xml.Linq.XDocument(
               new XDeclaration("1.0", "utf-8", "yes"),
               new XProcessingInstruction("webcretexml", "version=\"1.0\""),
               new XElement("WebcreteXML",
                   new XElement("WebcreteXMLMsgsRq",
                       new XElement("UOMQueryRq", ""))));

            return x.ToString();
        }

        public string GetItemTypeQueryRequest()
        {
            XDocument x = new System.Xml.Linq.XDocument(
               new XDeclaration("1.0", "utf-8", "yes"),
               new XProcessingInstruction("webcretexml", "version=\"1.0\""),
               new XElement("WebcreteXML",
                   new XElement("WebcreteXMLMsgsRq",
                       new XElement("ItemTypeQueryRq", ""))));

            return x.ToString();
        }

        public string GetItemCategoryQueryRequest()
        {
            XDocument x = new System.Xml.Linq.XDocument(
               new XDeclaration("1.0", "utf-8", "yes"),
               new XProcessingInstruction("webcretexml", "version=\"1.0\""),
               new XElement("WebcreteXML",
                   new XElement("WebcreteXMLMsgsRq",
                       new XElement("ItemCategoryQueryRq", ""))));

            return x.ToString();
        }

        public string GetCreditCodeQueryRequest()
        {
            XDocument x = new System.Xml.Linq.XDocument(
               new XDeclaration("1.0", "utf-8", "yes"),
               new XProcessingInstruction("webcretexml", "version=\"1.0\""),
               new XElement("WebcreteXML",
                   new XElement("WebcreteXMLMsgsRq",
                       new XElement("CreditCodeQueryRq", ""))));

            return x.ToString();
        }

        public string GetDivisionQueryRequest()
        {
            XDocument x = new System.Xml.Linq.XDocument(
               new XDeclaration("1.0", "utf-8", "yes"),
               new XProcessingInstruction("webcretexml", "version=\"1.0\""),
               new XElement("WebcreteXML",
                   new XElement("WebcreteXMLMsgsRq",
                       new XElement("DivisionQueryRq", ""))));

            return x.ToString();
        }

        public string GetPriceCategoryQueryRequest()
        {
            XDocument x = new System.Xml.Linq.XDocument(
               new XDeclaration("1.0", "utf-8", "yes"),
               new XProcessingInstruction("webcretexml", "version=\"1.0\""),
               new XElement("WebcreteXML",
                   new XElement("WebcreteXMLMsgsRq",
                       new XElement("PriceCategoryQueryRq", ""))));

            return x.ToString();
        }

        public string GetAccountingCategoryQueryRequest()
        {
            XDocument x = new System.Xml.Linq.XDocument(
               new XDeclaration("1.0", "utf-8", "yes"),
               new XProcessingInstruction("webcretexml", "version=\"1.0\""),
               new XElement("WebcreteXML",
                   new XElement("WebcreteXMLMsgsRq",
                       new XElement("AccountingCategoryQueryRq", ""))));

            return x.ToString();
        }

        public string GetLocationQueryRequest()
        {
            XDocument x = new System.Xml.Linq.XDocument(
               new XDeclaration("1.0", "utf-8", "yes"),
               new XProcessingInstruction("webcretexml", "version=\"1.0\""),
               new XElement("WebcreteXML",
                   new XElement("WebcreteXMLMsgsRq",
                       new XElement("LocationQueryRq", ""))));

            return x.ToString();
        }

        public string GetLocationUpdateRequest(string code, string name)
        {
            XDocument x = new System.Xml.Linq.XDocument(
             new XDeclaration("1.0", "utf-8", "yes"),
             new XProcessingInstruction("webcretexml", "version=\"1.0\""),
             new XElement("WebcreteXML",
                 new XElement("WebcreteXMLMsgsRq",
                     new XElement("LocationUpdateRq",
                         new XElement("LocationUpdate",
                            new XElement("Code", code),
                            new XElement("Name", name))))));

            return x.ToString();
        }

        public string GetPlantQueryRequest()
        {
            XDocument x = new System.Xml.Linq.XDocument(
               new XDeclaration("1.0", "utf-8", "yes"),
               new XProcessingInstruction("webcretexml", "version=\"1.0\""),
               new XElement("WebcreteXML",
                   new XElement("WebcreteXMLMsgsRq",
                       new XElement("PlantQueryRq", ""))));

            return x.ToString();
        }

        public string GetTruckQueryRequest()
        {
            XDocument x = new System.Xml.Linq.XDocument(
               new XDeclaration("1.0", "utf-8", "yes"),
               new XProcessingInstruction("webcretexml", "version=\"1.0\""),
               new XElement("WebcreteXML",
                   new XElement("WebcreteXMLMsgsRq",
                       new XElement("TruckQueryRq", ""))));

            return x.ToString();
        }

        public string GetEmployeeQueryRequest()
        {
            XDocument x = new System.Xml.Linq.XDocument(
               new XDeclaration("1.0", "utf-8", "yes"),
               new XProcessingInstruction("webcretexml", "version=\"1.0\""),
               new XElement("WebcreteXML",
                   new XElement("WebcreteXMLMsgsRq",
                       new XElement("EmployeeQueryRq", ""))));

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

        public string GetCustomerListQueryRequest()
        {
            XDocument x = new System.Xml.Linq.XDocument(
               new XDeclaration("1.0", "utf-8", "yes"),
               new XProcessingInstruction("webcretexml", "version=\"1.0\""),
               new XElement("WebcreteXML",
                   new XElement("WebcreteXMLMsgsRq",
                       new XElement("CustomerQueryRq", new XElement("ListOnly", "True")))));

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

        public string GetProjectListQueryRequest()
        {
            XDocument x = new System.Xml.Linq.XDocument(
               new XDeclaration("1.0", "utf-8", "yes"),
               new XProcessingInstruction("webcretexml", "version=\"1.0\""),
               new XElement("WebcreteXML",
                   new XElement("WebcreteXMLMsgsRq",
                       new XElement("ProjectQueryRq", new XElement("ListOnly", "True")))));

            return x.ToString();
        }

        public string GetProjectIncludeCustomerQueryRequest()
        {
            XDocument x = new System.Xml.Linq.XDocument(
               new XDeclaration("1.0", "utf-8", "yes"),
               new XProcessingInstruction("webcretexml", "version=\"1.0\""),
               new XElement("WebcreteXML",
                   new XElement("WebcreteXMLMsgsRq",
                       new XElement("ProjectQueryRq", ""),
                            new XElement("IncludeRetElement", "Customer"))));

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

        public string GetItemListQueryRequest()
        {
            XDocument x = new System.Xml.Linq.XDocument(
              new XDeclaration("1.0", "utf-8", "yes"),
              new XProcessingInstruction("webcretexml", "version=\"1.0\""),
              new XElement("WebcreteXML",
                  new XElement("WebcreteXMLMsgsRq",
                      new XElement("ItemQueryRq", new XElement("ListOnly", "True")))));

            return x.ToString();
        }

        public string GetItemQueryForSpecificLocationRequest()
        {
            XDocument x = new System.Xml.Linq.XDocument(
              new XDeclaration("1.0", "utf-8", "yes"),
              new XProcessingInstruction("webcretexml", "version=\"1.0\""),
              new XElement("WebcreteXML",
                  new XElement("WebcreteXMLMsgsRq",
                      new XElement("ItemQueryRq", new XElement("LocationCode", "2")))));

            return x.ToString();
        }        

        public string GetItemByItemCategoryQueryRequest()
        {
            XDocument x = new System.Xml.Linq.XDocument(
              new XDeclaration("1.0", "utf-8", "yes"),
              new XProcessingInstruction("webcretexml", "version=\"1.0\""),
              new XElement("WebcreteXML",
                  new XElement("WebcreteXMLMsgsRq",
                      new XElement("ItemQueryRq",
                        new XElement("CategoryCode", "MIX")))));

            return x.ToString();
        }

        public string GetMixItemQueryRequest()
        {
            XDocument x = new System.Xml.Linq.XDocument(
              new XDeclaration("1.0", "utf-8", "yes"),
              new XProcessingInstruction("webcretexml", "version=\"1.0\""),
              new XElement("WebcreteXML",
                  new XElement("WebcreteXMLMsgsRq",
                      new XElement("ItemQueryRq",
                        new XElement("ItemType", "Concrete")))));

            return x.ToString();
        }

        public string GetMixItemListQueryRequest()
        {
            XDocument x = new System.Xml.Linq.XDocument(
              new XDeclaration("1.0", "utf-8", "yes"),
              new XProcessingInstruction("webcretexml", "version=\"1.0\""),
              new XElement("WebcreteXML",
                  new XElement("WebcreteXMLMsgsRq",
                      new XElement("ItemQueryRq",
                        new XElement("ItemType", "Concrete"),
                        new XElement("ListOnly", "True")))));

            return x.ToString();
        }

        

        public string GetConstituentItemQueryRequest()
        {
            XDocument x = new System.Xml.Linq.XDocument(
              new XDeclaration("1.0", "utf-8", "yes"),
              new XProcessingInstruction("webcretexml", "version=\"1.0\""),
              new XElement("WebcreteXML",
                  new XElement("WebcreteXMLMsgsRq",
                      new XElement("ItemQueryRq",
                        new XElement("IsConstituent", "True")))));

            return x.ToString();
        }

        public string GetConstituentItemListQueryRequest()
        {
            XDocument x = new System.Xml.Linq.XDocument(
              new XDeclaration("1.0", "utf-8", "yes"),
              new XProcessingInstruction("webcretexml", "version=\"1.0\""),
              new XElement("WebcreteXML",
                  new XElement("WebcreteXMLMsgsRq",
                      new XElement("ItemQueryRq",
                        new XElement("IsConstituent", "True"),
                        new XElement("ListOnly", "True")))));

            return x.ToString();
        }

        public string GetItemIncludeLocationQueryRequest()
        {
            XDocument x = new System.Xml.Linq.XDocument(
              new XDeclaration("1.0", "utf-8", "yes"),
              new XProcessingInstruction("webcretexml", "version=\"1.0\""),
              new XElement("WebcreteXML",
                  new XElement("WebcreteXMLMsgsRq",
                      new XElement("ItemQueryRq",
                        new XElement("IncludeRetElement", "Location")))));

            return x.ToString();
        }

        public string GetItemIncludeMixDesignQueryRequest()
        {
            XDocument x = new System.Xml.Linq.XDocument(
              new XDeclaration("1.0", "utf-8", "yes"),
              new XProcessingInstruction("webcretexml", "version=\"1.0\""),
              new XElement("WebcreteXML",
                  new XElement("WebcreteXMLMsgsRq",
                      new XElement("ItemQueryRq",
                        new XElement("IncludeRetElement", "MixDesign")))));

            return x.ToString();
        }

        public string GetItemIncludePricingQueryRequest()
        {
            XDocument x = new System.Xml.Linq.XDocument(
              new XDeclaration("1.0", "utf-8", "yes"),
              new XProcessingInstruction("webcretexml", "version=\"1.0\""),
              new XElement("WebcreteXML",
                  new XElement("WebcreteXMLMsgsRq",
                      new XElement("ItemQueryRq",
                        new XElement("IncludeRetElement", "Pricing")))));

            return x.ToString();
        }

        public string GetItemIncludeCostQueryRequest()
        {
            XDocument x = new System.Xml.Linq.XDocument(
              new XDeclaration("1.0", "utf-8", "yes"),
              new XProcessingInstruction("webcretexml", "version=\"1.0\""),
              new XElement("WebcreteXML",
                  new XElement("WebcreteXMLMsgsRq",
                      new XElement("ItemQueryRq",
                        new XElement("IncludeRetElement", "Cost")))));

            return x.ToString();
        }

        public string GetItemIncludeBatchingQueryRequest()
        {
            XDocument x = new System.Xml.Linq.XDocument(
              new XDeclaration("1.0", "utf-8", "yes"),
              new XProcessingInstruction("webcretexml", "version=\"1.0\""),
              new XElement("WebcreteXML",
                  new XElement("WebcreteXMLMsgsRq",
                      new XElement("ItemQueryRq",
                        new XElement("IncludeRetElement", "Batching")))));

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

        public string GetTicketQueryWithBatchWeightsOnlyRequest(DateTime dtOrderFrom, DateTime dtOrderTo)
        {
            XDocument x = new System.Xml.Linq.XDocument(
              new XDeclaration("1.0", "utf-8", "yes"),
              new XProcessingInstruction("webcretexml", "version=\"1.0\""),
              new XElement("WebcreteXML",
                  new XElement("WebcreteXMLMsgsRq",
                      new XElement("TicketQueryRq",
                          new XElement("FromOrderDate", dtOrderFrom.ToShortDateString()),
                          new XElement("ToOrderDate", dtOrderTo.ToShortDateString()),
                          new XElement("WithBatchWeightsOnly", "true")))));

            return x.ToString();
        }

        

        public string GetTicketQueryDescRequest(DateTime dtOrderFrom, DateTime dtOrderTo)
        {
            XDocument x = new System.Xml.Linq.XDocument(
              new XDeclaration("1.0", "utf-8", "yes"),
              new XProcessingInstruction("webcretexml", "version=\"1.0\""),
              new XElement("WebcreteXML",
                  new XElement("WebcreteXMLMsgsRq",
                      new XElement("TicketQueryRq",
                          new XElement("FromOrderDate", dtOrderFrom.ToShortDateString()),
                          new XElement("ToOrderDate", dtOrderTo.ToShortDateString()),
                          new XElement("OrderBy", "desc")))));

            return x.ToString();
        }

        public string GetTicketQueryByLoadTimeRequest(DateTime dtLoadTimeFrom, DateTime dtLoadTimeTo)
        {
            XDocument x = new System.Xml.Linq.XDocument(
              new XDeclaration("1.0", "utf-8", "yes"),
              new XProcessingInstruction("webcretexml", "version=\"1.0\""),
              new XElement("WebcreteXML",
                  new XElement("WebcreteXMLMsgsRq",
                      new XElement("TicketQueryRq",
                          new XElement("FromLoadTime", dtLoadTimeFrom.ToString("s")),
                          new XElement("ToLoadTime", dtLoadTimeTo.ToString("s"))))));

            return x.ToString();
        }

        public string GetTicketQueryByUpdateTimeRequest(DateTime dtUpdateTimeFrom, DateTime dtUpdateTimeTo)
        {
            XDocument x = new System.Xml.Linq.XDocument(
              new XDeclaration("1.0", "utf-8", "yes"),
              new XProcessingInstruction("webcretexml", "version=\"1.0\""),
              new XElement("WebcreteXML",
                  new XElement("WebcreteXMLMsgsRq",
                      new XElement("TicketQueryRq",
                          new XElement("FromUpdateTime", dtUpdateTimeFrom.ToString("s")),
                          new XElement("ToUpdateTime", dtUpdateTimeTo.ToString("s"))))));

            return x.ToString();
        }


        public string GetTicketQueryWithRemovedRequest(DateTime dtOrderFrom, DateTime dtOrderTo)
        {
            XDocument x = new System.Xml.Linq.XDocument(
              new XDeclaration("1.0", "utf-8", "yes"),
              new XProcessingInstruction("webcretexml", "version=\"1.0\""),
              new XElement("WebcreteXML",
                  new XElement("WebcreteXMLMsgsRq",
                      new XElement("TicketQueryRq",
                          new XElement("IncludeRemovedTicket", "True"),
                          new XElement("FromOrderDate", dtOrderFrom.ToShortDateString()),
                          new XElement("ToOrderDate", dtOrderTo.ToShortDateString())))));

            return x.ToString();
        }
        
        public string GetTicketQueryForMixCodeRequest(DateTime dtOrderFrom, DateTime dtOrderTo)
        {
            XDocument x = new System.Xml.Linq.XDocument(
              new XDeclaration("1.0", "utf-8", "yes"),
              new XProcessingInstruction("webcretexml", "version=\"1.0\""),
              new XElement("WebcreteXML",
                  new XElement("WebcreteXMLMsgsRq",
                      new XElement("TicketQueryRq",
                           new XElement("MixCode", "020-2"),
                          new XElement("FromOrderDate", dtOrderFrom.ToShortDateString()),
                          new XElement("ToOrderDate", dtOrderTo.ToShortDateString())))));

            return x.ToString();
        }
        

        public string GetTicketListQueryRequest(DateTime dtOrderFrom, DateTime dtOrderTo)
        {
            XDocument x = new System.Xml.Linq.XDocument(
              new XDeclaration("1.0", "utf-8", "yes"),
              new XProcessingInstruction("webcretexml", "version=\"1.0\""),
              new XElement("WebcreteXML",
                  new XElement("WebcreteXMLMsgsRq",
                      new XElement("TicketQueryRq",
                          new XElement("ListOnly", "True"),
                          new XElement("FromOrderDate", dtOrderFrom.ToShortDateString()),
                          new XElement("ToOrderDate", dtOrderTo.ToShortDateString())))));

            return x.ToString();
        }

        public string GeOrderQueryRequest(DateTime dtOrderFrom, DateTime dtOrderTo)
        {
            XDocument x = new System.Xml.Linq.XDocument(
              new XDeclaration("1.0", "utf-8", "yes"),
              new XProcessingInstruction("webcretexml", "version=\"1.0\""),
              new XElement("WebcreteXML",
                  new XElement("WebcreteXMLMsgsRq",
                      new XElement("OrderQueryRq",
                          new XElement("FromOrderDate", dtOrderFrom.ToShortDateString()),
                          new XElement("ToOrderDate", dtOrderTo.ToShortDateString()),
                          new XElement("IncludeRetElement", "PRODUCT"),
                          new XElement("IncludeRetElement", "SCHEDULE")))));

            return x.ToString();
        }

        public string GeOrderUpdateQueryRequest(DateTime dtOrderUpdateFrom, DateTime dtOrderUpdateTo)
        {
            XDocument x = new System.Xml.Linq.XDocument(
              new XDeclaration("1.0", "utf-8", "yes"),
              new XProcessingInstruction("webcretexml", "version=\"1.0\""),
              new XElement("WebcreteXML",
                  new XElement("WebcreteXMLMsgsRq",
                      new XElement("OrderQueryRq",
                          new XElement("FromUpdateTime", dtOrderUpdateFrom.ToString("s")),
                          new XElement("ToUpdateTime", dtOrderUpdateTo.ToString("s")),
                          new XElement("IncludeRetElement", "PRODUCT"),
                          new XElement("IncludeRetElement", "SCHEDULE")))));

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


        public string GetTicketBatchResultMessageQueryRequest(string messageQueueID, string lastTicketBatchResultMessageID)
        {
            XDocument x = new System.Xml.Linq.XDocument(
             new XDeclaration("1.0", "utf-8", "yes"),
             new XProcessingInstruction("webcretexml", "version=\"1.0\""),
             new XElement("WebcreteXML",
                 new XElement("WebcreteXMLMsgsRq",
                     new XElement("TicketBatchResultMessageQueryRq",                            
                            new XElement("MessageQueueID", messageQueueID),
                            new XElement("LastTicketBatchResultMessageID", lastTicketBatchResultMessageID)))));

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
                case "CustomerQuery(ListOnly)":
                    textBoxRequest.Text = IndentXMLString(GetCustomerListQueryRequest());
                    break;
                case "OrderQuery":
                    textBoxRequest.Text = IndentXMLString(GeOrderQueryRequest(DateTime.Now, DateTime.Now));
                    break;
                case "OrderQuery(OrderUpdate)":
                    textBoxRequest.Text = IndentXMLString(GeOrderUpdateQueryRequest(DateTime.Now.AddMinutes(-5), DateTime.Now));
                    break;
                case "TicketQuery":
                    textBoxRequest.Text = IndentXMLString(GetTicketQueryRequest(DateTime.Now,DateTime.Now));
                    break;
                case "TicketQuery(IncludeRemovedTickets)":
                    textBoxRequest.Text = IndentXMLString(GetTicketQueryWithRemovedRequest(DateTime.Now, DateTime.Now));
                    break;
                case "TicketQuery(ListOnly)":
                    textBoxRequest.Text = IndentXMLString(GetTicketListQueryRequest(DateTime.Now, DateTime.Now));
                    break;
                case "TicketQuery(MixCode)":
                    textBoxRequest.Text = IndentXMLString(GetTicketQueryForMixCodeRequest(DateTime.Now, DateTime.Now));
                    break;
                case "TicketQuery(LoadTime)":
                    textBoxRequest.Text = IndentXMLString(GetTicketQueryByLoadTimeRequest(DateTime.Now.AddMinutes(-1), DateTime.Now));
                    break;
                case "TicketQuery(UpdateTime)":
                    textBoxRequest.Text = IndentXMLString(GetTicketQueryByUpdateTimeRequest(DateTime.Now.AddMinutes(-1), DateTime.Now));
                    break;
                case "TicketQuery(SortDesc)":
                    textBoxRequest.Text = IndentXMLString(GetTicketQueryDescRequest(DateTime.Now, DateTime.Now));
                    break;
                case "TicketQuery(WithBatchWeightsOnly)":
                    textBoxRequest.Text = IndentXMLString(GetTicketQueryWithBatchWeightsOnlyRequest(DateTime.Now, DateTime.Now));
                    break;
                case "ItemQuery":
                    textBoxRequest.Text = IndentXMLString(GetItemQueryRequest());
                    break;
                case "ItemQuery(ListOnly)":
                    textBoxRequest.Text = IndentXMLString(GetItemListQueryRequest());
                    break;
                case "ItemQuery(SpecificLocation(s))":
                    textBoxRequest.Text = IndentXMLString(GetItemQueryForSpecificLocationRequest());
                    break;
                case "ItemQuery(MixOnly)":
                    textBoxRequest.Text = IndentXMLString(GetMixItemQueryRequest());
                    break;
                case "ItemQuery(ListMixOnly)":
                    textBoxRequest.Text = IndentXMLString(GetMixItemListQueryRequest());
                    break;
                case "ItemQuery(ConstituentOnly)":
                    textBoxRequest.Text = IndentXMLString(GetConstituentItemQueryRequest());
                    break;
                case "ItemQuery(ListConstituentOnly)":
                    textBoxRequest.Text = IndentXMLString(GetConstituentItemListQueryRequest());
                    break;
                case "ItemQuery(ByItemCateogry)":
                    textBoxRequest.Text = IndentXMLString(GetItemByItemCategoryQueryRequest());
                    break;
                case "ItemQuery(IncludeLocation)":
                    textBoxRequest.Text = IndentXMLString(GetItemIncludeLocationQueryRequest());
                    break;
                case "ItemQuery(IncludeMixDesign)":
                    textBoxRequest.Text = IndentXMLString(GetItemIncludeMixDesignQueryRequest());
                    break;
                case "ItemQuery(IncludePricing)":
                    textBoxRequest.Text = IndentXMLString(GetItemIncludePricingQueryRequest());
                    break;
                case "ItemQuery(IncludeCost)":
                    textBoxRequest.Text = IndentXMLString(GetItemIncludeCostQueryRequest());
                    break;
                case "ItemQuery(IncludeBatching)":
                    textBoxRequest.Text = IndentXMLString(GetItemIncludeBatchingQueryRequest());
                    break;
                case "ProjectQuery":
                    textBoxRequest.Text = IndentXMLString(GetProjectQueryRequest());
                    break;
                case "ProjectQuery(ListOnly)":
                    textBoxRequest.Text = IndentXMLString(GetProjectListQueryRequest());
                    break;
                case "ProjectQuery(IncludeCustomer)":
                    textBoxRequest.Text = IndentXMLString(GetProjectIncludeCustomerQueryRequest());
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
                case "TicketBatchResultMessageQuery":
                    textBoxRequest.Text = IndentXMLString(GetTicketBatchResultMessageQueryRequest("1", "0"));
                    break;
                case "UOMQuery":
                    textBoxRequest.Text = IndentXMLString(GetUOMQueryRequest());
                    break;
                case "ItemTypeQuery":
                    textBoxRequest.Text = IndentXMLString(GetItemTypeQueryRequest());
                    break;
                case "ItemCategoryQuery":
                    textBoxRequest.Text = IndentXMLString(GetItemCategoryQueryRequest());
                    break;
                case "LocationQuery":
                    textBoxRequest.Text = IndentXMLString(GetLocationQueryRequest());
                    break;
                case "LocationUpdate":
                    textBoxRequest.Text = IndentXMLString(GetLocationUpdateRequest("1","Location 1"));
                    break;
                case "PlantQuery":
                    textBoxRequest.Text = IndentXMLString(GetPlantQueryRequest());
                    break;
                case "TruckQuery":
                    textBoxRequest.Text = IndentXMLString(GetTruckQueryRequest());
                    break;
                case "EmployeeQuery":
                    textBoxRequest.Text = IndentXMLString(GetEmployeeQueryRequest());
                    break;
                case "CreditCodeQuery":
                    textBoxRequest.Text = IndentXMLString(GetCreditCodeQueryRequest());
                    break;
                case "DivisionQuery":
                    textBoxRequest.Text = IndentXMLString(GetDivisionQueryRequest());
                    break;
                case "PriceCategoryQuery":
                    textBoxRequest.Text = IndentXMLString(GetPriceCategoryQueryRequest());
                    break;
                case "AccountingCategoryQuery":
                    textBoxRequest.Text = IndentXMLString(GetAccountingCategoryQueryRequest());
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
