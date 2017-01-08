﻿using System;
//using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using WindowsElnVatView.model;
using System.Collections.Generic;

namespace WindowsElnVatView
{
    public partial class Form1 : Form
    {
        //public Stream myStream { get; private set; }
        public string fileName { get; set; }
        public Form1()
        {
            InitializeComponent();

        }
        private void parseXml(Stream openFile)//-Stream loadFileXml
        {
            XmlDocument newDocumentXml = new XmlDocument();
            newDocumentXml.Load(openFile);
            var formElnVat = new General();
            var listRoster = new List<ModelXMLParsePosition>();
            formElnVat = XMLParsers.ParseElnVatFromXMLDocument(newDocumentXml);
            listRoster = XMLParsers.parseItemRoster(newDocumentXml);
            
            //разносим по форме general
            
            maskedTextBox4.Text = formElnVat.number;
            maskedTextBox1.Text = formElnVat.dateIssuance;
            maskedTextBox2.Text = formElnVat.dateTransaction;
            if (formElnVat.documentType == "ORIGINAL") { originalCheckBox1.Checked = true; }

            //разносим по форме provider
            if (formElnVat.providerStatus == "SELLER") { checkBox1.Checked = true; }
            checkBox2.Checked = formElnVat.dependentPersonProvider;
            checkBox3.Checked = formElnVat.residentsOfOffshoreProvider;
            checkBox4.Checked = formElnVat.specialDealGoodsProvider;
            checkBox5.Checked = formElnVat.bigCompanyProvider;
            textBox1.Text = formElnVat.countryCodeProvider;
            textBox2.Text = formElnVat.unpProvider;
            textBox3.Text = formElnVat.nameProvider;
            textBox4.Text = formElnVat.addressProvider;

            //разносим по форме receiver
            if (formElnVat.recipientStatus == "CUSTOMER") { checkBox6.Checked = true; }
            checkBox7.Checked = formElnVat.dependentPersonRecipient;
            checkBox8.Checked = formElnVat.residentsOfOffshoreRecipient;
            checkBox9.Checked = formElnVat.specialDealGoodsRecipient;
            checkBox10.Checked = formElnVat.bigCompanyRecipient;
            textBox8.Text = formElnVat.countryCodeRecipient;

            var recipient = new parseNalogGovBy();
            textBox7.Text = formElnVat.unpRecipient;
            recipient = parseNalogGovBy.getXmlFromNalogGovBy(formElnVat.unpRecipient);
            textBox6.Text = recipient.nameNalogGovBy;
            //не у всех забит адрес,если адреса нету,оставляем старый
            if(recipient.adressNalogGovBy == "") { textBox5.Text = formElnVat.addressRecipient; }
            else { textBox5.Text = recipient.adressNalogGovBy; }
            

            //разносим по форме deliveryCondition
            textBox9.Text = formElnVat.numberDeliveryCondition;
            maskedTextBox3.Text = formElnVat.dateDeliveryCondition;

            //разносим по форме roster
            label29.Text = formElnVat.totalVatAttrib;
            label28.Text = formElnVat.totalCostAttrib;
            label27.Text = formElnVat.totalCostVatAttrib;
            label31.Text = formElnVat.totalExciseAttrib;
            //заполняю элемент таблицы
            dataGridView1.DataSource = listRoster;
            //добавляю названия столбцам
            dataGridView1.Columns[0].HeaderText = "Название";
            dataGridView1.Columns[1].HeaderText = "№";
            dataGridView1.Columns[2].HeaderText = "Количество";
            dataGridView1.Columns[2].HeaderText = "Количество";
            dataGridView1.Columns[3].HeaderText = "Цена 1 шт.";
            dataGridView1.Columns[4].HeaderText = "Цена без НДС";
            dataGridView1.Columns[5].HeaderText = "Акциз";
            dataGridView1.Columns[6].HeaderText = "% НДС";
            dataGridView1.Columns[7].HeaderText = "Тип";
            dataGridView1.Columns[8].HeaderText = "Кол-во НДС";
            dataGridView1.Columns[9].HeaderText = "Цена с НДС";
        }

