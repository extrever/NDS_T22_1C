using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NDS_T22_1C
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();                                    
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region "ТОВ САВ-Д" + "Без розн.,опт,и-нет"
            if (comboBox1.Text == "ТОВ САВ-Д" && comboBox3.Text == "Без розн.,опт,и-нет")
            {
                if (comboBox4.Text == "Заполнено")
                {
                    //создаём основной грид
                    dataGridView1.ColumnCount = 6;
                    dataGridView1.Columns[0].Name = "Магазин";
                    dataGridView1.Columns[1].Name = "Сумма НДС в Т22";
                    dataGridView1.Columns[2].Name = "Сумма НДС в 1С";
                    dataGridView1.Columns[3].Name = "Расхождение";
                    dataGridView1.Columns[4].Name = "Расхождение фикс.";
                    dataGridView1.Columns[5].Name = "Расхождение врем.";

                    DataGridViewComboBoxColumn col = new DataGridViewComboBoxColumn();
                    col.Items.AddRange("Да", "Нет");
                    dataGridView1.Columns.Add(col);
                    dataGridView1.Columns[6].Name = "Сверено";

                    DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
                    dataGridView1.Columns.Add(col1);
                    dataGridView1.Columns[7].Name = "Кто сверил";

                    DataGridViewCheckBoxColumn col2 = new DataGridViewCheckBoxColumn();
                    dataGridView1.Columns.Add(col2);
                    dataGridView1.Columns[8].Name = "Создать док.";

                    string[,] masterGridData = new string[5, 9]
                   {
                        {"Магазин1", "100", "50", "50", "0", "50", "Да", "Иванов", null},
                        {"Магазин2", "200", "200", "0", "0", "0", "Да", "Петров", null},
                        {"Магазин3", "100", "99", "1", "1", "0", "Нет", "", null},
                        {"Магазин4", "500", "550", "50", "50", "0", "Да", "Сидоров", null},
                        {"Магазин5", "150", "150", "0", "0", "0", "Нет", "", null}
                   };

                    for (int i = 0; i < 5; i++)
                    {
                        for (int y = 0; y < 8; y++)
                        //при y<9 ошибка, скорее всего неправильно пытаюсь записать null в ячейку типа CheckBox
                        {
                            dataGridView1.Rows.Add();
                            dataGridView1[y, i].Value = masterGridData[i, y].ToString();
                        }
                    }

                    dataGridView1.AutoResizeColumns();

                    //создаём грид 1С
                    dataGridView2.ColumnCount = 3;
                    dataGridView2.Columns[0].Name = "Дата";
                    dataGridView2.Columns[1].Name = "№ док.";
                    dataGridView2.Columns[2].Name = "Сумма НДС";

                    string[,] detailGridData = new string[4, 3]
                   {
                        {"05/07/2016", "652134", "50"},
                        {"18/07/2016", "127413", "200"},
                        {"23/07/2016", "543687", "99"},
                        {"XX/XX/XXXX", "Нет документа", "XX"}
                   };

                    for (int i = 0; i < 4; i++)
                    {
                        for (int y = 0; y < 3; y++)
                        {
                            dataGridView2.Rows.Add();
                            dataGridView2[y, i].Value = detailGridData[i, y].ToString();
                        }
                    }

                    dataGridView2.AutoResizeColumns();

                    //создаём грид Т22
                    dataGridView3.ColumnCount = 3;
                    dataGridView3.Columns[0].Name = "Дата";
                    dataGridView3.Columns[1].Name = "№ док.";
                    dataGridView3.Columns[2].Name = "Сумма НДС";                    
                    
                    string[,] detail2GridData = new string[3, 3]
                   {
                        {"05/07/2016", "1652134", "50"},
                        {"18/07/2016", "2127413", "200"},
                        {"23/07/2016", "4543687", "99"},
                   };

                    for (int i = 0; i < 3; i++)
                    {
                        for (int y = 0; y < 3; y++)
                        {
                            dataGridView3.Rows.Add();
                            dataGridView3[y, i].Value = detail2GridData[i, y].ToString();
                        }
                    }

                    dataGridView3.AutoResizeColumns();
                }

                if (comboBox4.Text == "Черновик")
                {
                    dataGridView1.ColumnCount = 0;
                    dataGridView2.ColumnCount = 0;
                    dataGridView3.ColumnCount = 0;
                }
            }
            #endregion

            #region "ТОВ САВ-Д" + "Только розница"
            if (comboBox1.Text == "ТОВ САВ-Д" && comboBox3.Text == "Только розница")
            {
                if (comboBox4.Text == "Заполнено")
                {
                    dataGridView1.ColumnCount = 6;
                    dataGridView1.Columns[0].Name = "Магазин";
                    dataGridView1.Columns[1].Name = "Сумма НДС в Т22";
                    dataGridView1.Columns[2].Name = "Сумма НДС в 1С";
                    dataGridView1.Columns[3].Name = "Расхождение";
                    dataGridView1.Columns[4].Name = "Расхождение фикс.";
                    dataGridView1.Columns[5].Name = "Расхождение врем.";                    

                    DataGridViewComboBoxColumn col = new DataGridViewComboBoxColumn();
                    col.Items.AddRange("Да", "Нет");
                    dataGridView1.Columns.Add(col);
                    dataGridView1.Columns[6].Name = "Сверено";                    

                    DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();                    
                    dataGridView1.Columns.Add(col1);
                    dataGridView1.Columns[7].Name = "Кто сверил";                                

                    DataGridViewCheckBoxColumn col2 = new DataGridViewCheckBoxColumn();
                    dataGridView1.Columns.Add(col2);
                    dataGridView1.Columns[8].Name = "Создать док.";

                    string[,] masterGridData = new string[5, 9]
                   {
                        {"Магазин1", "100", "50", "50", "0", "50", "Да", "Иванов", null},
                        {"Магазин2", "200", "200", "0", "0", "0", "Да", "Петров", null},
                        {"Магазин3", "100", "99", "1", "1", "0", "Нет", "", null},
                        {"Магазин4", "500", "550", "50", "50", "0", "Да", "Сидоров", null},
                        {"Магазин5", "150", "150", "0", "0", "0", "Нет", "", null}
                   };

                    for (int i = 0; i < 5; i++)
                    {
                        for (int y = 0; y < 8; y++)
                            //при y<9 ошибка, скорее всего неправильно пытаюсь записать null в ячейку типа CheckBox
                        {
                            dataGridView1.Rows.Add();
                            dataGridView1[y, i].Value = masterGridData[i, y].ToString();
                        }
                    }

                    dataGridView1.AutoResizeColumns();                    

                }

                if (comboBox4.Text == "Черновик")
                {
                    dataGridView1.ColumnCount = 0;
                    dataGridView2.ColumnCount = 0;
                    dataGridView3.ColumnCount = 0;
                }
            }
            #endregion
        }
    }
}
