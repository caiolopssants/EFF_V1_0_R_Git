using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Message_Classes_V1_0
{
    public static class MessageBoxIListEnumerated
    {
        public static DialogResult Show(IEnumerable<string> informations)
        {        
           return MessageBox.Show(EnumerableToString(informations));           
        }
        public static DialogResult Show(IEnumerable<string> informations, string caption)
        {
            return MessageBox.Show(EnumerableToString(informations), caption);
        }
        public static DialogResult Show(IEnumerable<string> informations, string caption, MessageBoxButtons buttons)
        {
            return MessageBox.Show(EnumerableToString(informations), caption, buttons);
        }
        public static DialogResult Show(IEnumerable<string> informations, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            return MessageBox.Show(EnumerableToString(informations), caption, buttons, icon);
        }
        public static DialogResult Show(IEnumerable<string> informations, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton)
        {
            return MessageBox.Show(EnumerableToString(informations), caption, buttons, icon, defaultButton);
        }




        static string EnumerableToString(IEnumerable<string> informations)
        {
            string fT = string.Empty;
            int count = informations.Count();
            int index = -1;

            foreach (var x in informations)
            {
                index++;
                fT += x.ToString();
                if (index < count - 1)
                {
                    fT += "\n";
                }
            }
            return fT;
        }

        //Este processo irá gerar uma lista contendo todos os textos, não importa a quantidade lista genéricas contidas



        public static DialogResult Show(IEnumerable<object> informations)
        {
            return MessageBox.Show(EnumerableToString(informations));
        }
        public static DialogResult Show(IEnumerable<object> informations, string caption)
        {
            return MessageBox.Show(EnumerableToString(informations), caption);
        }
        public static DialogResult Show(IEnumerable<object> informations, string caption, MessageBoxButtons buttons)
        {
            return MessageBox.Show(EnumerableToString(informations), caption, buttons);
        }
        public static DialogResult Show(IEnumerable<object> informations, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            return MessageBox.Show(EnumerableToString(informations), caption, buttons, icon);
        }
        public static DialogResult Show(IEnumerable<object> informations, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton)
        {
            return MessageBox.Show(EnumerableToString(informations), caption, buttons, icon, defaultButton);
        }




        static string EnumerableToString(IEnumerable<object> informations)
        {
            string fT = string.Empty;
            int count = informations.Count();
            int index = -1;

            foreach (var x in informations)
            {
                index++;

                if(x!=null)
                {
                    fT += x.ToString();
                }
                else
                {
                    fT += $"{null}";
                }
                if (index < count - 1)
                {
                    fT += "\n";
                }
            }
            return fT;
        }


    }
}
