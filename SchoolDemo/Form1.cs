namespace SchoolDemo
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            fillClassDepartments();
            fillClassSube();
            ogrenciSayisiYaz();
            fillClassBrans();


        }
        private void ogrenciSayisiYaz()
        {
            int ogrenciSayisi = listBoxOgrenciler.Items.Count;
        }
        private void fillClassDepartments()
        {
            var names = Enum.GetNames<Departments>();
            names.ToList().ForEach(n => comboBoxBolum.Items.Add(n));
        }
        private void fillClassSube()
        {
            var names = Enum.GetNames<Sube>();
            names.ToList().ForEach(n => comboBoxSube.Items.Add(n));
        }
        private void fillClassBrans()
        {
            var names = Enum.GetNames<Brans>();
            names.ToList().ForEach(n => comboBoxEgitmenBransi.Items.Add(n));
        }

        private void buttonSinifOlustur_Click(object sender, EventArgs e)
        {
            ClassRoom classRoom = new ClassRoom();
            classRoom.ClassNo = Convert.ToInt32(textBoxSinifNo.Text);
            classRoom.Department = comboBoxBolum.Text;
            classRoom.Letter = comboBoxSube.Text;
            classRoom.ClassName = $" {textBoxSinifNo.Text} {classRoom.Department} {classRoom.Letter} ";

            if (textBoxSinifNo.Text!=""&& comboBoxBolum.Text!=""&&comboBoxSube.Text!="")
            {
                ListViewItem item = new ListViewItem("Mustafa Kemal Anadolu Lisesi");
                item.SubItems.Add(classRoom.ClassName);
                item.SubItems.Add("0");
                item.SubItems.Add("-");
                listViewSiniflar.Items.Add(item);
                
                textBoxSinifNo.Text = "";
                comboBoxBolum.Text = "";
                comboBoxSube.Text = "";
            }
            else
            {
               MessageBox.Show("Bu alanlar  boþ geçilemez.","HATA",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            
        }
        private void buttonOgrenciEkle_Click(object sender, EventArgs e)
        {
            Student student=new Student();
            student.Name = textBoxOgrenciAdi.Text;
            student.Address = textBoxOgrenciAdresi.Text;
            student.LastName = textBoxOgrenciSoyadi.Text;
            if ( textBoxOgrenciAdi.Text!=""&&textBoxOgrenciSoyadi.Text!=""&&textBoxOgrenciAdresi.Text!="")
            {
                listBoxOgrenciler.Items.Add(student.Name + " " + student.LastName + " " + student.Address);
                foreach (ListViewItem seciliSinif in listViewSiniflar.CheckedItems)
                {
                    seciliSinif.SubItems[2].Text= listBoxOgrenciler.Items.Count.ToString();
                }
                textBoxOgrenciAdi.Text = "";
                textBoxOgrenciSoyadi.Text = "";
                textBoxOgrenciAdresi.Text = "";
            }
            else
            {
                MessageBox.Show("Bu alanlar  boþ geçilemez.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void splitContainer2_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listViewSiniflar_SelectedIndexChanged(object sender, EventArgs e)
        {
    
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void buttonEgitmenAta_Click(object sender, EventArgs e)
        {
            Instructor ýnstructor = new Instructor();
            ýnstructor.Name = textBoxEgitmenAdi.Text;
            ýnstructor.LastName = textBoxEgitmenSoyadi.Text;
            ýnstructor.Department = comboBoxEgitmenBransi.Text;
            if (ýnstructor.Name!=""&&ýnstructor.LastName!=""&&ýnstructor.Department!="")
            {
                foreach (ListViewItem seciliSinif in listViewSiniflar.CheckedItems)
                {
                    seciliSinif.SubItems[3].Text = ýnstructor.Name;
                }
            }
            else
            {
                MessageBox.Show("Bu alanlar  boþ geçilemez.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            textBoxEgitmenAdi.Text = "";
            textBoxEgitmenSoyadi.Text = "";
            comboBoxEgitmenBransi.Text = "";
        }

        private void listViewSiniflar_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (listViewSiniflar.CheckedItems.Count == 0)
            {
                groupBox2.Enabled = false;
                buttonOgrenciEkle.Enabled = false;

            }
            else
            {
                groupBox2.Enabled = true;
                buttonOgrenciEkle.Enabled = true;
                listBoxOgrenciler.Items.Clear();
            }
        }
    }
}