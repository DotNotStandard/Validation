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

		private string _explanatoryText = string.Empty;
		private string _characterSet = string.Empty;

		#region Constructors

		public frmMain()
		{
			InitializeComponent();
		}

		#endregion

		#region Event Handlers

		private void frmMain_Load(object sender, EventArgs e)
		{
			ddlCategory.Items.Add(new KeyValuePair<UnicodeCategory, string>(UnicodeCategory.UppercaseLetter | UnicodeCategory.LowercaseLetter | UnicodeCategory.TitlecaseLetter | UnicodeCategory.ModifierLetter | UnicodeCategory.OtherLetter, "All Letters"));
			ddlCategory.Items.Add(new KeyValuePair<UnicodeCategory, string>(UnicodeCategory.UppercaseLetter | UnicodeCategory.LowercaseLetter | UnicodeCategory.TitlecaseLetter, "Upper, Lower and Title case Letter"));
			ddlCategory.Items.Add(new KeyValuePair<UnicodeCategory, string>(UnicodeCategory.UppercaseLetter | UnicodeCategory.LowercaseLetter, "Uppercase and Lowercase Letter"));
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
			string setNameMatch = string.Empty;
			KeyValuePair<UnicodeCategory, string> selectedItem;
			UnicodeCategory categoriesOfInterest;
			StringBuilder explanationBuilder;
			StringBuilder characterSetBuilder;

			_explanatoryText = string.Empty;
			_characterSet = string.Empty;
			txtResults.Visible = false;
			lblProgress.Text = "Working ...";

			// Determine the match rules we are discovering with
			selectedItem = (KeyValuePair<UnicodeCategory, string>)ddlCategory.SelectedItem;
			categoriesOfInterest = selectedItem.Key;
			if (chkRestrict.Checked)
			{
				setNameMatch = txtSetNameMatch.Text;
			}

			// Iterate all of the characters, identifying all of the ones that match the rules entered
			explanationBuilder = new StringBuilder();
			characterSetBuilder = new StringBuilder();
			for (ushort codePoint = 0; codePoint < ushort.MaxValue; codePoint++)
			{
				characterUnderTest = Convert.ToChar(codePoint);

				// Check if the test character is within the categories being requested
				if (IsOfInterest(characterUnderTest, categoriesOfInterest, setNameMatch))
				{
					characterSetBuilder.Append(characterUnderTest);
					if (!withinSubset)
					{
						// Output where we are in the range, as a starting point for understanding
						explanationBuilder.AppendFormat("{0} (U+{0:X4}):\r\n", codePoint);
						withinSubset = true;
					}
					explanationBuilder.Append(characterUnderTest);
				}
				else
				{
					if (withinSubset)
					{
						// Add a separator between subsets, now that we've reached the end of one
						explanationBuilder.AppendLine();
						withinSubset = false;
					}
				}
			}

			// Store, and then show, the results of the calculation
			_explanatoryText = explanationBuilder.ToString();
			_characterSet = characterSetBuilder.ToString();
			txtResults.Text = _explanatoryText;
			txtResults.Visible = true;
			lblProgress.Text = "Press Test to start";
		}

		private void btnCopyToClipboard_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(_characterSet, TextDataFormat.UnicodeText);
		}

		private void btnExit_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		#endregion

		#region Private Helper Methods

		/// <summary>
		/// Method to determine if a character is within those deemed of interest
		/// </summary>
		/// <param name="characterUnderTest">The character for which interest is being determined</param>
		/// <param name="categoriesOfInterest">The categories of characters that have been deemed interesting</param>
		/// <param name="setNameMatch">Optional word expected to be found in the character set name if it is of interest</param>
		/// <returns>Boolean true if the character meets the match rules, otherwise false</returns>
		private bool IsOfInterest(char characterUnderTest, UnicodeCategory categoriesOfInterest, string setNameMatch)
		{
			int codePoint;
			System.Unicode.UnicodeCharInfo unicodeInfo;

			// Start by checking if the character is within the categories that are of interest
			if (categoriesOfInterest.HasFlag(CharUnicodeInfo.GetUnicodeCategory(characterUnderTest)))
			{
				// Check if a set name match has been requested
				if (string.IsNullOrEmpty(setNameMatch))
				{
					// No set name match required; it's a match
					return true;
				}

				// Perform matching of the name of the set in which the character resides
				codePoint = Convert.ToInt32(characterUnderTest);
				unicodeInfo = System.Unicode.UnicodeInfo.GetCharInfo(codePoint);
				if (unicodeInfo.Block.Contains(setNameMatch))
				{
					return true;
				}
			}

			return false;
		}

		#endregion

	}
}