        private General saveDateFormToModelXML()
        {
            var XMlDateForm = new General();
            //заполняем модель из таблицы
            XMlDateForm.number = maskedTextBox4.Text;
            XMlDateForm.dateIssuance = maskedTextBox1.Text;
            XMlDateForm.dateTransaction = maskedTextBox2.Text;
            if (originalCheckBox1.Checked == true) { XMlDateForm.documentType = "ORIGINAL"; }

            if (checkBox1.Checked == true) { XMlDateForm.providerStatus = "SELLER"; }
            XMlDateForm.dependentPersonProvider = checkBox2.Checked;
            XMlDateForm.residentsOfOffshoreProvider = checkBox3.Checked;
            XMlDateForm.specialDealGoodsProvider = checkBox4.Checked;
            XMlDateForm.bigCompanyProvider = checkBox5.Checked;
            XMlDateForm.countryCodeProvider = textBox1.Text;
            XMlDateForm.unpProvider = textBox2.Text;
            XMlDateForm.nameProvider = textBox3.Text;
            XMlDateForm.addressProvider = textBox4.Text;

            if (checkBox6.Checked == true) { XMlDateForm.recipientStatus = "CUSTOMER"; }
            XMlDateForm.dependentPersonRecipient = checkBox10.Checked;
            XMlDateForm.residentsOfOffshoreRecipient = checkBox9.Checked;
            XMlDateForm.specialDealGoodsRecipient = checkBox8.Checked;
            XMlDateForm.bigCompanyRecipient = checkBox7.Checked;
            XMlDateForm.countryCodeRecipient = textBox8.Text;
            XMlDateForm.unpRecipient = textBox7.Text;
            XMlDateForm.nameRecipient = textBox6.Text;
            XMlDateForm.addressRecipient = textBox5.Text;

            XMlDateForm.numberDeliveryCondition = textBox9.Text;
            XMlDateForm.dateDeliveryCondition = maskedTextBox3.Text;
            
            XMlDateForm.totalVatAttrib = label29.Text;
            XMlDateForm.totalCostAttrib = label28.Text;
            XMlDateForm.totalCostVatAttrib = label27.Text;
            XMlDateForm.totalExciseAttrib = label31.Text;

            
            return XMlDateForm;
            }

        private List<ModelXMLParsePosition> saveDateFromTable()
        {
            var listRewriteModelFromTable = new List<ModelXMLParsePosition>();
            var listRoster = new List<ModelXMLParsePosition> { };
            //int i = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                var roster = new ModelXMLParsePosition();
                roster = row.DataBoundItem as ModelXMLParsePosition;
                listRewriteModelFromTable.Add(roster);
            }
            return listRewriteModelFromTable;
        }
        //Открываю файл на чтение
        private void button3_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\vbs\\in\\";
            openFileDialog1.Filter = "XML file (*.xml)|*.xml";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            fileName = openFileDialog1.FileName;
                            parseXml(myStream);
                            
                            label33.Text = "Документ редактируется";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error:Не удалось прочитать файл. " + ex.Message);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] s = Environment.GetCommandLineArgs();
            if(s.Length > 1) {
                Stream openFileAssoc = null;
                fileName = s[1];
                openFileAssoc = File.Open(fileName,FileMode.Open);
                parseXml(openFileAssoc);
                openFileAssoc.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
             try {
            var newItemRoster = new List<ModelXMLParsePosition>();
            
                
                General insertDateForm = saveDateFormToModelXML();
                newItemRoster = saveDateFromTable();
                generateNewXMLfile.createNewFileXML(insertDateForm,fileName,newItemRoster);
                label34.Text = "Файл сохранен,можно открыть следующий";
            }
            catch(Exception errSave)
            {
                label34.Text = "Файл не сохранен,что то не так."+ errSave.Source;
            }
            
        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            var recipient = new parseNalogGovBy();
            string unp = textBox7.Text;
            recipient = parseNalogGovBy.getXmlFromNalogGovBy(unp);
            textBox6.Text = recipient.nameNalogGovBy;
            textBox5.Text = recipient.adressNalogGovBy;
        }
    }
}
