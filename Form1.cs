using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Windows;


namespace Notebook
{
	public partial class Form1 : Form
	{
		bool NewFile = true;
		SaveFileDialog SaveFile = new SaveFileDialog();
		public Form1()
		{
			InitializeComponent();
		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MessageBox.Show(
				"Notebook version 1.0.0.0",
				"About",
				MessageBoxButtons.OK,
				MessageBoxIcon.Information);
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void viewGithubToolStripMenuItem_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("https://github.com/BSOD-Master/Notebook");
		}

		private void viewDocumentationToolStripMenuItem_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("https://github.com/BSOD-Master/Notebook/wiki");
		}

		private void newToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if ((NewFile == true && textBox1.Text != "" && textBox1.Text != null) || (NewFile == false && textBox1.Text != "" && textBox1.Text != null) || (NewFile == false && (textBox1.Text != "" || textBox1.Text != null)))
			{
				DialogResult confirm = MessageBox.Show(
					"Do you want to save your file first?",
					"New",
					MessageBoxButtons.YesNoCancel,
					MessageBoxIcon.Warning);
				switch (confirm)
				{
					default:
						break;

					case DialogResult.Yes:
						if (NewFile == true)
						{
							SaveFile.ShowDialog();
						}
						try
						{
							TextWriter txt = new StreamWriter(SaveFile.FileName);
							txt.Write(textBox1.Text);
							txt.Close();
							SaveFile.FileName = "";
						}
						catch (IndexOutOfRangeException exception)
						{
							IndexOutOfRangeException except = exception;
						}
						textBox1.Clear();
						NewFile = true;
						break;

					case DialogResult.No:
						textBox1.Clear();
						NewFile = true;
						break;

					case DialogResult.Cancel:
						break;
				}
			}
			else
			{
				textBox1.Clear();
				NewFile = true;
			}
		}

		private void saveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (NewFile == true)
			{
				SaveFile.ShowDialog();
				NewFile = false;
			}
			try
			{
				TextWriter txt = new StreamWriter(SaveFile.FileName);
				txt.Write(textBox1.Text);
				txt.Close();
			}
			catch (IndexOutOfRangeException exception)
			{
				IndexOutOfRangeException except = exception;
				NewFile = true;
			}
			catch (ArgumentException passed)
			{
				ArgumentException pass = passed;
				NewFile = true;
			}
		}

		private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SaveFile.ShowDialog();
			try
			{
				TextWriter txt = new StreamWriter(SaveFile.FileName);
				txt.Write(textBox1.Text);
				txt.Close();
			}
			catch (IndexOutOfRangeException exception)
			{
				IndexOutOfRangeException except = exception;
			}
			catch (ArgumentException passed)
			{
				ArgumentException pass = passed;
				NewFile = true;
			}
		}

		private void currentFileToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (SaveFile.FileName == "" || SaveFile.FileName == null)
			{
				MessageBox.Show(
					"New unsaved file",
					"Current File");
			}
			else
			{
				MessageBox.Show(
					SaveFile.FileName,
					"Current File");
			}
		}

		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if ((NewFile == true && textBox1.Text != "" && textBox1.Text != null) || (NewFile == false && textBox1.Text != "" && textBox1.Text != null) || (NewFile == false && (textBox1.Text != "" || textBox1.Text != null)))
			{
				DialogResult confirm = MessageBox.Show(
					"Do you want to save your file first?",
					"New",
					MessageBoxButtons.YesNoCancel,
					MessageBoxIcon.Warning);
				switch (confirm)
				{
					default:
						break;

					case DialogResult.Yes:
						if (NewFile == true)
						{
							SaveFile.ShowDialog();
							NewFile = false;
						}
						try
						{
							TextWriter txt = new StreamWriter(SaveFile.FileName);
							txt.Write(textBox1.Text);
							txt.Close();
							SaveFile.FileName = "";
						}
						catch (IndexOutOfRangeException exception)
						{
							IndexOutOfRangeException except = exception;
						}

						textBox1.Clear();
						OpenFileDialog OpenFile = new OpenFileDialog();
						OpenFile.ShowDialog();
						if (OpenFile.FileName != null && OpenFile.FileName != "")
						{
							TextReader text = new StreamReader(OpenFile.FileName);
							textBox1.Text = text.ReadToEnd();
							SaveFile.FileName = OpenFile.FileName;
							text.Close();
						}
						else if (OpenFile.FileName == null || OpenFile.FileName == "")
						{
							NewFile = true;
						}
						break;

					case DialogResult.No:
						textBox1.Clear();
						OpenFileDialog OpenFile1 = new OpenFileDialog();
						OpenFile1.ShowDialog();
						if (OpenFile1.FileName != null && OpenFile1.FileName != "")
						{
							TextReader text = new StreamReader(OpenFile1.FileName);
							textBox1.Text = text.ReadToEnd();
							SaveFile.FileName = OpenFile1.FileName;
							text.Close();
						}
						else if (OpenFile1.FileName == null || OpenFile1.FileName == "")
						{
							NewFile = true;
						}
						break;
						
					case DialogResult.Cancel:
						break;
				}
			} 
			else
			{
				textBox1.Clear();
				OpenFileDialog OpenFile2 = new OpenFileDialog();
				OpenFile2.ShowDialog();
				if (OpenFile2.FileName != null && OpenFile2.FileName != "")
				{
					TextReader text = new StreamReader(OpenFile2.FileName);
					textBox1.Text = text.ReadToEnd();
					SaveFile.FileName = OpenFile2.FileName;
					text.Close();
				}
				else if (OpenFile2.FileName == null || OpenFile2.FileName == "")
				{
					NewFile = true;
				}
			}
		}

		private void toolStripSeparator2_Click(object sender, EventArgs e)
		{
			bool run = true;
			while (run == true)
			{
				DialogResult egg = MessageBox.Show(
					"You found an easter egg!\nThe reason why\n\"Edit > Activate Windows\"\nis disabled is because you can't use a simple C# text editor to activate windows.\nPlease try again in 2098.",
					"You found me!",
					MessageBoxButtons.RetryCancel,
					MessageBoxIcon.Question);
				switch (egg)
				{
					case DialogResult.Cancel:
						run = false;
						break;
					default:
						break;
				}
			}
		}

		private void toolStripSeparator1_Click(object sender, EventArgs e)
		{
			MessageBox.Show(
				"Help is on the way!",
				"Hidden help button",
				MessageBoxButtons.OK,
				MessageBoxIcon.Information);
		}

		private void infoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MessageBox.Show(
				"Edit controls coming soon",
				"Info",
				MessageBoxButtons.OK,
				MessageBoxIcon.Information);
		}
	}
}
