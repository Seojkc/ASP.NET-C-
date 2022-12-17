using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3B
{

    
    public partial class listBoxHairDresser : Form
    {
        /// <summary>
        /// initializing the comboBox as "Jane"
        /// </summary>
        public listBoxHairDresser()
        {
            InitializeComponent();
            // comboBox1.Items{ }
            comboBox1.SelectedIndex = 0;
           
        }

       

        bool condition = true;
        

        /// <summary>
        /// store the correspoding price  of hairdresser in a array 
        /// </summary>
        int[] HairdresserpreiceLst = {30,45,40,50,55 };

        /// <summary>
        /// store the correspoding price  of services in a array 
        /// </summary>
        int[] servicePriceList = {30, 20, 40, 50, 200, 60 };

        /// <summary>
        /// returnt the hair dresser price corresponds to the array list
        /// 
        /// return -1 if not found
        /// </summary>
        /// <returns></returns>
        public int getHairdresserPrice()
        {
            if (comboBox1.SelectedIndex >= 0)///checking whether user set any 
            {
                int index = comboBox1.SelectedIndex;
                return HairdresserpreiceLst[index];


            }
            else
            {
                condition = false;

                return -1;
            }


        }

        /// <summary>
        /// returnt he servoce price corresponds to the list
        /// return -1 if not found
        /// </summary>
        /// <returns></returns>
        public int getService()
        {
            if (ServiceBox.SelectedIndex >= 0)
            {
                int index = ServiceBox.SelectedIndex;
                return servicePriceList[index];


            }
            else
            {
                condition = false;

                return -1;
            }


        }

        /// <summary>
        /// return the hair dresser name  corresponds to the comboBox 's  selected Index
        /// </summary>
        /// <returns></returns>
        public string gethairDresserName()
        {
            string name="";            
            if (comboBox1.SelectedIndex==0)

            {
                name = "Jane";
            }
            if (comboBox1.SelectedIndex == 1)
            {
                name = "Pat";
            } if (comboBox1.SelectedIndex == 2)
            {
                name = "Ron";
            } if (comboBox1.SelectedIndex == 3)
            {
                name = "Sue";
            } if (comboBox1.SelectedIndex == 4)
            {
                name = "Laurie";
            }
            else
            {
                condition = false;
            }

                return name;
        }


        /// <summary>
        /// return the service name with the listbox selected index
        /// </summary>
        /// <returns></returns>
        public string getServiceName()
        {
            string serviceName = "";

            if(ServiceBox.SelectedIndex == 0)
            {
                serviceName = "Cut";
            }
            if (ServiceBox.SelectedIndex == 1)
            {
                serviceName = "Wash, Blow, and style";
            }
            if (ServiceBox.SelectedIndex == 2)
            {
                serviceName = "Color";
            }
            if (ServiceBox.SelectedIndex == 3)
            {
                serviceName = "HIghlights";
            }
            if (ServiceBox.SelectedIndex == 4)
            {
                serviceName = "Extension";
            }
            if (ServiceBox.SelectedIndex == 5)
            {
                serviceName = "Up-do";
            }
            

            return serviceName;
        }


        /// <summary>
        /// check whether the name is set or not
        /// </summary>
        bool nameSet = true;


        /// <summary>
        /// declaring total price
        /// </summary>
        int totalPrice = 0;


        /// <summary>
        /// store the items of user selected . this include hairdresser name and the services. 
        /// </summary>
        List<string> setItems = new List<string>();

        /// <summary>
        /// store the items's price  of user selected . this include hairdresser 's price  and the service's price . 
        /// </summary>
        List<int> setPrice = new List<int>();
        private void addServices_Click(object sender, EventArgs e)
        {
            bool condition = true;
            
            ///declaring the fhairdresser price
            int hairDresserPrice = getHairdresserPrice();

            //declaring the service price
            int servicePrice = getService();
           
            if (condition)//checkin user selected everything correctly
            {
                if (!setItems.Contains(getServiceName())){//check not to add the hairdresser name and price again to the list.
                    if (nameSet)
                    {
                        setItems.Add(gethairDresserName());
                        setPrice.Add(getHairdresserPrice());
                        nameSet = false;

                    }
                    setItems.Add(getServiceName());///adding services 
                    setPrice.Add(getService());///adding service price to the list
                }
            }

           //clearing the listview
           listView1.Items.Clear();
           listView2.Items.Clear();

            //setting total price to 0
            totalPrice = 0;

            //printing the listview 1 whichc is the serices
            foreach (string s in setItems)
            {
                listView1.Items.Add(s);
            }

            //printing the listview 2 whichc is the serices' price
            foreach (int s in setPrice)
            {
                listView2.Items.Add("$"+" " + s.ToString() + ".00" );
                totalPrice += s;
                calculateButton.Enabled = true;

            }







        }

       
        /// <summary>
        /// method work when listbox 1 which the services clicked 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ServiceBox.SelectedItems.Count>=1 && comboBox1.SelectedIndex >= 0)//check whether both services and hairdresser selected 
            {
                addServices.Enabled = true;//enabling add service button
                comboBox1.Enabled = false;//disabling comboBox (hair dresser name )

            }
        }

        /// <summary>
        /// method work when comboBox 1  1 which the hairdresser name  clicked 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBoxHairDresser_Load(object sender, EventArgs e)
        {
            if (ServiceBox.SelectedItems.Count >= 1 && comboBox1.SelectedIndex >= 0)//check whether both services and hairdresser selected 
            {
                addServices.Enabled = true;//enabling add service button
                comboBox1.Enabled = false;//disabling comboBox (hair dresser name )
            }

        }


        /// <summary>
        /// method works whene calculate button clicked 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            totalPricetxtBox.Text ="$ " +totalPrice.ToString()+ ".00";//formating and converting total price into string and change the text of textbox 
        }


        /// <summary>
        /// 
        /// reset Button.resetting everything 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            totalPrice = 0;
            listView2.Items.Clear();
            condition = true;
            totalPricetxtBox.Text = "";
            comboBox1.Enabled = true;
            addServices.Enabled = false;
            calculateButton.Enabled = false;
            setItems = new List<string>();
            setPrice = new List<int>();
            nameSet = true;



        }

        /// <summary>
        /// exit button clicked 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {

            //confirming the user want to exit the window
            const string message =
               "Are you sure that you would like to close the form?";
            const string caption = "Form Closing";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Exclamation);

            // If the no button was pressed ...  
            if (result != DialogResult.No)
            {
                // cancel the closure of the form.  
                this.Close();
            }
            
        }

        /// <summary>
        /// listview 2 which print the price of services
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// prints the services
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}