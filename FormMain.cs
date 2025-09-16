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
                string AppID = textBoxAPPID.Text;
                string APIKey = textBoxAPIKEY.Text;
                var ticketHeader = api.GetPublicKey(AppID, APIKey, out string publicKey); 
               
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
                    if (api.Login(ticketHeader, textBoxUserName.Text, encryptedPassword, textBoxSlug.Text) == false)                    
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

        public string GetReasonCodeQueryRequest()
        {
            XDocument x = new System.Xml.Linq.XDocument(
               new XDeclaration("1.0", "utf-8", "yes"),
               new XProcessingInstruction("webcretexml", "version=\"1.0\""),
               new XElement("WebcreteXML",
                   new XElement("WebcreteXMLMsgsRq",
                       new XElement("ReasonCodeQueryRq", ""))));

            return x.ToString();
        }

        public string GetSalesAnalysisCodeQueryRequest()
        {
            XDocument x = new System.Xml.Linq.XDocument(
               new XDeclaration("1.0", "utf-8", "yes"),
               new XProcessingInstruction("webcretexml", "version=\"1.0\""),
               new XElement("WebcreteXML",
                   new XElement("WebcreteXMLMsgsRq",
                       new XElement("SalesAnalysisCodeQueryRq", ""))));

            return x.ToString();
        }

        public string GetHaulerQueryRequest()
        {
            XDocument x = new System.Xml.Linq.XDocument(
               new XDeclaration("1.0", "utf-8", "yes"),
               new XProcessingInstruction("webcretexml", "version=\"1.0\""),
               new XElement("WebcreteXML",
                   new XElement("WebcreteXMLMsgsRq",
                       new XElement("HaulerQueryRq", ""))));

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

        public string GetTruckUpdateRequest(string code, string description, string plantCode)
        {
            XDocument x = new System.Xml.Linq.XDocument(
               new XDeclaration("1.0", "utf-8", "yes"),
               new XProcessingInstruction("webcretexml", "version=\"1.0\""),
               new XElement("WebcreteXML",
                   new XElement("WebcreteXMLMsgsRq",
                       new XElement("TruckUpdateRq",
                            new XElement("TruckUpdate",
                                new XElement("Code", code),
                                new XElement("Description", description),
                                new XElement("PlantCode", plantCode))))));

            return x.ToString();
        }

        public string GetTruckQueryByStatusUpdateTimeRequest(DateTime dtUpdateTimeFrom, DateTime dtUpdateTimeTo)
        {
            XDocument x = new System.Xml.Linq.XDocument(
               new XDeclaration("1.0", "utf-8", "yes"),
               new XProcessingInstruction("webcretexml", "version=\"1.0\""),
               new XElement("WebcreteXML",
                   new XElement("WebcreteXMLMsgsRq",
                       new XElement("TruckQueryRq", 
                          new XElement("FromStatusTimeStamp", dtUpdateTimeFrom.ToString("s")),
                          new XElement("ToStatusTimeStamp", dtUpdateTimeTo.ToString("s"))))));

            return x.ToString();
        }

        public string GetTruckQueryByLocationUpdateTimeRequest(DateTime dtUpdateTimeFrom, DateTime dtUpdateTimeTo)
        {
            XDocument x = new System.Xml.Linq.XDocument(
               new XDeclaration("1.0", "utf-8", "yes"),
               new XProcessingInstruction("webcretexml", "version=\"1.0\""),
               new XElement("WebcreteXML",
                   new XElement("WebcreteXMLMsgsRq",
                       new XElement("TruckQueryRq", 
                          new XElement("FromLocationUpdateTime", dtUpdateTimeFrom.ToString("s")),
                          new XElement("ToLocationUpdateTime", dtUpdateTimeTo.ToString("s"))))));

            return x.ToString();
        }

        public string GetEmployeeQueryRequest()
        {
            XDocument x = new System.Xml.Linq.XDocument(
               new XDeclaration("1.0", "utf-8", "yes"),
               new XProcessingInstruction("webcretexml", "version=\"1.0\""),
               new XElement("WebcreteXML",
                   new XElement("WebcreteXMLMsgsRq",
                       new XElement("EmployeeQueryRq"))));

            return x.ToString();
        }

        public string GetEmployeeUpdateRequest(string code, string name, string employeeType)
        {
            XDocument x = new System.Xml.Linq.XDocument(
               new XDeclaration("1.0", "utf-8", "yes"),
               new XProcessingInstruction("webcretexml", "version=\"1.0\""),
               new XElement("WebcreteXML",
                   new XElement("WebcreteXMLMsgsRq",
                       new XElement("EmployeeUpdateRq",
                            new XElement("EmployeeUpdate",
                                new XElement("Code", code),
                                new XElement("Name", name),
                                new XElement("EmployeeType", employeeType))))));

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

        public string GetCustomerIncludeSundryChargesQueryRequest()
        {
            XDocument x = new System.Xml.Linq.XDocument(
               new XDeclaration("1.0", "utf-8", "yes"),
               new XProcessingInstruction("webcretexml", "version=\"1.0\""),
               new XElement("WebcreteXML",
                   new XElement("WebcreteXMLMsgsRq",
                       new XElement("CustomerQueryRq", new XElement("IncludeRetElement", "SUNDRYCHARGE")))));

            return x.ToString();
        }

        public string GetCustomerIncludeUserDefinedFieldsQueryRequest()
        {
            XDocument x = new System.Xml.Linq.XDocument(
               new XDeclaration("1.0", "utf-8", "yes"),
               new XProcessingInstruction("webcretexml", "version=\"1.0\""),
               new XElement("WebcreteXML",
                   new XElement("WebcreteXMLMsgsRq",
                       new XElement("CustomerQueryRq", new XElement("IncludeRetElement", "USERDEFINEDFIELD")))));

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

        public string GetJobQueryRequest()
        {
            XDocument x = new System.Xml.Linq.XDocument(
               new XDeclaration("1.0", "utf-8", "yes"),
               new XProcessingInstruction("webcretexml", "version=\"1.0\""),
               new XElement("WebcreteXML",
                   new XElement("WebcreteXMLMsgsRq",
                       new XElement("JobQueryRq", ""))));

            return x.ToString();
        }

        public string GetQuoteQueryRequest()
        {
            XDocument x = new System.Xml.Linq.XDocument(
               new XDeclaration("1.0", "utf-8", "yes"),
               new XProcessingInstruction("webcretexml", "version=\"1.0\""),
               new XElement("WebcreteXML",
                   new XElement("WebcreteXMLMsgsRq",
                       new XElement("QuoteQueryRq", ""))));

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
                       new XElement("ProjectQueryRq", 
                            new XElement("IncludeRetElement", "Customer")))));

            return x.ToString();
        }

        public string GetProjectIncludeProductQueryRequest()
        {
            XDocument x = new System.Xml.Linq.XDocument(
               new XDeclaration("1.0", "utf-8", "yes"),
               new XProcessingInstruction("webcretexml", "version=\"1.0\""),
               new XElement("WebcreteXML",
                   new XElement("WebcreteXMLMsgsRq",
                       new XElement("ProjectQueryRq",
                            new XElement("IncludeRetElement", "Product")))));

            return x.ToString();
        }

        public string GetProjectIncludeSundryChargesQueryRequest()
        {
            XDocument x = new System.Xml.Linq.XDocument(
               new XDeclaration("1.0", "utf-8", "yes"),
               new XProcessingInstruction("webcretexml", "version=\"1.0\""),
               new XElement("WebcreteXML",
                   new XElement("WebcreteXMLMsgsRq",
                       new XElement("ProjectQueryRq",
                            new XElement("IncludeRetElement", "SundryCharge")))));

            return x.ToString();
        }

        public string GetProjectUserDefinedFieldsQueryRequest()
        {
            XDocument x = new System.Xml.Linq.XDocument(
               new XDeclaration("1.0", "utf-8", "yes"),
               new XProcessingInstruction("webcretexml", "version=\"1.0\""),
               new XElement("WebcreteXML",
                   new XElement("WebcreteXMLMsgsRq",
                       new XElement("ProjectQueryRq",
                            new XElement("IncludeRetElement", "UserDefinedField")))));

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

        public string GetItemDeleteRequest(string code)
        {
            XDocument x = new System.Xml.Linq.XDocument(
             new XDeclaration("1.0", "utf-8", "yes"),
             new XProcessingInstruction("webcretexml", "version=\"1.0\""),
             new XElement("WebcreteXML",
                 new XElement("WebcreteXMLMsgsRq",
                     new XElement("ItemUpdateRq",
                         new XElement("ItemUpdate",
                            new XElement("Code", code),
                            new XElement("Action", "Delete"))))));

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

        public string GetItemIncludeTaxOverrideQueryRequest()
        {
            XDocument x = new System.Xml.Linq.XDocument(
              new XDeclaration("1.0", "utf-8", "yes"),
              new XProcessingInstruction("webcretexml", "version=\"1.0\""),
              new XElement("WebcreteXML",
                  new XElement("WebcreteXMLMsgsRq",
                      new XElement("ItemQueryRq",
                        new XElement("IncludeRetElement", "TaxOverride")))));

            return x.ToString();
        }

        public string GetBatchTicketQueryRequest(DateTime dtOrderFrom, DateTime dtOrderTo, string dispatchOrderCode, string dispatchTicketCode)
        {
            XDocument x = new System.Xml.Linq.XDocument(
              new XDeclaration("1.0", "utf-8", "yes"),
              new XProcessingInstruction("webcretexml", "version=\"1.0\""),
              new XElement("WebcreteXML",
                  new XElement("WebcreteXMLMsgsRq",
                      new XElement("BatchTicketQueryRq",
                          new XElement("FromOrderDate", dtOrderFrom.ToShortDateString()),
                          new XElement("ToOrderDate", dtOrderTo.ToShortDateString()),
                          new XElement("DispatchOrderCode", dispatchOrderCode),
                          new XElement("DispatchTicketCode", dispatchTicketCode)
                          ))));

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

        public string GetReviewedTicketQueryRequest(DateTime dtOrderFrom, DateTime dtOrderTo)
        {
            XDocument x = new System.Xml.Linq.XDocument(
              new XDeclaration("1.0", "utf-8", "yes"),
              new XProcessingInstruction("webcretexml", "version=\"1.0\""),
              new XElement("WebcreteXML",
                  new XElement("WebcreteXMLMsgsRq",
                      new XElement("TicketQueryRq",
                          new XElement("FromOrderDate", dtOrderFrom.ToShortDateString()),
                          new XElement("ToOrderDate", dtOrderTo.ToShortDateString()),
                          new XElement("Reviewed", "True")))));

            return x.ToString();
        }

        public string GetTicketQueryRequestWithUserDefinedFields(DateTime dtOrderFrom, DateTime dtOrderTo)
        {
            XDocument x = new System.Xml.Linq.XDocument(
              new XDeclaration("1.0", "utf-8", "yes"),
              new XProcessingInstruction("webcretexml", "version=\"1.0\""),
              new XElement("WebcreteXML",
                  new XElement("WebcreteXMLMsgsRq",
                      new XElement("TicketQueryRq",
                          new XElement("FromOrderDate", dtOrderFrom.ToShortDateString()),
                          new XElement("ToOrderDate", dtOrderTo.ToShortDateString()),
                          new XElement("IncludeRetElement", "USERDEFINEDFIELD")))));

            return x.ToString();
        }

        public string GetTicketQueryRequestWithOrderUserDefinedFields(DateTime dtOrderFrom, DateTime dtOrderTo)
        {
            XDocument x = new System.Xml.Linq.XDocument(
              new XDeclaration("1.0", "utf-8", "yes"),
              new XProcessingInstruction("webcretexml", "version=\"1.0\""),
              new XElement("WebcreteXML",
                  new XElement("WebcreteXMLMsgsRq",
                      new XElement("TicketQueryRq",
                          new XElement("FromOrderDate", dtOrderFrom.ToShortDateString()),
                          new XElement("ToOrderDate", dtOrderTo.ToShortDateString()),
                          new XElement("IncludeRetElement", "ORDERUSERDEFINEDFIELD")))));

            return x.ToString();
        }

        public string GetTicketQueryRequestWithCustomerUserDefinedFields(DateTime dtOrderFrom, DateTime dtOrderTo)
        {
            XDocument x = new System.Xml.Linq.XDocument(
              new XDeclaration("1.0", "utf-8", "yes"),
              new XProcessingInstruction("webcretexml", "version=\"1.0\""),
              new XElement("WebcreteXML",
                  new XElement("WebcreteXMLMsgsRq",
                      new XElement("TicketQueryRq",
                          new XElement("FromOrderDate", dtOrderFrom.ToShortDateString()),
                          new XElement("ToOrderDate", dtOrderTo.ToShortDateString()),
                          new XElement("IncludeRetElement", "CUSTOMERUSERDEFINEDFIELD")))));

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

        public string GetTicketQueryByOrderUpdateTimeRequest(DateTime dtUpdateTimeFrom, DateTime dtUpdateTimeTo)
        {
            XDocument x = new System.Xml.Linq.XDocument(
              new XDeclaration("1.0", "utf-8", "yes"),
              new XProcessingInstruction("webcretexml", "version=\"1.0\""),
              new XElement("WebcreteXML",
                  new XElement("WebcreteXMLMsgsRq",
                      new XElement("TicketQueryRq",
                          new XElement("FromOrderUpdateTime", dtUpdateTimeFrom.ToString("s")),
                          new XElement("ToOrderUpdateTime", dtUpdateTimeTo.ToString("s"))))));

            return x.ToString();
        }

        public string GetTicketQueryByTicketTimeRequest(DateTime dtUpdateTimeFrom, DateTime dtUpdateTimeTo)
        {
            XDocument x = new System.Xml.Linq.XDocument(
              new XDeclaration("1.0", "utf-8", "yes"),
              new XProcessingInstruction("webcretexml", "version=\"1.0\""),
              new XElement("WebcreteXML",
                  new XElement("WebcreteXMLMsgsRq",
                      new XElement("TicketQueryRq",
                          new XElement("FromTicketTime", dtUpdateTimeFrom.ToString("s")),
                          new XElement("ToTicketTime", dtUpdateTimeTo.ToString("s"))))));

            return x.ToString();
        }

        public string GetTicketQueryByCreatedDateRequest(DateTime dtUpdateTimeFrom, DateTime dtUpdateTimeTo)
        {
            XDocument x = new System.Xml.Linq.XDocument(
              new XDeclaration("1.0", "utf-8", "yes"),
              new XProcessingInstruction("webcretexml", "version=\"1.0\""),
              new XElement("WebcreteXML",
                  new XElement("WebcreteXMLMsgsRq",
                      new XElement("TicketQueryRq",
                          new XElement("FromCreatedDate", dtUpdateTimeFrom.ToString("s")),
                          new XElement("ToCreatedDate", dtUpdateTimeTo.ToString("s"))))));

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

        public string GetTicketQueryForOrderIDRequest(int OrderID)
        {
            XDocument x = new System.Xml.Linq.XDocument(
              new XDeclaration("1.0", "utf-8", "yes"),
              new XProcessingInstruction("webcretexml", "version=\"1.0\""),
              new XElement("WebcreteXML",
                  new XElement("WebcreteXMLMsgsRq",
                      new XElement("TicketQueryRq",
                           new XElement("OrderID", OrderID)))));

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

        public string GetTicketQueryWithFailOnOrderLockRequest(DateTime dtOrderFrom, DateTime dtOrderTo)
        {
            XDocument x = new System.Xml.Linq.XDocument(
              new XDeclaration("1.0", "utf-8", "yes"),
              new XProcessingInstruction("webcretexml", "version=\"1.0\""),
              new XElement("WebcreteXML",
                  new XElement("WebcreteXMLMsgsRq",
                      new XElement("TicketQueryRq",
                          new XElement("FailOnOrderLock", "True"),
                          new XElement("FromOrderDate", dtOrderFrom.ToShortDateString()),
                          new XElement("ToOrderDate", dtOrderTo.ToShortDateString())))));

            return x.ToString();
        }

        public string GetInvoiceQueryByInvoiceDateRequest(DateTime dtInvoiceFrom, DateTime dtInvoiceTo)
        {
            XDocument x = new System.Xml.Linq.XDocument(
              new XDeclaration("1.0", "utf-8", "yes"),
              new XProcessingInstruction("webcretexml", "version=\"1.0\""),
              new XElement("WebcreteXML",
                  new XElement("WebcreteXMLMsgsRq",
                      new XElement("InvoiceQueryRq",
                          new XElement("FromInvoiceDate", dtInvoiceFrom.ToShortDateString()),
                          new XElement("ToInvoiceDate", dtInvoiceTo.ToShortDateString())))));

            return x.ToString();
        }

        public string GetInvoiceQueryByCustomerCodeRequest(DateTime dtInvoiceFrom, DateTime dtInvoiceTo, string customerCode)
        {
            XDocument x = new System.Xml.Linq.XDocument(
              new XDeclaration("1.0", "utf-8", "yes"),
              new XProcessingInstruction("webcretexml", "version=\"1.0\""),
              new XElement("WebcreteXML",
                  new XElement("WebcreteXMLMsgsRq",
                      new XElement("InvoiceQueryRq",
                          new XElement("CustomerCode", customerCode),
                          new XElement("FromInvoiceDate", dtInvoiceFrom.ToShortDateString()),
                          new XElement("ToInvoiceDate", dtInvoiceTo.ToShortDateString())))));

            return x.ToString();
        }

        public string GetInvoiceQueryByCustomerCodeListOnlyRequest(DateTime dtInvoiceFrom, DateTime dtInvoiceTo, string customerCode)
        {
            XDocument x = new System.Xml.Linq.XDocument(
              new XDeclaration("1.0", "utf-8", "yes"),
              new XProcessingInstruction("webcretexml", "version=\"1.0\""),
              new XElement("WebcreteXML",
                  new XElement("WebcreteXMLMsgsRq",
                      new XElement("InvoiceQueryRq",
                          new XElement("ListOnly", "True"),
                          new XElement("CustomerCode", customerCode),
                          new XElement("FromInvoiceDate", dtInvoiceFrom.ToShortDateString()),
                          new XElement("ToInvoiceDate", dtInvoiceTo.ToShortDateString())))));

            return x.ToString();
        }

        
        public string GetInventoryTransactionQueryUsagesRequest(DateTime dtTransactionFrom, DateTime dtTransactionTo)
        {
            XDocument x = new System.Xml.Linq.XDocument(
              new XDeclaration("1.0", "utf-8", "yes"),
              new XProcessingInstruction("webcretexml", "version=\"1.0\""),
              new XElement("WebcreteXML",
                  new XElement("WebcreteXMLMsgsRq",
                      new XElement("InventoryTransactionQueryRq",                          
                          new XElement("TransactionType", "USAGE"),
                          new XElement("FromTransactionDate", dtTransactionFrom.ToShortDateString()),
                          new XElement("ToTransactionDate", dtTransactionTo.ToShortDateString())))));

            return x.ToString();
        }

        public string GetInventoryTransactionQueryQuantityAdjustmentsRequest(DateTime dtTransactionFrom, DateTime dtTransactionTo)
        {
            XDocument x = new System.Xml.Linq.XDocument(
              new XDeclaration("1.0", "utf-8", "yes"),
              new XProcessingInstruction("webcretexml", "version=\"1.0\""),
              new XElement("WebcreteXML",
                  new XElement("WebcreteXMLMsgsRq",
                      new XElement("InventoryTransactionQueryRq",                          
                          new XElement("TransactionType", "QUANTITYADJUSTMENT"),
                          new XElement("FromTransactionDate", dtTransactionFrom.ToShortDateString()),
                          new XElement("ToTransactionDate", dtTransactionTo.ToShortDateString())))));

            return x.ToString();
        }

        public string GetInventoryTransactionQueryRawMaterialReceiptsRequest(DateTime dtTransactionFrom, DateTime dtTransactionTo)
        {
            XDocument x = new System.Xml.Linq.XDocument(
              new XDeclaration("1.0", "utf-8", "yes"),
              new XProcessingInstruction("webcretexml", "version=\"1.0\""),
              new XElement("WebcreteXML",
                  new XElement("WebcreteXMLMsgsRq",
                      new XElement("InventoryTransactionQueryRq",                          
                          new XElement("TransactionType", "RAWMATERIALRECEIPT"),
                          new XElement("FromTransactionDate", dtTransactionFrom.ToShortDateString()),
                          new XElement("ToTransactionDate", dtTransactionTo.ToShortDateString())))));

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

        public string GeOrderQueryWithFailOnOrderLockRequest(DateTime dtOrderFrom, DateTime dtOrderTo)
        {
            XDocument x = new System.Xml.Linq.XDocument(
              new XDeclaration("1.0", "utf-8", "yes"),
              new XProcessingInstruction("webcretexml", "version=\"1.0\""),
              new XElement("WebcreteXML",
                  new XElement("WebcreteXMLMsgsRq",
                      new XElement("OrderQueryRq",
                          new XElement("FailOnOrderLock", "True"),
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

        public string GetItemUpdateRemoveLocationRequest(string code, string locationToBeRemoved)
        {
            XDocument x = new System.Xml.Linq.XDocument(
             new XDeclaration("1.0", "utf-8", "yes"),
             new XProcessingInstruction("webcretexml", "version=\"1.0\""),
             new XElement("WebcreteXML",
                 new XElement("WebcreteXMLMsgsRq",
                     new XElement("ItemUpdateRq",
                         new XElement("ItemUpdate",
                            new XElement("Code", code),
                            new XElement("Locations",
                                new XElement("Location",
                                    new XAttribute("Active","False"),
                                    new XElement("LocationCode", locationToBeRemoved)
                           )))))));

            return x.ToString();
        }
        

        public string GetTruckStatusQueryRequest()
        {
            XDocument x = new System.Xml.Linq.XDocument(
               new XDeclaration("1.0", "utf-8", "yes"),
               new XProcessingInstruction("webcretexml", "version=\"1.0\""),
               new XElement("WebcreteXML",
                   new XElement("WebcreteXMLMsgsRq",
                       new XElement("TruckStatusQueryRq", ""))));

            return x.ToString();
        }

        public string GetTruckStatusQueryByStatusUpdateTimeRequest(DateTime dtUpdateTimeFrom, DateTime dtUpdateTimeTo)
        {
            XDocument x = new System.Xml.Linq.XDocument(
               new XDeclaration("1.0", "utf-8", "yes"),
               new XProcessingInstruction("webcretexml", "version=\"1.0\""),
               new XElement("WebcreteXML",
                   new XElement("WebcreteXMLMsgsRq",
                       new XElement("TruckStatusQueryRq",
                          new XElement("FromStatusTimeStamp", dtUpdateTimeFrom.ToString("s")),
                          new XElement("ToStatusTimeStamp", dtUpdateTimeTo.ToString("s"))))));

            return x.ToString();
        }

        public string GetTruckStatusQueryByLocationUpdateTimeRequest(DateTime dtUpdateTimeFrom, DateTime dtUpdateTimeTo)
        {
            XDocument x = new System.Xml.Linq.XDocument(
               new XDeclaration("1.0", "utf-8", "yes"),
               new XProcessingInstruction("webcretexml", "version=\"1.0\""),
               new XElement("WebcreteXML",
                   new XElement("WebcreteXMLMsgsRq",
                       new XElement("TruckStatusQueryRq",
                          new XElement("FromLocationUpdateTime", dtUpdateTimeFrom.ToString("s")),
                          new XElement("ToLocationUpdateTime", dtUpdateTimeTo.ToString("s"))))));

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

        public string GetTruckStatusMessageQueryRequest()
        {
            XDocument x = new System.Xml.Linq.XDocument(
               new XDeclaration("1.0", "utf-8", "yes"),
               new XProcessingInstruction("webcretexml", "version=\"1.0\""),
               new XElement("WebcreteXML",
                   new XElement("WebcreteXMLMsgsRq",
                       new XElement("TruckStatusMessageQueryRq",
                        new XElement("LastTruckStatusMessageID", "0")))));

            return x.ToString();
        }

        public string GetTruckStatusMessageByStatusBeginTimeQueryRequest()
        {
            XDocument x = new System.Xml.Linq.XDocument(
               new XDeclaration("1.0", "utf-8", "yes"),
               new XProcessingInstruction("webcretexml", "version=\"1.0\""),
               new XElement("WebcreteXML",
                   new XElement("WebcreteXMLMsgsRq",
                       new XElement("TruckStatusMessageQueryRq",
                        new XElement("LastTruckStatusMessageID", "0"),
                        new XElement("FromStatusBeginTime", DateTime.Now.AddDays(-3).ToString("s")),
                        new XElement("ToStatusBeginTime", DateTime.Now.ToString("s"))))));

            return x.ToString();
        }

        public string GetTruckStatusMessageByUpdateTimeQueryRequest()
        {
            XDocument x = new System.Xml.Linq.XDocument(
               new XDeclaration("1.0", "utf-8", "yes"),
               new XProcessingInstruction("webcretexml", "version=\"1.0\""),
               new XElement("WebcreteXML",
                   new XElement("WebcreteXMLMsgsRq",
                       new XElement("TruckStatusMessageQueryRq",
                        new XElement("LastTruckStatusMessageID", "0"),
                        new XElement("FromUpdateTime", DateTime.Now.AddDays(-3).ToString("s")),
                        new XElement("ToUpdateTime", DateTime.Now.ToString("s"))))));

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

        public string GetTaxAuthorityQueryRequest()
        {
            XDocument x = new System.Xml.Linq.XDocument(
               new XDeclaration("1.0", "utf-8", "yes"),
               new XProcessingInstruction("webcretexml", "version=\"1.0\""),
               new XElement("WebcreteXML",
                   new XElement("WebcreteXMLMsgsRq",
                       new XElement("TaxAuthorityQueryRq", ""))));

            return x.ToString();
        }

        public string GetTaxAuthorityUpdateRequest()
        {
            XDocument x = new System.Xml.Linq.XDocument(
               new XDeclaration("1.0", "utf-8", "yes"),
               new XProcessingInstruction("webcretexml", "version=\"1.0\""),
               new XElement("WebcreteXML",
                   new XElement("WebcreteXMLMsgsRq",
                       new XElement("TaxAuthorityUpdateRq",
                            new XElement("TaxAuthorityUpdate",
                                new XElement("Code","S"),
                                new XElement("Description", "State Tax"),
                                new XElement("ShortDescription", "State Tax"),
                                new XElement("TaxBasedOn", "1"),
                                new XElement("PointOfTaxation", "1"),
                                new XElement("AllowReciprocation", "False"))))));

            return x.ToString();
        }

        public string GetTaxLocationQueryRequest()
        {
            XDocument x = new System.Xml.Linq.XDocument(
               new XDeclaration("1.0", "utf-8", "yes"),
               new XProcessingInstruction("webcretexml", "version=\"1.0\""),
               new XElement("WebcreteXML",
                   new XElement("WebcreteXMLMsgsRq",
                       new XElement("TaxLocationQueryRq", ""))));

            return x.ToString();
        }

        public string GetTaxLocationUpdateRequest()
        {
            XDocument x = new System.Xml.Linq.XDocument(
               new XDeclaration("1.0", "utf-8", "yes"),
               new XProcessingInstruction("webcretexml", "version=\"1.0\""),
               new XElement("WebcreteXML",
                   new XElement("WebcreteXMLMsgsRq",
                       new XElement("TaxLocationUpdateRq",
                            new XElement("TaxLocationUpdate",
                                new XElement("Code", "1"),
                                new XElement("Description", "NY State"),
                                new XElement("ShortDescription", "NY State"),
                                new XElement("TaxAuthorityCode", "S"),
                                new XElement("CurrentRate", "8.675"),
                                new XElement("EffectiveDate", "1/1/2020"),
                                new XElement("PreviousRate", "6.5")
                            )))));

            return x.ToString();
        }
        public string GetTaxCodeQueryRequest()
        {
            XDocument x = new System.Xml.Linq.XDocument(
               new XDeclaration("1.0", "utf-8", "yes"),
               new XProcessingInstruction("webcretexml", "version=\"1.0\""),
               new XElement("WebcreteXML",
                   new XElement("WebcreteXMLMsgsRq",
                       new XElement("TaxCodeQueryRq", ""))));

            return x.ToString();
        }

        public string GetTaxCodeUpdateRequest()
        {
            XDocument x = new System.Xml.Linq.XDocument(
               new XDeclaration("1.0", "utf-8", "yes"),
               new XProcessingInstruction("webcretexml", "version=\"1.0\""),
               new XElement("WebcreteXML",
                   new XElement("WebcreteXMLMsgsRq",
                       new XElement("TaxCodeUpdateRq",
                            new XElement("TaxCodeUpdate",
                                new XElement("Code", "1"),
                                new XElement("Description", "NY State"),
                                new XElement("ShortDescription", "NY State"),                                
                                new XElement("TaxLocations",
                                        new XElement("TaxLocation",
                                                new XElement("TaxLocationCode", "1"))))))));

            return x.ToString();
        }

        public string GetOrderUpdateRequest(int orderID, bool invoiced)
        {
            XDocument x = new System.Xml.Linq.XDocument(
               new XDeclaration("1.0", "utf-8", "yes"),
               new XProcessingInstruction("webcretexml", "version=\"1.0\""),
               new XElement("WebcreteXML",
                   new XElement("WebcreteXMLMsgsRq",
                       new XElement("OrderUpdateRq",
                            new XElement("OrderUpdate",
                                new XElement("ID", orderID),                                
                                new XElement("Invoiced", invoiced))))));

            return x.ToString();
        }

        public string GetTicketUpdateRequest(int ticketId, bool invoiced)
        {
            XDocument x = new System.Xml.Linq.XDocument(
               new XDeclaration("1.0", "utf-8", "yes"),
               new XProcessingInstruction("webcretexml", "version=\"1.0\""),
               new XElement("WebcreteXML",
                   new XElement("WebcreteXMLMsgsRq",
                       new XElement("TicketUpdateRq",
                            new XElement("TicketUpdate",
                                new XElement("ID", ticketId),
                                new XElement("Invoiced", invoiced))))));

            return x.ToString();
        }

        public string GetBatchInventoryQueryCurrentBalanceRequest()
        {
            XDocument x = new System.Xml.Linq.XDocument(
              new XDeclaration("1.0", "utf-8", "yes"),
              new XProcessingInstruction("webcretexml", "version=\"1.0\""),
              new XElement("WebcreteXML",
                  new XElement("WebcreteXMLMsgsRq",
                      new XElement("BatchInventoryQueryRq"))));

            return x.ToString();
        }

        public string GetBatchInventoryQueryShipmentsRequest(DateTime dtTransactionFrom, DateTime dtTransactionTo)
        {
            XDocument x = new System.Xml.Linq.XDocument(
              new XDeclaration("1.0", "utf-8", "yes"),
              new XProcessingInstruction("webcretexml", "version=\"1.0\""),
              new XElement("WebcreteXML",
                  new XElement("WebcreteXMLMsgsRq",
                      new XElement("BatchInventoryQueryRq",
                          new XElement("TransactionType", "SHIPMENT"),
                          new XElement("FromTransactionDate", dtTransactionFrom.ToShortDateString()),
                          new XElement("ToTransactionDate", dtTransactionTo.ToShortDateString())))));

            return x.ToString();
        }

        public string GetBatchInventoryQueryShipmentsForPlantItemRequest(DateTime dtTransactionFrom, DateTime dtTransactionTo, string plantCode, string itemCode)
        {
            XDocument x = new System.Xml.Linq.XDocument(
              new XDeclaration("1.0", "utf-8", "yes"),
              new XProcessingInstruction("webcretexml", "version=\"1.0\""),
              new XElement("WebcreteXML",
                  new XElement("WebcreteXMLMsgsRq",
                      new XElement("BatchInventoryQueryRq",
                          new XElement("TransactionType", "SHIPMENT"),
                          new XElement("PlantCode", plantCode),
                          new XElement("ItemCode", itemCode),
                          new XElement("FromTransactionDate", dtTransactionFrom.ToShortDateString()),
                          new XElement("ToTransactionDate", dtTransactionTo.ToShortDateString())))));

            return x.ToString();
        }

        public string GetBatchInventoryQueryUsagesRequest(DateTime dtTransactionFrom, DateTime dtTransactionTo)
        {
            XDocument x = new System.Xml.Linq.XDocument(
              new XDeclaration("1.0", "utf-8", "yes"),
              new XProcessingInstruction("webcretexml", "version=\"1.0\""),
              new XElement("WebcreteXML",
                  new XElement("WebcreteXMLMsgsRq",
                      new XElement("BatchInventoryQueryRq",
                          new XElement("TransactionType", "USAGE"),
                          new XElement("FromTransactionDate", dtTransactionFrom.ToShortDateString()),
                          new XElement("ToTransactionDate", dtTransactionTo.ToShortDateString())))));

            return x.ToString();
        }

        public string GetBatchInventoryQueryAdjustmentsRequest(DateTime dtTransactionFrom, DateTime dtTransactionTo)
        {
            XDocument x = new System.Xml.Linq.XDocument(
              new XDeclaration("1.0", "utf-8", "yes"),
              new XProcessingInstruction("webcretexml", "version=\"1.0\""),
              new XElement("WebcreteXML",
                  new XElement("WebcreteXMLMsgsRq",
                      new XElement("BatchInventoryQueryRq",
                          new XElement("TransactionType", "ADJUSTMENT"),
                          new XElement("FromTransactionDate", dtTransactionFrom.ToShortDateString()),
                          new XElement("ToTransactionDate", dtTransactionTo.ToShortDateString())))));

            return x.ToString();
        }

        public string GetBatchInventoryQueryReconciliationsRequest(DateTime dtTransactionFrom, DateTime dtTransactionTo)
        {
            XDocument x = new System.Xml.Linq.XDocument(
              new XDeclaration("1.0", "utf-8", "yes"),
              new XProcessingInstruction("webcretexml", "version=\"1.0\""),
              new XElement("WebcreteXML",
                  new XElement("WebcreteXMLMsgsRq",
                      new XElement("BatchInventoryQueryRq",
                          new XElement("TransactionType", "RECONCILIATION"),
                          new XElement("FromTransactionDate", dtTransactionFrom.ToShortDateString()),
                          new XElement("ToTransactionDate", dtTransactionTo.ToShortDateString())))));

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
                case "CustomerQuery(IncludeSundryCharges)":
                    textBoxRequest.Text = IndentXMLString(GetCustomerIncludeSundryChargesQueryRequest());
                    break;
                case "CustomerQuery(IncludeUserDefinedFields)":
                    textBoxRequest.Text = IndentXMLString(GetCustomerIncludeUserDefinedFieldsQueryRequest());
                    break;
                case "OrderQuery":
                    textBoxRequest.Text = IndentXMLString(GeOrderQueryRequest(DateTime.Now, DateTime.Now));
                    break;
                case "OrderQuery(FailOnOrderLock)":
                    textBoxRequest.Text = IndentXMLString(GeOrderQueryWithFailOnOrderLockRequest(DateTime.Now, DateTime.Now));
                    break;
                case "OrderQuery(OrderUpdate)":
                    textBoxRequest.Text = IndentXMLString(GeOrderUpdateQueryRequest(DateTime.Now.AddMinutes(-5), DateTime.Now));
                    break;
                case "TicketQuery":
                    textBoxRequest.Text = IndentXMLString(GetTicketQueryRequest(DateTime.Now,DateTime.Now));
                    break;
                case "TicketQuery(Reviewed)":
                    textBoxRequest.Text = IndentXMLString(GetReviewedTicketQueryRequest(DateTime.Now, DateTime.Now));
                    break;
                case "TicketQuery(WithUserDefinedFields)":
                    textBoxRequest.Text = IndentXMLString(GetTicketQueryRequestWithUserDefinedFields(DateTime.Now, DateTime.Now));
                    break; 
                case "TicketQuery(WithOrderUserDefinedFields)":
                    textBoxRequest.Text = IndentXMLString(GetTicketQueryRequestWithOrderUserDefinedFields(DateTime.Now, DateTime.Now));
                    break;
                case "TicketQuery(WithCustomerUserDefinedFields)":
                    textBoxRequest.Text = IndentXMLString(GetTicketQueryRequestWithCustomerUserDefinedFields(DateTime.Now, DateTime.Now));
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
                case "TicketQuery(OrderUpdateTime)":
                    textBoxRequest.Text = IndentXMLString(GetTicketQueryByOrderUpdateTimeRequest(DateTime.Now.AddMinutes(-1), DateTime.Now));
                    break;
                    break;
                case "TicketQuery(TicketTime)":
                    textBoxRequest.Text = IndentXMLString(GetTicketQueryByTicketTimeRequest(DateTime.Now.AddMinutes(-1), DateTime.Now));
                    break;
                case "TicketQuery(CreatedDate)":
                    textBoxRequest.Text = IndentXMLString(GetTicketQueryByCreatedDateRequest(DateTime.Now.AddMinutes(-1), DateTime.Now));
                    break;
                case "TicketQuery(SortDesc)":
                    textBoxRequest.Text = IndentXMLString(GetTicketQueryDescRequest(DateTime.Now, DateTime.Now));
                    break;
                case "TicketQuery(WithBatchWeightsOnly)":
                    textBoxRequest.Text = IndentXMLString(GetTicketQueryWithBatchWeightsOnlyRequest(DateTime.Now, DateTime.Now));
                    break;
                case "TicketQuery(OrderID)":
                    textBoxRequest.Text = IndentXMLString(GetTicketQueryForOrderIDRequest(54604));
                    break;
                case "TicketQuery(FailOnOrderLock)":
                    textBoxRequest.Text = IndentXMLString(GetTicketQueryWithFailOnOrderLockRequest(DateTime.Now, DateTime.Now));
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
                case "ItemQuery(IncludeTaxOverride)":
                    textBoxRequest.Text = IndentXMLString(GetItemIncludeTaxOverrideQueryRequest());
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
                case "ProjectQuery(IncludeProduct)":
                    textBoxRequest.Text = IndentXMLString(GetProjectIncludeProductQueryRequest());
                    break;
                case "ProjectQuery(IncludeSundryCharges)":
                    textBoxRequest.Text = IndentXMLString(GetProjectIncludeSundryChargesQueryRequest());
                    break;
                case "ProjectQuery(IncludeUserDefinedFields)":
                    textBoxRequest.Text = IndentXMLString(GetProjectUserDefinedFieldsQueryRequest());
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
                case "ItemUpdate(Remove Location)":
                    textBoxRequest.Text = IndentXMLString(GetItemUpdateRemoveLocationRequest("4011", "01"));
                    break;
                case "TruckStatusQuery":
                    textBoxRequest.Text = IndentXMLString(GetTruckStatusQueryRequest());
                    break;
                case "TruckStatusQuery(StatusUpdateTime)":
                    textBoxRequest.Text = IndentXMLString(GetTruckStatusQueryByStatusUpdateTimeRequest(DateTime.Now.AddMinutes(-1), DateTime.Now));
                    break;
                case "TruckStatusQuery(LocationUpdateTime)":
                    textBoxRequest.Text = IndentXMLString(GetTruckStatusQueryByLocationUpdateTimeRequest(DateTime.Now.AddMinutes(-1), DateTime.Now));
                    break;
                case "TruckStatusUpdate":
                    textBoxRequest.Text = IndentXMLString(GetTruckStatusUpdateRequest("1", "32", "TOJOB", DateTime.Now));
                    break;
                case "TruckGpsUpdate":
                    textBoxRequest.Text = IndentXMLString(GetTruckGpsUpdateRequest("1", "32", "41.303603", "-73.933310", DateTime.Now));
                    break;
                case "TruckStatusMessageQuery":
                    textBoxRequest.Text = IndentXMLString(GetTruckStatusMessageQueryRequest());
                    break;
                case "TruckStatusMessageQuery(StatusBeginTime)":
                    textBoxRequest.Text = IndentXMLString(GetTruckStatusMessageByStatusBeginTimeQueryRequest());
                    break;
                case "TruckStatusMessageQuery(UpdateTime)":
                    textBoxRequest.Text = IndentXMLString(GetTruckStatusMessageByUpdateTimeQueryRequest());
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
                case "TruckUpdate":
                    textBoxRequest.Text = IndentXMLString(GetTruckUpdateRequest("1","Truck 1","1"));
                    break;
                case "TruckQuery(StatusUpdateTime)":
                    textBoxRequest.Text = IndentXMLString(GetTruckQueryByStatusUpdateTimeRequest(DateTime.Now.AddMinutes(-1), DateTime.Now));
                    break;
                case "TruckQuery(LocationUpdateTime)":
                    textBoxRequest.Text = IndentXMLString(GetTruckQueryByLocationUpdateTimeRequest(DateTime.Now.AddMinutes(-1), DateTime.Now));
                    break;
                case "EmployeeQuery":
                    textBoxRequest.Text = IndentXMLString(GetEmployeeQueryRequest());
                    break;
                case "EmployeeUpdate":
                    textBoxRequest.Text = IndentXMLString(GetEmployeeUpdateRequest("2387","Mike Tyson","Driver"));
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
                case "TaxAuthorityQuery":
                    textBoxRequest.Text = IndentXMLString(GetTaxAuthorityQueryRequest());
                    break;
                case "TaxAuthorityUpdate":
                    textBoxRequest.Text = IndentXMLString(GetTaxAuthorityUpdateRequest());
                    break;
                case "TaxLocationQuery":
                    textBoxRequest.Text = IndentXMLString(GetTaxLocationQueryRequest());
                    break;
                case "TaxLocationUpdate":
                    textBoxRequest.Text = IndentXMLString(GetTaxLocationUpdateRequest());
                    break;
                case "TaxCodeQuery":
                    textBoxRequest.Text = IndentXMLString(GetTaxCodeQueryRequest());
                    break;
                case "TaxCodeUpdate":
                    textBoxRequest.Text = IndentXMLString(GetTaxCodeUpdateRequest());
                    break;
                case "ItemDelete":
                    textBoxRequest.Text = IndentXMLString(GetItemDeleteRequest("030-4"));
                    break;
                case "JobQuery":
                    textBoxRequest.Text = IndentXMLString(GetJobQueryRequest());
                    break;
                case "QuoteQuery":
                    textBoxRequest.Text = IndentXMLString(GetQuoteQueryRequest());
                    break;
                case "OrderUpdate":
                    textBoxRequest.Text = IndentXMLString(GetOrderUpdateRequest(61278,true));
                    break;
                case "TicketUpdate":
                    textBoxRequest.Text = IndentXMLString(GetTicketUpdateRequest(100, true));
                    break;
                case "InvoiceQueryByInvoiceDate":
                    textBoxRequest.Text = IndentXMLString(GetInvoiceQueryByInvoiceDateRequest(DateTime.Now.AddDays(-7), DateTime.Now));
                    break;
                case "InvoiceQueryByCustomerCode":
                    textBoxRequest.Text = IndentXMLString(GetInvoiceQueryByCustomerCodeRequest(DateTime.Now.AddDays(-30), DateTime.Now, "CAL1074"));
                    break;
                case "InvoiceQueryByCustomerCodeListOnly":
                    textBoxRequest.Text = IndentXMLString(GetInvoiceQueryByCustomerCodeListOnlyRequest(DateTime.Now.AddDays(-30), DateTime.Now, "CAL1074"));
                    break;
                case "InventoryTransactionQuery(Usages)":
                    textBoxRequest.Text = IndentXMLString(GetInventoryTransactionQueryUsagesRequest(DateTime.Now.AddDays(-30), DateTime.Now));
                    break;
                case "InventoryTransactionQuery(RawMaterialReceipt)":
                    textBoxRequest.Text = IndentXMLString(GetInventoryTransactionQueryRawMaterialReceiptsRequest(DateTime.Now.AddDays(-30), DateTime.Now));
                    break;
                case "InventoryTransactionQuery(QuantityAdjustments)":
                    textBoxRequest.Text = IndentXMLString(GetInventoryTransactionQueryQuantityAdjustmentsRequest(DateTime.Now.AddDays(-30), DateTime.Now));
                    break;
                case "BatchInventoryQuery(CurrentBalance)":
                    textBoxRequest.Text = IndentXMLString(GetBatchInventoryQueryCurrentBalanceRequest());
                    break;
                case "BatchInventoryQuery(Shipments)":
                    textBoxRequest.Text = IndentXMLString(GetBatchInventoryQueryShipmentsRequest(DateTime.Now.AddDays(-30), DateTime.Now));
                    break;
                case "BatchInventoryQuery(Usages)":
                    textBoxRequest.Text = IndentXMLString(GetBatchInventoryQueryUsagesRequest(DateTime.Now.AddDays(-30), DateTime.Now));
                    break;
                case "BatchInventoryQuery(Adjustments)":
                    textBoxRequest.Text = IndentXMLString(GetBatchInventoryQueryAdjustmentsRequest(DateTime.Now.AddDays(-30), DateTime.Now));
                    break;
                case "BatchInventoryQuery(Reconciliations)":
                    textBoxRequest.Text = IndentXMLString(GetBatchInventoryQueryReconciliationsRequest(DateTime.Now.AddDays(-30), DateTime.Now));
                    break;
                case "BatchInventoryQuery(ShipmentsForPlantItem)":
                    textBoxRequest.Text = IndentXMLString(GetBatchInventoryQueryShipmentsForPlantItemRequest(DateTime.Now.AddDays(-30), DateTime.Now, "1", "CEMENT" ));
                    break;
                case "BatchTicketQuery":
                    textBoxRequest.Text = IndentXMLString(GetBatchTicketQueryRequest(DateTime.Now, DateTime.Now, "1340", "16377032"));
                    break;
                case "ReasonCodeQuery":
                    textBoxRequest.Text = IndentXMLString(GetReasonCodeQueryRequest());
                    break;
                case "SalesAnalysisCodeQuery":
                    textBoxRequest.Text = IndentXMLString(GetSalesAnalysisCodeQueryRequest());
                    break;
                case "HaulerQuery":
                    textBoxRequest.Text = IndentXMLString(GetHaulerQueryRequest());
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
