using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace GetTag
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();

            comboBox1.Items.Add("innerhtml");
            comboBox1.Items.Add("outerhtml");
            comboBox1.Items.Add("innertext");
            comboBox1.Items.Add("outertext");
            comboBox1.SelectedIndex = 1;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        /*
        @para strings adress (url), returnType (inner/outer/text/html), Tag (html tag), Id (html idname), Class (html ClassName), Attribute (Own Attribute), Value (Own Attribute Value)
        @return String of found parameters
        Send in empty strings on parameters not used and they will be skipped!
        */
        private string getData(string adress, string returnType, string Tag, string Id, string Class, string Attribute, string Value)
        {
            WebBrowser wb = new WebBrowser();

            wb.ScriptErrorsSuppressed = true;

            wb.Navigate(adress);

            while (wb.ReadyState != WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
            }

            wb.Stop();

            // look for our data
            HtmlElementCollection AllTagElems = wb.Document.All;
 
            string RichVariable = "";
            switch (returnType)
            {
                case "innerhtml":

                    // all null
                    if (Tag.Length == 0 && Id.Length == 0 && Class.Length == 0 && Attribute.Length == 0 && Value.Length == 0)
                    {
                        return wb.Document.Body.InnerHtml;
                    }

                    foreach (HtmlElement elem in AllTagElems)
                    {
                        if (Tag.Length != 0)
                        {
                            if (elem.TagName.Contains(Tag)) RichVariable += elem.InnerHtml;
                        }
                        else if (elem.Id != null)
                        {
                            if (Id.Length > 0) if (elem.Id.Contains(Id)) RichVariable += elem.InnerHtml;

                        }
                        else if (Class.Length != 0)
                        {
                            if (elem.GetAttribute("className").Contains(Class)) RichVariable += elem.InnerHtml;

                        }
                        else if (Attribute.Length != 0 && Value.Length != 0)
                        {
                            if (elem.GetAttribute(Attribute).Contains(Value)) RichVariable += elem.InnerHtml;
                        }
                    }
                    break;

                case "outerhtml":
                  
                    // all null
                    if (Tag.Length == 0 && Id.Length == 0 && Class.Length == 0 && Attribute.Length == 0 && Value.Length == 0)
                    {
                     
                        return wb.Document.Body.OuterHtml;
                    }
                
                    foreach (HtmlElement elem in AllTagElems)
                    {
                       
                        if (Tag.Length != 0)
                        {
                            if (elem.TagName.Contains(Tag)) {   RichVariable += elem.OuterHtml; }
                        }
                        else if (elem.Id != null)
                        {

                            if (Id.Length > 0) if (elem.Id.Contains(Id)) {  RichVariable += elem.OuterHtml; }

                        }
                        else if (Class.Length != 0 )
                        {
                            
                            if (elem.GetAttribute("classname").ToString().Contains(Class)) { RichVariable += elem.OuterHtml;  }

                        }
                        else if (Attribute.Length != 0 && Value.Length != 0)
                        {
                            if (elem.GetAttribute(Attribute).Contains(Value))  RichVariable += elem.OuterHtml;
                        }
                    }
                    break;

                case "innertext":

                    // all null
                    if (Tag.Length == 0 && Id.Length == 0 && Class.Length == 0 && Attribute.Length == 0 && Value.Length == 0)
                    {
                       
                        return wb.Document.Body.InnerText;
                    }

                    foreach (HtmlElement elem in AllTagElems)
                    {
                        if (Tag.Length != 0)
                        {
                            if (elem.TagName.Contains(Tag)) RichVariable += elem.InnerText;
                        }
                        else if (elem.Id != null)
                        {
                            if (Id.Length > 0) if (elem.Id.Contains(Id)) RichVariable += elem.InnerText;

                        }
                        else if (Class.Length != 0)
                        {
                            if (elem.GetAttribute("className").Contains(Class))  RichVariable += elem.InnerText;

                        }
                        else if (Attribute.Length != 0 && Value.Length != 0)
                        {
                            if (elem.GetAttribute(Attribute).Contains(Value)) RichVariable += elem.InnerText;
                        }
                    }

                    break;

                case "outertext":
                  
                    // all null
                    if (Tag.Length == 0 && Id.Length == 0 && Class.Length == 0 && Attribute.Length == 0 && Value.Length == 0)
                    {
                        return wb.Document.Body.OuterText;
                    }

                    foreach (HtmlElement elem in AllTagElems)
                    {

                        if (Tag.Length != 0)
                        {
                            if (elem.TagName.Contains(Tag)) RichVariable += elem.OuterText;
                        }
                        else if (elem.Id != null)
                        {
                            if (Id.Length > 0) if (elem.Id.Contains(Id)) RichVariable += elem.OuterText;

                        }
                        else if (Class.Length != 0)
                        {
                            if (elem.GetAttribute("className").Contains(Class)) RichVariable += elem.OuterText;

                        }
                        else if (Attribute.Length != 0 && Value.Length != 0)
                        {
                            if (elem.GetAttribute(Attribute).Contains(Value)) RichVariable += elem.OuterText;
                        }
                    }
                    break;
            }
          
            return RichVariable;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";

            richTextBox1.Text = getData(textBox1.Text, comboBox1.Text, textBox2.Text, textBox4.Text, textBox3.Text, textBox5.Text, textBox6.Text);
          


        }
    }
}
