using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Lab4B
{

   
    public partial class Form1 : Form
    {

        /// <summary>
        /// initial component
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }


        /// <summary>
        /// method work when exit button clicked.
        /// exits the window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();//closing the window
        }


        //store the entire file as string
        private string document;



        /// <summary>
        /// method work when load file button clicked inside the menu strip
        /// load the new window using open file dialog
        /// check the format of the file loaded and 
        /// import the html file data into string using streamReader
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //checking the foramt of file loaded
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //enabling the check tag button in menu strip
                checkTagsToolStripMenuItem.Enabled = true;

                //storing the file name
                string DATAFILENAME = openFileDialog1.FileName;

                //reading the file 
                StreamReader reader = new StreamReader(DATAFILENAME);

                
                document = reader.ReadToEnd();

                //updating the label
                label1.Text = Path.GetFileName(DATAFILENAME) + " Succesfully Loaded ! ";           
            }
        }


        /// <summary>
        /// method used to rotate the stack
        /// by storing into a temp. stack
        /// </summary>
        /// <param name="TagsStack"></param>
        /// <returns></returns>
        public Stack<string> stackRotate(Stack<string> TagsStack)
        {
            Stack<string> temp = new Stack<string>();

            while(TagsStack.Count != 0)
            {
                temp.Push(TagsStack.Pop());
            }

            return temp;// returning the rotated stack
        }


        /// <summary>
        /// method to check the tags are balanced or not
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkTagsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //stop at the > sign to filter the tag from string
            bool resume = false;

            //store the array of tags
            Stack<string> TagsStack = new Stack<string>();

            //store the single tag
            string singleTag = "";

            //filtering the tags
            foreach(char singleChar in document)
            {
               
                if (singleChar == '<')
                {
                    resume = true;
                }
                if (resume)
                {
                    singleTag += singleChar;
                }

                if ( singleChar == '>')
                {
                    resume = false;
                    TagsStack.Push(singleTag);
                    singleTag = "";
                }
            }

            //rotating the stack
            TagsStack = stackRotate(TagsStack);

            //store the space for decoration and track the code is balanced or not
            int spaceNumber = 0;

            //printing the each tags in listbox
            foreach (string Element in TagsStack)
            {
                //creating the space for decoration 
                string space = new string(' ', spaceNumber * 4);

                //tracking the non-container tag
                if (Element.Contains("<br>") || Element.Contains("<img") || Element.Contains("<hr>"))
                {
                    listBox1.Items.Add(space+"Found non-container tag: " + Element + "\n");
                    
                }
                else
                {
                    //tracking closing tag
                    if (Element[1] == '/')
                    {
                        spaceNumber -= 1;
                        space = new string(' ', spaceNumber*4);
                        listBox1.Items.Add(space+"Found Closing tag: " + Element + "\n");
                        
                    }
                    //tracking opening tag
                    else
                    {
                        listBox1.Items.Add(space+"Found Opening tag: " + Element + "\n");
                        spaceNumber += 1;
                    }
                }
            }

            // printing the result 
            if (spaceNumber == 0)
            {
                label1.Text = " Balanced Code";
            }
            else
            {
                label1.Text = " UnBalanced Code";

            }



        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
    
}
