using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SemEspera.Helpers
{
    public class EntryCellPassWord : EntryCell
    {
       
        private string _value;
        public string Value { get { return _value; } set { _value = value; setStars(); } }

        
        private string starFiller(int count) { var output = ""; for (; count > 0; count--, output += "●") ;
         return output; }
        private void setStars() { this.Text = starFiller(this.Value.Length); }
        public EntryCellPassWord()
        {
           
            this.Value = ""; this.PropertyChanged += (object sender, System.ComponentModel.PropertyChangedEventArgs e) => { if (e.PropertyName == "Text") { var txtLen = this.Text.Length; var txtVal = this.Text; var mdlLen = this.Value.Length; if (txtLen > mdlLen) { this.Value += txtVal.Substring(txtLen - 1); } else { this.Value = this.Value.Substring(0, txtLen); } setStars(); } }; } }
}
