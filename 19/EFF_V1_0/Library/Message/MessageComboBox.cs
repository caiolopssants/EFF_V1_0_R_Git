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
    public static class MessageComboBox
    {
        /// <summary>
        /// Show a form to user insert the informations
        /// </summary>
        /// <param name="title">Title of form</param>
        /// <param name="selectedIndex">Initial index to show</param>
        /// <param name="items">Itens into ComboBox element</param>
        /// <param name="icon">Image icon to form</param>        
        /// <returns></returns>
        public static Tuple<DialogResult, object, int> Show(IEnumerable<object> items, int selectedIndex = 0, string title = "", System.Drawing.Icon icon = null)
        {
            // 
            // textBox1
            // 
            System.Windows.Forms.ComboBox comboBox1 = new System.Windows.Forms.ComboBox()
            {
                Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right) | System.Windows.Forms.AnchorStyles.Top))),
                Location = new System.Drawing.Point(12, 12),
                Name = "textBox1",
                Size = new System.Drawing.Size(312, 20),
                TabIndex = 0,
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            foreach( var x in items)
            {
                comboBox1.Items.Add(x);
            }
            comboBox1.SelectedIndex = selectedIndex;

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
            //int width = 352, heigth = 115;
            int width = 360, heigth = 140;
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

            

            

            //
            // Insert controls
            //
            form1.Controls.Add(comboBox1);
            form1.Controls.Add(button1);
            form1.ResumeLayout(false);


            if (form1.ShowDialog() == DialogResult.OK)
            {
                return new Tuple<DialogResult, object,int>(form1.DialogResult, comboBox1.SelectedItem,comboBox1.SelectedIndex);
            }
            else
            {
                return new Tuple<DialogResult, object,int>(DialogResult.None, null,-1);
            }

        }

        /// <summary>
        /// Show a form to user insert the informations
        /// </summary>
        /// <param name="title">Title of form</param>
        /// <param name="selectedIndex">Initial index to show</param>
        /// <param name="items">Itens into ComboBox element</param>
        /// <param name="icon">Image icon to form</param>        
        /// <returns></returns>
        public static Tuple<DialogResult, string, int> Show(IEnumerable<string> items, int selectedIndex = 0, string title = "", System.Drawing.Icon icon = null)
        {
            // 
            // textBox1
            // 
            System.Windows.Forms.ComboBox comboBox1 = new System.Windows.Forms.ComboBox()
            {
                Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right) | System.Windows.Forms.AnchorStyles.Top))),
                Location = new System.Drawing.Point(12, 12),
                Name = "textBox1",
                Size = new System.Drawing.Size(312, 20),
                TabIndex = 0,
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            foreach (var x in items)
            {
                comboBox1.Items.Add(x);
            }
            comboBox1.SelectedIndex = selectedIndex;

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
            //int width = 352, heigth = 115;
            int width = 360, heigth = 140;
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





            //
            // Insert controls
            //
            form1.Controls.Add(comboBox1);
            form1.Controls.Add(button1);
            form1.ResumeLayout(false);


            if (form1.ShowDialog() == DialogResult.OK)
            {
                return new Tuple<DialogResult, string, int>(form1.DialogResult, (string)comboBox1.SelectedItem, comboBox1.SelectedIndex);
            }
            else
            {
                return new Tuple<DialogResult, string, int>(DialogResult.None, null, -1);
            }

        }






    }

}
