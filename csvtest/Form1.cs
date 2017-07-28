using LINQtoCSV;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csvtest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // todo
            // 载入文件并查询
            CsvFileDescription inputFileDescription = new CsvFileDescription
            {
                SeparatorChar = ',',
                FirstLineHasColumnNames = true
            };
            CsvContext cc = new CsvContext();
            IEnumerable<Patient> products =
                cc.Read<Patient>(@"d:/wenyunlong/Documents/Visual Studio 2015/Projects/csvtest/csvtest/patient.csv", inputFileDescription);
            // Data is now available via variable products.
            //var productsByName =
            //    from p in products
            //    orderby p.ID
            //    select new { p.ID, p.Name, p.age, p.sex, p.bed, p.Description };
            // or ...
            Patient result = new Patient();
            foreach (Patient item in products) {
                if(item.ID == inputID.Text)
                {
                    result = item;
                }
            }
            
            resultBox.Text = "ID"+ "\t"+"名字"+ "\t"+"性别"+ "\t"+"床号" + "\t" + "医院"+"\n"+result.ID + "\t"+ result.Name + "\t" + result.sex + "\t" + result.bed + "\t" + result.hospital;
        }

    }


public class Patient
    {
        [CsvColumn(FieldIndex = 1)]
        public string ID { get; set; }
        [CsvColumn(FieldIndex = 2)]
        public string Name { get; set; }
        [CsvColumn(FieldIndex = 3)]
        public string age { get; set; }
        [CsvColumn(FieldIndex = 4)]
        public string sex { get; set; }
        [CsvColumn(FieldIndex = 5)]
        public string bed { get; set; }
        [CsvColumn(FieldIndex = 6)]
        public string Description { get; set; }
        [CsvColumn(FieldIndex = 7)]
        public string hospital { get; set; }
    }
}