using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharacterSetInvestigator.WinUI
{
	public partial class frmMain : Form
	{

		private string _results = string.Empty;

		#region Constructors

		public frmMain()
		{
			InitializeComponent();
		}

		#endregion

		#region Event Handlers

		private void frmMain_Load(object sender, EventArgs e)
		{
			ddlCategory.Items.Add(new KeyValuePair<UnicodeCategory, string>(UnicodeCategory.UppercaseLetter, "Uppercase Letter"));
			ddlCategory.Items.Add(new KeyValuePair<UnicodeCategory, string>(UnicodeCategory.LowercaseLetter, "Lowercase Letter"));
			ddlCategory.Items.Add(new KeyValuePair<UnicodeCategory, string>(UnicodeCategory.TitlecaseLetter, "Titlecase Letter"));
			ddlCategory.Items.Add(new KeyValuePair<UnicodeCategory, string>(UnicodeCategory.ModifierLetter, "Modifier Letter"));
			ddlCategory.Items.Add(new KeyValuePair<UnicodeCategory, string>(UnicodeCategory.OtherLetter, "Other Letter"));
			ddlCategory.Items.Add(new KeyValuePair<UnicodeCategory, string>(UnicodeCategory.DecimalDigitNumber, "Decimal Digit Number"));
			ddlCategory.DisplayMember = "Value";
			ddlCategory.ValueMember = "Key";
			ddlCategory.SelectedIndex = 0;
		}

		private void btnTest_Click(object sender, EventArgs e)
		{
			bool withinSubset = false;
			Char characterUnderTest;
			KeyValuePair<UnicodeCategory, string> selectedItem;
			UnicodeCategory category;
			StringBuilder stringBuilder;

			_results = string.Empty;
			txtResults.Visible = false;
			lblProgress.Text = "Working ...";
			selectedItem = (KeyValuePair<UnicodeCategory, string>)ddlCategory.SelectedItem;
			category = selectedItem.Key;

			// Iterate all of the characters, identifying all of the ones in the chosen category
			stringBuilder = new StringBuilder();
			for (ushort codePoint = 0; codePoint < ushort.MaxValue; codePoint++)
			{
				characterUnderTest = Convert.ToChar(codePoint);

				// Check if the test character is within the category being requested
				if (CharUnicodeInfo.GetUnicodeCategory(characterUnderTest) == category)
				{
					if (!withinSubset)
					{
						// Output where we are in the range, as a starting point for understanding
						stringBuilder.AppendFormat("{0} (U+{0:X4}):\r\n", codePoint);
						withinSubset = true;
					}
					stringBuilder.Append(characterUnderTest);
				}
				else
				{
					if (withinSubset)
					{
						// Add a separator between subsets, now that we've reached the end of one
						stringBuilder.AppendLine();
						withinSubset = false;
					}
				}
			}

			// Show the results of the calculation
			_results = stringBuilder.ToString();
			txtResults.Text = _results;
			txtResults.Visible = true;
			lblProgress.Text = "Press Test to start";
		}

		private void btnCopyToClipboard_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(_results, TextDataFormat.UnicodeText);
		}

		private void btnExit_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		#endregion

	}
}
