using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Balance
{
    public partial class Form1 : Form
    {
    
        string FileText = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {

            OpenFileDialog fDialog = new OpenFileDialog();
            fDialog.ShowDialog();

            FileText = File.ReadAllText(fDialog.FileName);

            txtFile.Text = FileText;
        }

        private void btnBalance_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Balance().ToString());
        }

        private bool Balance()
        {
            int i = 0;
            txtOutput.Text = String.Empty;

            Stack<char> stack = new Stack<char>();

            //Checking if the text contains parentheses
            if (FileText.Contains('{') || FileText.Contains('(') || FileText.Contains('[') || FileText.Contains(']') || FileText.Contains(')') || FileText.Contains('}'))
            {
                //loop through each character
                foreach (char c in FileText)
                {
                    //pushing open brackets to the stack
                    switch (c)
                    {
                        case '{': stack.Push(c); txtOutput.AppendText($"\n Pushed {c} to stack"); break;
                        case '(': stack.Push(c); txtOutput.AppendText($"\n Pushed {c} to stack"); break;
                        case '[': stack.Push(c); txtOutput.AppendText($"\n Pushed {c} to stack"); break;

                        default:
                            break;
                    }

                    //popping off from the stack when a closing bracket is encountered
                    switch (c)
                    {
                        case '}':
                            if (stack.IsEmpty())
                            {
                                txtOutput.AppendText($"{c} - Stack is Empty");
                                return false;
                            }
                            else
                            {
                                if (stack.Pop() != '{')
                                {
                                    txtOutput.AppendText($"\n{c} - No match - cb  i = {i}");
                                    txtOutput.AppendText($"\n Bad chars - {FileText.Substring(i, 50)}  /{c}/");
                                    return false;
                                }
                                else
                                {
                                    txtOutput.AppendText($"\n Pop Successful {c} ");
                                }
                                break;
                            }

                        case ')':
                            if (stack.IsEmpty())
                            {
                                txtOutput.AppendText($"{c} - Stack  is Empty");
                                return false;
                            }
                            else
                            {
                                if (stack.Pop() != '(')
                                {
                                    txtOutput.AppendText($"\n{c} - No match - b i = {i}");
                                    txtOutput.AppendText($"\n Bad chars - {FileText.Substring(i, 50)}  /{c}/");
                                    return false;
                                }
                                else
                                {
                                    txtOutput.AppendText($"\n Pop Successful {c} ");
                                }
                                break;
                            }

                        case ']':
                            if (stack.IsEmpty())
                            {
                                txtOutput.AppendText($"{c} - Stack is Emptyl");
                                return false;
                            }
                            else
                            {
                                if (stack.Pop() != '[')
                                {
                                    txtOutput.AppendText($"\n{c} - No match - sb i = {i}");
                                    txtOutput.AppendText($"\n Bad chars - {FileText.Substring(i, 50)}  /{c}/");
                                    return false;
                                }
                                else
                                {
                                    txtOutput.AppendText($"\n Pop Successful {c} ");
                                }
                                break;
                            }

                        default:
                            break;
                    }
                    i++;
                }

                bool result = stack.IsEmpty();

                if (!result)
                {
                    txtOutput.AppendText("\nStack was not empty");
                }

                return result;

            }
            else
            {
                //Returning false if there are no parentheses in the file.
                return false;
            }
        }
    }
}
