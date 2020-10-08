using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace Message_Classes_V1_0
{
    /// <summary>
    /// Get of user a string information.
    /// </summary>
    public static class MessageTextBox
    {
        /// <summary>
        /// Show a form to user insert the informations
        /// </summary>
        /// <param name="title">Title of form</param>
        /// <param name="previusText">Previus text into <see cref="System.Windows.Forms.TextBox"/></param>
        /// <param name="maxTextLength">Max text length informed wath user can inform</param>
        /// <param name="multiLines">That <see cref="System.Windows.Forms.TextBox"/> can do text line break</param>
        /// <param name="justNumber">User can only enter numbers</param>
        /// <param name="justLetter">User can only enter letters</param>
        /// <param name="invalidTerms">Specifialy char term not permecive into text</param>
        /// <param name="icon">Image icon to form</param>
        /// <returns></returns>
        public static Tuple<DialogResult, string> Show(string title = "", string previusText = "", int maxTextLength = 32767, bool multiLines = false, bool justNumber = false, bool justLetter = false, char[] invalidTerms = null, char[] validExceptionTerms = null, System.Drawing.Icon icon = null)
        {
            // 
            // textBox1
            // 
            System.Windows.Forms.TextBox textBox1 = new System.Windows.Forms.TextBox()
            {
                Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right) | System.Windows.Forms.AnchorStyles.Top))),
                Location = new System.Drawing.Point(12, 12),
                Name = "textBox1",
                Size = new System.Drawing.Size(312, 20),
                TabIndex = 0,
                Text = previusText,
                MaxLength = maxTextLength,
                Multiline = multiLines

            };


            // 
            // button1
            // 
            System.Windows.Forms.Button button1 = new System.Windows.Forms.Button()
            {
                Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right))),
                Location = new System.Drawing.Point(12, 47),
                Name = "button1",
                Size = new System.Drawing.Size(312, 23),
                TabIndex = 1,
                Text = "Ok",
                UseVisualStyleBackColor = true
            };


            //
            // form1
            //                
            int width = 352, heigth = 115;
            System.Windows.Forms.Form form1 = new System.Windows.Forms.Form()
            {
                AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F),
                AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font,
                ClientSize = new System.Drawing.Size(width, heigth),
                Size = new System.Drawing.Size(width, heigth),
                MinimumSize = new System.Drawing.Size(width, heigth),
                MaximumSize = new System.Drawing.Size(width, heigth),
                MinimizeBox = false,
                MaximizeBox = false,
                FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable,
                Icon = icon,
                Name = "form1",
                StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen,
                Text = $"{title}",
                DialogResult = DialogResult.None
            };

            if (multiLines) { form1.MaximumSize = new System.Drawing.Size(0, 0); }
            System.Drawing.Size minSize = form1.MinimumSize;

            //
            // Methods and Events
            //
            button1.Click += new EventHandler(Button1_Click);
            void Button1_Click(object sender, EventArgs e)
            {
                form1.DialogResult = DialogResult.OK;
            }

            textBox1.KeyUp += new KeyEventHandler(TextBox1_KeyUp);
            void TextBox1_KeyUp(object sender, KeyEventArgs e)
            {
                if (!multiLines && e.KeyCode == Keys.Enter)
                {
                    button1.PerformClick();
                }
            }

            textBox1.KeyPress += new KeyPressEventHandler(TextBox1_KeyPress);
            void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
            {


                if ((justNumber && !char.IsNumber(e.KeyChar)) && !validExceptionTerms.Contains(e.KeyChar))
                {
                    e.Handled = true;
                }
                else
                {
                    if ((justLetter && !char.IsLetter(e.KeyChar)) && !validExceptionTerms.Contains(e.KeyChar))
                    {
                        e.Handled = true;
                    }
                    else
                    {
                        if ((invalidTerms != null && invalidTerms.Contains(e.KeyChar)) && !validExceptionTerms.Contains(e.KeyChar))
                        {
                            e.Handled = true;
                        }
                    }
                }
            }

            textBox1.PreviewKeyDown += new PreviewKeyDownEventHandler(TextBox1_PreviewKeyDown);
            void TextBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
            {

            }


            //
            // Insert controls
            //
            form1.Controls.Add(textBox1);
            form1.Controls.Add(button1);
            form1.ResumeLayout(false);


            if (form1.ShowDialog() == DialogResult.OK)
            {
                return new Tuple<DialogResult, string>(form1.DialogResult, textBox1.Text);
            }
            else
            {
                return new Tuple<DialogResult, string>(DialogResult.None, string.Empty);
            }

        }


        /// <summary>
        /// Show a form to user insert the informations
        /// </summary>
        /// <param name="passwordChar">Digit to hide the real infortion</param>
        /// <param name="title">Title of form</param>
        /// <param name="maxTextLength">Max text length informed wath user can inform</param>
        /// <param name="justNumber">User can only enter numbers</param>
        /// <param name="justLetter">User can only enter letters</param>
        /// <param name="icon">Image icon to form</param>
        /// <returns></returns>
        public static Tuple<DialogResult, string> ShowPasswordMode(char passwordChar = '*', string title = "", int maxTextLength = 32767, bool justNumber = false, bool justLetter = false, System.Drawing.Icon icon = null)
        {
            // 
            // textBox1
            // 
            System.Windows.Forms.TextBox textBox1 = new System.Windows.Forms.TextBox()
            {
                Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right) | System.Windows.Forms.AnchorStyles.Top))),
                Location = new System.Drawing.Point(12, 12),
                Name = "textBox1",
                Size = new System.Drawing.Size(312, 20),
                TabIndex = 0,
                Text = string.Empty,
                MaxLength = maxTextLength,
                Multiline = false,
                PasswordChar = passwordChar
            };


            // 
            // button1
            // 
            System.Windows.Forms.Button button1 = new System.Windows.Forms.Button()
            {
                Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right))),
                Location = new System.Drawing.Point(12, 47),
                Name = "button1",
                Size = new System.Drawing.Size(312, 23),
                TabIndex = 1,
                Text = "Ok",
                UseVisualStyleBackColor = true
            };
            //
            // form1
            //                
            int width = 352, heigth = 115;
            System.Windows.Forms.Form form1 = new System.Windows.Forms.Form()
            {
                AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F),
                AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font,
                ClientSize = new System.Drawing.Size(width, heigth),
                Size = new System.Drawing.Size(width, heigth),
                MinimumSize = new System.Drawing.Size(width, heigth),
                MaximumSize = new System.Drawing.Size(width, heigth),
                MinimizeBox = false,
                MaximizeBox = false,
                FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable,
                Icon = icon,
                Name = "form1",
                StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen,
                Text = $"{title}",
                DialogResult = DialogResult.None
            };


            System.Drawing.Size minSize = form1.MinimumSize;

            //
            // Methods and Events
            //
            button1.Click += new EventHandler(Button1_Click);
            void Button1_Click(object sender, EventArgs e)
            {
                form1.DialogResult = DialogResult.OK;
            }

            textBox1.KeyUp += new KeyEventHandler(TextBox1_KeyUp);
            void TextBox1_KeyUp(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    button1.PerformClick();
                }
            }

            textBox1.KeyPress += new KeyPressEventHandler(TextBox1_KeyPress);
            void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
            {
                if ((justNumber && !char.IsNumber(e.KeyChar)))
                {
                    e.Handled = true;
                }
                else
                {
                    if ((justLetter && !char.IsLetter(e.KeyChar)))
                    {
                        e.Handled = true;
                    }
                    else
                    {


                    }
                }
            }

            textBox1.PreviewKeyDown += new PreviewKeyDownEventHandler(TextBox1_PreviewKeyDown);
            void TextBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
            {

            }


            //
            // Insert controls
            //
            form1.Controls.Add(textBox1);
            form1.Controls.Add(button1);
            form1.ResumeLayout(false);


            if (form1.ShowDialog() == DialogResult.OK)
            {
                return new Tuple<DialogResult, string>(form1.DialogResult, textBox1.Text);
            }
            else
            {
                return new Tuple<DialogResult, string>(DialogResult.None, string.Empty);
            }

        }





    }

}
