using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.UI.WebControls;

namespace UCENTRIK.LIB.App_Controls.ServerControls
{

    public class UcRadioButton : RadioButton
    {
        //private string m_value;


        protected string m_value
        {
            get
            {
                string _m_value = "";
                Object objViewStateValue = this.ViewState[this.ID + "Value"];
                if (objViewStateValue != null)
                    _m_value = Convert.ToString(objViewStateValue);

                return _m_value;
            }
            set
            {
                this.ViewState.Remove(this.ID + "Value");
                this.ViewState.Add(this.ID + "Value", value);
            }
        }






        public string UcValue
        {
            get { return m_value; }
            set { m_value = value; }
        }

        public UcRadioButton()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }

}
